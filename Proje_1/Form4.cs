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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void OpenChildForm(Form childForm)
        {
            panel2.Controls.Clear();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel2.Controls.Add(childForm);
            childForm.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form5());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form6());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form7());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form8());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form9());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenChildForm(new Form10());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
