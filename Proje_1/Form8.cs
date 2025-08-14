using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_1
{
    public partial class Form8 : Form
    {
        int personelId;
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';");

        public Form8()
        {
            InitializeComponent();
        }
        private void Form8_Load(object sender, EventArgs e)
        {
            IzinHakkiGetir();
        }

        private void IzinHakkiGetir()
        {
            if (label1 == null)
            {
                MessageBox.Show("label1 bulunamadı. Designer'da kontrolün Name özelliğini kontrol et.");
                return;
            }

            // Host formdan kullanıcı adı çözmeye çalış
            string kullaniciAdi = TryResolveKullaniciAdiFromParent();

            // Fallback: Windows kullanıcı adı (çok nadiren eşleşir)
            if (string.IsNullOrWhiteSpace(kullaniciAdi))
                kullaniciAdi = Environment.UserName;

            // Eğer kullaniciAdi yoksa, personelId ile dene (eğer daha önce set edilmişse)
            if (string.IsNullOrWhiteSpace(kullaniciAdi) && personelId <= 0)
            {
                label1.Text = "Kalan İzin Hakkınız : Bilinmiyor";
                return;
            }

            try
            {
                using (var cnn = new MySqlConnection("Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';"))
                {
                    cnn.Open();

                    object sonuc = null;

                    if (!string.IsNullOrWhiteSpace(kullaniciAdi))
                    {
                        using (var cmd = new MySqlCommand("SELECT izin_gun_sayisi, id FROM personel WHERE kullanici_adi = @kadi LIMIT 1", cnn))
                        {
                            cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                            using (var reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    sonuc = reader["izin_gun_sayisi"];
                                    // personelId'yi de al (ileride talep için kullanışlı)
                                    if (reader["id"] != DBNull.Value)
                                        personelId = Convert.ToInt32(reader["id"]);
                                }
                            }
                        }
                    }

                    // Eğer hâlâ sonuç yoksa ve personelId mevcutsa, id ile sorgula
                    if ((sonuc == null || sonuc == DBNull.Value) && personelId > 0)
                    {
                        using (var cmd2 = new MySqlCommand("SELECT izin_gun_sayisi FROM personel WHERE id = @id LIMIT 1", cnn))
                        {
                            cmd2.Parameters.AddWithValue("@id", personelId);
                            sonuc = cmd2.ExecuteScalar();
                        }
                    }

                    // Sonuç hâlâ null ise isteğe bağlı fallback: tablodan ilk kaydı al (UYARI ile)
                    bool usedFallback = false;
                    if (sonuc == null || sonuc == DBNull.Value)
                    {
                        using (var cmd3 = new MySqlCommand("SELECT izin_gun_sayisi, id FROM personel LIMIT 1", cnn))
                        {
                            using (var reader3 = cmd3.ExecuteReader())
                            {
                                if (reader3.Read())
                                {
                                    sonuc = reader3["izin_gun_sayisi"];
                                    if (reader3["id"] != DBNull.Value)
                                        personelId = Convert.ToInt32(reader3["id"]);
                                    usedFallback = true;
                                }
                            }
                        }
                    }

                    if (sonuc == null || sonuc == DBNull.Value)
                    {
                        label1.Text = "Kalan İzin Hakkınız : Kayıt bulunamadı";
                        return;
                    }

                    if (int.TryParse(sonuc.ToString(), out int izinSayisi))
                    {
                        if (usedFallback)
                            label1.Text = $"Kalan İzin Hakkınız : {izinSayisi} gün (TABLODAN fallback)";
                        else
                            label1.Text = $"Kalan İzin Hakkınız : {izinSayisi} gün";
                    }
                    else
                    {
                        label1.Text = "Kalan İzin Hakkınız : Bilinmiyor";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("İzin bilgisi alınırken hata oluştu: " + ex.Message);
            }
        }

        private string TryResolveKullaniciAdiFromParent()
        {
            try
            {
                Form hostForm = this.Parent?.FindForm() ?? this.FindForm();
                if (hostForm == null) return null;

                // Public string property'leri tara (örn. KullaniciAdi, username, Email, UserName)
                var props = hostForm.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                foreach (var p in props)
                {
                    if (p.PropertyType == typeof(string))
                    {
                        string name = p.Name.ToLower();
                        if (name.Contains("kullanici") || name.Contains("kadi") || name.Contains("username") || name.Contains("user") || name.Contains("mail"))
                        {
                            object val = p.GetValue(hostForm);
                            if (val is string s && !string.IsNullOrWhiteSpace(s))
                                return s;
                        }
                    }
                }

                // Public string field'leri tara
                var fields = hostForm.GetType().GetFields(BindingFlags.Public | BindingFlags.Instance);
                foreach (var f in fields)
                {
                    if (f.FieldType == typeof(string))
                    {
                        string name = f.Name.ToLower();
                        if (name.Contains("kullanici") || name.Contains("kadi") || name.Contains("username") || name.Contains("user") || name.Contains("mail"))
                        {
                            object val = f.GetValue(hostForm);
                            if (val is string s && !string.IsNullOrWhiteSpace(s))
                                return s;
                        }
                    }
                }

                // Host form üzerindeki kontrolleri tara (Label, TextBox vs)
                foreach (Control c in hostForm.Controls)
                {
                    if (c == null) continue;
                    string ctrlName = c.Name?.ToLower() ?? "";

                    if (ctrlName.Contains("kullanici") || ctrlName.Contains("kadi") || ctrlName.Contains("username") || ctrlName.Contains("user") || ctrlName.Contains("mail"))
                    {
                        if (!string.IsNullOrWhiteSpace(c.Text))
                            return c.Text;
                    }

                    // Tag alanında tutuluyor olabilir
                    if (c.Tag != null && c.Tag is string tagStr && !string.IsNullOrWhiteSpace(tagStr))
                    {
                        if (tagStr.Contains("@") || tagStr.Length > 2)
                            return tagStr;
                    }
                }
            }
            catch
            {
                // başarısızsa null dön
            }

            return null;
        }



        private void button1_Click(object sender, EventArgs e)
        {
            DateTime baslangic = dateTimePicker1.Value.Date;
            DateTime bitis = dateTimePicker2.Value.Date;

            if (bitis < baslangic)
            {
                MessageBox.Show("Bitiş tarihi başlangıç tarihinden önce olamaz.");
                return;
            }

            // Eğer personelId yoksa, eğer hosttan kullaniciAdi alınabiliyorsa personelId'yi çek
            if (personelId <= 0)
            {
                string kullaniciAdi = TryResolveKullaniciAdiFromParent();
                if (!string.IsNullOrWhiteSpace(kullaniciAdi))
                {
                    try
                    {
                        using (var cnn = new MySqlConnection("Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';"))
                        {
                            cnn.Open();
                            using (var cmd = new MySqlCommand("SELECT id FROM personel WHERE kullanici_adi = @kadi LIMIT 1", cnn))
                            {
                                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                                var res = cmd.ExecuteScalar();
                                if (res != null && res != DBNull.Value)
                                    personelId = Convert.ToInt32(res);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Personel bilgisi alınırken hata: " + ex.Message);
                    }
                }
            }

            if (personelId <= 0)
            {
                MessageBox.Show("Personel kimliği bulunamadığı için izin talebi gönderilemiyor. (Oturum bilgisi eksik)");
                return;
            }

            try
            {
                using (var cnn = new MySqlConnection("Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';"))
                {
                    cnn.Open();
                    using (var cmd = new MySqlCommand("INSERT INTO izin_talepleri (personel_id, baslangic_tarihi, bitis_tarihi) VALUES (@pid, @bas, @bit)", cnn))
                    {
                        cmd.Parameters.AddWithValue("@pid", personelId);
                        cmd.Parameters.AddWithValue("@bas", baslangic);
                        cmd.Parameters.AddWithValue("@bit", bitis);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("İzin talebiniz gönderildi. Onay bekleniyor.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("İzin talebi gönderilirken hata oluştu: " + ex.Message);
            }
        }

    }
}
