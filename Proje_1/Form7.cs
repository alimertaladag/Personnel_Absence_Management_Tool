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
    public partial class Form7 : Form
    {
        int personelId;
        MySqlConnection baglanti = new MySqlConnection("Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';");

        public Form7()
        {
            InitializeComponent();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            IzinHakkiGetir();
            GecmisIzinleriGetir();
            BugunIzinDurumu();
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



        private void GecmisIzinleriGetir()
        {
            baglanti.Open();
            MySqlDataAdapter da = new MySqlDataAdapter("SELECT baslangic_tarihi, bitis_tarihi, aciklama FROM izinler WHERE personel_id=@id", baglanti);
            da.SelectCommand.Parameters.AddWithValue("@id", personelId);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            baglanti.Close();
        }

        private void BugunIzinDurumu()
        {
            baglanti.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT COUNT(*) FROM izinler WHERE personel_id=@id AND CURDATE() BETWEEN baslangic_tarihi AND bitis_tarihi", baglanti);
            cmd.Parameters.AddWithValue("@id", personelId);
            int sayi = Convert.ToInt32(cmd.ExecuteScalar());
            if (sayi > 0)
                label2.Text = "Bugün izinlisiniz";
            else
                label2.Text = "Bugün çalışıyorsunuz";
            baglanti.Close();
        }


    }
}
