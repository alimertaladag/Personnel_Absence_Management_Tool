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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private async void Form6_Load(object sender, EventArgs e)
        {
            // Adana Büyükşehir Belediyesi duyurular sayfasını aç
            webBrowser1.ScriptErrorsSuppressed = true; // Script hatalarını gizle
            webBrowser1.Navigate("https://www.adana.bel.tr/tr/duyuru");
        }
    }
}
