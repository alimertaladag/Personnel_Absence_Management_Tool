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
    public partial class Form3 : Form
    {
        double butonOpacity = 0.0;
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string kullaniciAdi = textBox1.Text.Trim();
                string sifre = textBox2.Text;

                if (kullaniciAdi == "" || sifre == "")
                {
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Bu örnekte sabit kullanıcı adı/şifre var. Gerçekte veritabanından kontrol edilir.
                if(kullaniciAdi != "yonetici" && sifre != "1234")
                {
                    MessageBox.Show("Kullanıcı adı ve şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (kullaniciAdi != "yonetici")
                {
                    MessageBox.Show("Kullanıcı adı hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (sifre != "1234")
                {
                    MessageBox.Show("Şifre hatalı.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Giriş başarılı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();
                    // yeni form gösterilebilir
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
