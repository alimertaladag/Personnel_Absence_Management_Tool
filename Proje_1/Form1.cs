using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Proje_1
{
    public partial class Form1 : Form
    {

        double butonOpacity = 0.0;
        Point hedefLabelKonum, hedefButton1Konum, hedefButton2Konum;
        

        public Form1()
        {
            InitializeComponent();

            // Orijinal hedef konumları kaydet
            hedefLabelKonum = label1.Location;
            hedefButton1Konum = button1.Location;
            hedefButton2Konum = button2.Location;

            // Bu kontrolleri aşağıya kaydır
            label1.Top += 40;
            button1.Top += 40;
            button2.Top += 40;

            // MySQL bağlantısını kontrol et
            string connStr = "server=localhost;port=3306;database=personel_izin_takip;uid=root;pwd=root;charset=utf8mb4;SslMode=None;";

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    MessageBox.Show("MySQL bağlantısı başarılı!");
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Bağlantı hatası: " + ex.Message);
            }
        }



        private void Form1_Load(object sender, EventArgs e)
        {

        }
        


        private void button1_Click(object sender, EventArgs e)
        {
            Form2 personelForm = new Form2();
            personelForm.Show();
            this.Hide();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            Form3 yoneticiForm = new Form3();
            yoneticiForm.Show();
            this.Hide();
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
                button2.Visible = true;

                // Renkleri opacity (alpha) ile güncelle
                button1.BackColor = Color.FromArgb((int)(butonOpacity * 255), 70, 130, 180);
                button2.BackColor = Color.FromArgb((int)(butonOpacity * 255), 25, 25, 112);

                int hız = 1;

                // Label için
                if (label1.Top > hedefLabelKonum.Y)
                    label1.Top -= hız;

                // Button1 için
                if (button1.Top > hedefButton1Konum.Y)
                    button1.Top -= hız;

                // Button2 için
                if (button2.Top > hedefButton2Konum.Y)
                    button2.Top -= hız;

                // Hepsi hedefe geldiyse timer durdur
                if (label1.Top <= hedefLabelKonum.Y &&
                    button1.Top <= hedefButton1Konum.Y &&
                    button2.Top <= hedefButton2Konum.Y)
                {
                    // Konumları düzelt (taşma olmaması için)
                    label1.Top = hedefLabelKonum.Y;
                    button1.Top = hedefButton1Konum.Y;
                    button2.Top = hedefButton2Konum.Y;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
