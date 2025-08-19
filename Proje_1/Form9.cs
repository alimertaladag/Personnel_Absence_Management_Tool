using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Proje_1.Form2;

namespace Proje_1
{
    public partial class Form9 : Form
    {
        private int personelId; // Global'den doldurulacak
        private readonly MySqlConnection baglanti =
            new MySqlConnection("Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';");


        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            string globalIdStr = GlobalKullanici.ID; // GlobalKullanici.ID string tipinde olmalı

            if (!int.TryParse(globalIdStr, out personelId) || personelId <= 0)
            {
                MessageBox.Show("Kullanıcı ID'si geçersiz. Lütfen tekrar giriş yapın.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close(); // veya etkinliği sonlandır
                return;
            }

            // Güvenlik/UX
            textBox1.UseSystemPasswordChar = true;
            textBox2.UseSystemPasswordChar = true;
            textBox3.UseSystemPasswordChar = true;

            textBox1.MaxLength = 6;
            textBox2.MaxLength = 6;
            textBox3.MaxLength = 6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mevcutSifre = textBox1.Text.Trim();
            string yeniSifre = textBox2.Text.Trim();
            string yeniSifreTekrar = textBox3.Text.Trim();

            if (string.IsNullOrEmpty(mevcutSifre) || string.IsNullOrEmpty(yeniSifre) || string.IsNullOrEmpty(yeniSifreTekrar))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (yeniSifre != yeniSifreTekrar)
            {
                MessageBox.Show("Yeni şifreler eşleşmiyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                baglanti.Open();

                // Önce mevcut şifre doğru mu kontrol et
                MySqlCommand kontrolKomut = new MySqlCommand("SELECT sifre FROM personel WHERE id = @id", baglanti);
                kontrolKomut.Parameters.AddWithValue("@id", personelId);

                object sonuc = kontrolKomut.ExecuteScalar();

                if (sonuc == null)
                {
                    MessageBox.Show("Kullanıcı bulunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (sonuc.ToString() != mevcutSifre)
                {
                    MessageBox.Show("Mevcut şifreniz yanlış!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Şifreyi güncelle
                    MySqlCommand guncelleKomut = new MySqlCommand("UPDATE personel SET sifre = @yeniSifre WHERE id = @id", baglanti);
                    guncelleKomut.Parameters.AddWithValue("@yeniSifre", yeniSifre);
                    guncelleKomut.Parameters.AddWithValue("@id", personelId);

                    int etkilenen = guncelleKomut.ExecuteNonQuery();

                    if (etkilenen > 0)
                        MessageBox.Show("Şifreniz başarıyla güncellendi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Şifre güncellenemedi!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                baglanti.Close();
            }
        }
    }
}
