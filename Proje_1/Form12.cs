// File: IzinYonetimiForm.cs
using System;
using System.Data;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proje_1
{
    public partial class IzinYonetimiForm : Form
    {
        // Değiştir: kendi DB bilgilerine göre
        private readonly string _connectionString = "Server=localhost;Database=personel_izin_takip;Uid=root;Pwd=root;";
        private readonly MySqlConnection _connection;
        private readonly BindingSource _izinBinding = new BindingSource();

        public IzinYonetimiForm()
        {
            InitializeComponent();
            _connection = new MySqlConnection(_connectionString);

            // DataGridView'i BindingSource ile bağla (sağlam ve düzenli)
            dgvIzinler.AutoGenerateColumns = true;
            dgvIzinler.DataSource = _izinBinding;
        }

        private void IzinYonetimiForm_Load(object sender, EventArgs e)
        {
            RefreshPersonelList();
            RefreshIzinList();
        }

        private void RefreshPersonelList()
        {
            try
            {
                var dt = new DataTable();
                using (var da = new MySqlDataAdapter("SELECT id, CONCAT(ad,' ',soyad) AS adsoyad FROM personel ORDER BY ad, soyad", _connection))
                {
                    da.Fill(dt);
                }

                // ComboBox'u DataSource ile doldur (DisplayMember/ValueMember kullan)
                cmbPersonel.DisplayMember = "adsoyad";
                cmbPersonel.ValueMember = "id";
                cmbPersonel.DataSource = dt;
                cmbPersonel.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Personel yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshIzinList(string filter = "")
        {
            try
            {
                var sql = @"
                    SELECT it.id,
                           p.ad AS Ad,
                           p.soyad AS Soyad,
                           it.baslangic_tarihi AS Baslangic,
                           it.bitis_tarihi AS Bitis,
                           it.gun_sayisi AS GunSayisi,
                           it.neden AS Neden,
                           it.durum AS Durum
                    FROM izin_talepleri it
                    INNER JOIN personel p ON p.id = it.personel_id
                ";

                if (!string.IsNullOrWhiteSpace(filter))
                {
                    sql += " WHERE p.ad LIKE @f OR p.soyad LIKE @f OR it.neden LIKE @f OR it.durum LIKE @f";
                }

                var dt = new DataTable();
                using (var cmd = new MySqlCommand(sql, _connection))
                {
                    if (!string.IsNullOrWhiteSpace(filter))
                        cmd.Parameters.AddWithValue("@f", "%" + filter + "%");

                    using (var da = new MySqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }

                _izinBinding.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("İzin listesi yüklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            RefreshIzinList(txtAra.Text.Trim());
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (cmbPersonel.SelectedIndex < 0)
            {
                MessageBox.Show("Lütfen personel seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var personelId = Convert.ToInt32(cmbPersonel.SelectedValue);
            var bas = dtpBaslama.Value.Date;
            var bit = dtpBitis.Value.Date;
            var gunSayisi = (int)nudGunSayisi.Value;
            var neden = txtNeden.Text.Trim();

            try
            {
                using (var cmd = new MySqlCommand(@"
                    INSERT INTO izin_talepleri (personel_id, baslangic_tarihi, bitis_tarihi, gun_sayisi, neden, durum)
                    VALUES (@pid, @b, @bt, @g, @n, @d)", _connection))
                {
                    cmd.Parameters.AddWithValue("@pid", personelId);
                    cmd.Parameters.AddWithValue("@b", bas);
                    cmd.Parameters.AddWithValue("@bt", bit);
                    cmd.Parameters.AddWithValue("@g", gunSayisi);
                    cmd.Parameters.AddWithValue("@n", neden);
                    cmd.Parameters.AddWithValue("@d", "Beklemede");

                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }

                MessageBox.Show("İzin talebi eklendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshIzinList();
            }
            catch (Exception ex)
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
                MessageBox.Show("İzin eklenirken hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetSelectedIzinId()
        {
            if (dgvIzinler.CurrentRow == null) return -1;
            var row = ((DataRowView)dgvIzinler.CurrentRow.DataBoundItem)?.Row;
            if (row == null) return -1;
            if (!row.Table.Columns.Contains("id")) return -1;
            return Convert.ToInt32(row["id"]);
        }

        private void dgvIzinler_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgvIzinler.CurrentRow == null) return;
                var drv = dgvIzinler.CurrentRow.DataBoundItem as DataRowView;
                if (drv == null) return;

                // Tarih ve diğer alanları doldur
                if (drv.Row.Table.Columns.Contains("Baslangic") && drv["Baslangic"] != DBNull.Value)
                    dtpBaslama.Value = Convert.ToDateTime(drv["Baslangic"]);

                if (drv.Row.Table.Columns.Contains("Bitis") && drv["Bitis"] != DBNull.Value)
                    dtpBitis.Value = Convert.ToDateTime(drv["Bitis"]);

                if (drv.Row.Table.Columns.Contains("GunSayisi") && drv["GunSayisi"] != DBNull.Value)
                    nudGunSayisi.Value = Math.Min(nudGunSayisi.Maximum, Convert.ToDecimal(drv["GunSayisi"]));

                if (drv.Row.Table.Columns.Contains("Neden"))
                    txtNeden.Text = drv["Neden"]?.ToString() ?? "";

                if (drv.Row.Table.Columns.Contains("Durum"))
                    txtDurum.Text = drv["Durum"]?.ToString() ?? "";

                // Personeli seç (varsa)
                if (drv.Row.Table.Columns.Contains("Ad") && drv.Row.Table.Columns.Contains("Soyad"))
                {
                    var ad = drv["Ad"]?.ToString() ?? "";
                    var soyad = drv["Soyad"]?.ToString() ?? "";
                    var full = (ad + " " + soyad).Trim();

                    // Eğer cmbPersonel DataSource DataTable ise SelectedValue atayabilirsin:
                    // Öncelikle personel id sütun yoksa ad-soyad ile eşleştirme dene.
                    if (drv.Row.Table.Columns.Contains("id")) // burada id = izin_talepleri.id değil personel id değil; bu satır yoksayılabilir
                    {
                        // yoksa arama ile seçim yap (ad-soyad üzerinden)
                        for (int i = 0; i < cmbPersonel.Items.Count; i++)
                        {
                            var row = (cmbPersonel.Items[i] as DataRowView);
                            if (row != null)
                            {
                                var display = row["adsoyad"]?.ToString() ?? "";
                                if (display == full)
                                {
                                    cmbPersonel.SelectedIndex = i;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                // Sessizce yakala — UI'da selection değişimlerinde beklenmedik veriler olabilir.
            }
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            int izinId = GetSelectedIzinId();
            if (izinId == -1) { MessageBox.Show("Lütfen bir izin seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (cmbPersonel.SelectedIndex < 0) { MessageBox.Show("Personel seçili değil.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            var personelId = Convert.ToInt32(cmbPersonel.SelectedValue);
            var bas = dtpBaslama.Value.Date;
            var bit = dtpBitis.Value.Date;
            var gunSayisi = (int)nudGunSayisi.Value;
            var neden = txtNeden.Text.Trim();

            try
            {
                using (var cmd = new MySqlCommand(@"
                    UPDATE izin_talepleri
                    SET personel_id=@pid, baslangic_tarihi=@b, bitis_tarihi=@bt, gun_sayisi=@g, neden=@n
                    WHERE id=@id", _connection))
                {
                    cmd.Parameters.AddWithValue("@pid", personelId);
                    cmd.Parameters.AddWithValue("@b", bas);
                    cmd.Parameters.AddWithValue("@bt", bit);
                    cmd.Parameters.AddWithValue("@g", gunSayisi);
                    cmd.Parameters.AddWithValue("@n", neden);
                    cmd.Parameters.AddWithValue("@id", izinId);

                    _connection.Open();
                    var affected = cmd.ExecuteNonQuery();
                    _connection.Close();

                    if (affected > 0)
                        MessageBox.Show("İzin güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Güncelleme uygulanmadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    RefreshIzinList();
                }
            }
            catch (Exception ex)
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
                MessageBox.Show("Güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int izinId = GetSelectedIzinId();
            if (izinId == -1) { MessageBox.Show("Silinecek izin seçilmedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            if (MessageBox.Show("Seçili izin silinecek. Devam edilsin mi?", "Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            try
            {
                using (var cmd = new MySqlCommand("DELETE FROM izin_talepleri WHERE id=@id", _connection))
                {
                    cmd.Parameters.AddWithValue("@id", izinId);
                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }

                MessageBox.Show("İzin silindi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshIzinList();
            }
            catch (Exception ex)
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
                MessageBox.Show("Silme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            ChangeDurum("Onaylandi");
        }

        private void btnReddet_Click(object sender, EventArgs e)
        {
            ChangeDurum("Reddedildi");
        }

        private void ChangeDurum(string yeniDurum)
        {
            int izinId = GetSelectedIzinId();
            if (izinId == -1) { MessageBox.Show("Lütfen listeden bir izin seçin.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            try
            {
                using (var cmd = new MySqlCommand("UPDATE izin_talepleri SET durum=@d WHERE id=@id", _connection))
                {
                    cmd.Parameters.AddWithValue("@d", yeniDurum);
                    cmd.Parameters.AddWithValue("@id", izinId);
                    _connection.Open();
                    cmd.ExecuteNonQuery();
                    _connection.Close();
                }

                MessageBox.Show($"Durum '{yeniDurum}' olarak güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshIzinList();
            }
            catch (Exception ex)
            {
                if (_connection.State == ConnectionState.Open) _connection.Close();
                MessageBox.Show("Durum güncelleme hatası: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
