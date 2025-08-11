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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            label1.Text = GlobalKullanici.Ad;
            label2.Text = GlobalKullanici.Soyad;
            label3.Text = GlobalKullanici.Pozisyon;
            label4.Text = GlobalKullanici.KullaniciAdi;
        }
    }
}
