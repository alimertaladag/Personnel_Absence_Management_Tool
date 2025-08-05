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
    public partial class Form1 : Form
    {

        double butonOpacity = 0.0;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 personelForm = new Form2();
            personelForm.Show();
            this.Hide(); // veya this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 yoneticiForm = new Form3();
            yoneticiForm.Show();
            this.Hide(); // veya this.Close();
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
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
