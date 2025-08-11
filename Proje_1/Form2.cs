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

namespace Proje_1
{
    public partial class Form2 : Form
    {
        double butonOpacity = 0.0;

        string connectionString = "Server=localhost;Database=personel_izin_takip;Uid=root;Pwd=root;";

        public Form2()
        {
            InitializeComponent();
        }

        public static class GlobalKullanici
        {
            public static string ID { get; set; }
            public static string Ad { get; set; }
            public static string Soyad { get; set; }
            public static string Pozisyon { get; set; }
            public static string KullaniciAdi { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
                string kullaniciAdi = textBox1.Text;
                string sifre = textBox2.Text;

            if (string.IsNullOrWhiteSpace(kullaniciAdi) || string.IsNullOrWhiteSpace(sifre))
            {
                MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT * FROM personel WHERE kullanici_adi=@kullaniciAdi AND sifre=@sifre";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@kullaniciAdi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sifre", sifre);

                    MySqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        // Global değişkenlere bilgileri ata
                        GlobalKullanici.ID = dr["id"].ToString();
                        GlobalKullanici.Ad = dr["ad"].ToString();
                        GlobalKullanici.Soyad = dr["soyad"].ToString();
                        GlobalKullanici.Pozisyon = dr["pozisyon"].ToString();
                        GlobalKullanici.KullaniciAdi = dr["kullanici_adi"].ToString();

                        MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Pozisyona göre menüye yönlendir
                        if (GlobalKullanici.Pozisyon.ToLower() == "yönetici")
                        {
                            Form4 frm = new Form4();
                            frm.Show();
                        }
                        else
                        {
                            Form4 frm = new Form4();
                            frm.Show();
                        }
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Kullanıcı adı veya şifre hatalı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hata: " + ex.Message);
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            try
            {
                butonOpacity += 0.05;

                if (butonOpacity >= 1.0)
                {
                    butonOpacity = 1.0;
                    timer1.Stop();
                }

                // Butonları görünür yap
                button1.Visible = true;

                // Renkleri opacity (alpha) ile güncelle
                button1.BackColor = Color.FromArgb((int)(butonOpacity * 255), 70, 130, 180);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
