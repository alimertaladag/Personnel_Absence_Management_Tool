// File: IzinYonetimiForm.Designer.cs
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Proje_1
{
    partial class IzinYonetimiForm
    {
        private IContainer components = null;

        private DataGridView dgvIzinler;
        private ComboBox cmbPersonel;
        private DateTimePicker dtpBaslama;
        private DateTimePicker dtpBitis;
        private NumericUpDown nudGunSayisi;
        private TextBox txtNeden;
        private TextBox txtDurum;
        private TextBox txtAra;

        private Button btnAra;
        private Button btnEkle;
        private Button btnDuzenle;
        private Button btnSil;
        private Button btnOnayla;
        private Button btnReddet;

        private Label lblPersonel;
        private Label lblBas;
        private Label lblBit;
        private Label lblGun;
        private Label lblNeden;
        private Label lblDurum;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.dgvIzinler = new System.Windows.Forms.DataGridView();
            this.cmbPersonel = new System.Windows.Forms.ComboBox();
            this.dtpBaslama = new System.Windows.Forms.DateTimePicker();
            this.dtpBitis = new System.Windows.Forms.DateTimePicker();
            this.nudGunSayisi = new System.Windows.Forms.NumericUpDown();
            this.txtNeden = new System.Windows.Forms.TextBox();
            this.txtDurum = new System.Windows.Forms.TextBox();
            this.txtAra = new System.Windows.Forms.TextBox();
            this.btnAra = new System.Windows.Forms.Button();
            this.btnEkle = new System.Windows.Forms.Button();
            this.btnDuzenle = new System.Windows.Forms.Button();
            this.btnSil = new System.Windows.Forms.Button();
            this.btnOnayla = new System.Windows.Forms.Button();
            this.btnReddet = new System.Windows.Forms.Button();
            this.lblPersonel = new System.Windows.Forms.Label();
            this.lblBas = new System.Windows.Forms.Label();
            this.lblBit = new System.Windows.Forms.Label();
            this.lblGun = new System.Windows.Forms.Label();
            this.lblNeden = new System.Windows.Forms.Label();
            this.lblDurum = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGunSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIzinler
            // 
            this.dgvIzinler.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvIzinler.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIzinler.Location = new System.Drawing.Point(12, 44);
            this.dgvIzinler.MultiSelect = false;
            this.dgvIzinler.Name = "dgvIzinler";
            this.dgvIzinler.ReadOnly = true;
            this.dgvIzinler.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIzinler.Size = new System.Drawing.Size(788, 229);
            this.dgvIzinler.TabIndex = 2;
            this.dgvIzinler.SelectionChanged += new System.EventHandler(this.dgvIzinler_SelectionChanged);
            // 
            // cmbPersonel
            // 
            this.cmbPersonel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPersonel.Location = new System.Drawing.Point(110, 296);
            this.cmbPersonel.Name = "cmbPersonel";
            this.cmbPersonel.Size = new System.Drawing.Size(240, 21);
            this.cmbPersonel.TabIndex = 4;
            // 
            // dtpBaslama
            // 
            this.dtpBaslama.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBaslama.Location = new System.Drawing.Point(444, 296);
            this.dtpBaslama.Name = "dtpBaslama";
            this.dtpBaslama.Size = new System.Drawing.Size(120, 20);
            this.dtpBaslama.TabIndex = 6;
            // 
            // dtpBitis
            // 
            this.dtpBitis.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpBitis.Location = new System.Drawing.Point(615, 296);
            this.dtpBitis.Name = "dtpBitis";
            this.dtpBitis.Size = new System.Drawing.Size(120, 20);
            this.dtpBitis.TabIndex = 8;
            // 
            // nudGunSayisi
            // 
            this.nudGunSayisi.Location = new System.Drawing.Point(110, 336);
            this.nudGunSayisi.Maximum = new decimal(new int[] {
            365,
            0,
            0,
            0});
            this.nudGunSayisi.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudGunSayisi.Name = "nudGunSayisi";
            this.nudGunSayisi.Size = new System.Drawing.Size(80, 20);
            this.nudGunSayisi.TabIndex = 10;
            this.nudGunSayisi.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtNeden
            // 
            this.txtNeden.Location = new System.Drawing.Point(270, 336);
            this.txtNeden.Name = "txtNeden";
            this.txtNeden.Size = new System.Drawing.Size(375, 20);
            this.txtNeden.TabIndex = 12;
            // 
            // txtDurum
            // 
            this.txtDurum.Location = new System.Drawing.Point(110, 376);
            this.txtDurum.Name = "txtDurum";
            this.txtDurum.ReadOnly = true;
            this.txtDurum.Size = new System.Drawing.Size(200, 20);
            this.txtDurum.TabIndex = 14;
            // 
            // txtAra
            // 
            this.txtAra.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtAra.Location = new System.Drawing.Point(12, 12);
            this.txtAra.Name = "txtAra";
            this.txtAra.Size = new System.Drawing.Size(260, 23);
            this.txtAra.TabIndex = 0;
            // 
            // btnAra
            // 
            this.btnAra.Location = new System.Drawing.Point(278, 10);
            this.btnAra.Name = "btnAra";
            this.btnAra.Size = new System.Drawing.Size(80, 28);
            this.btnAra.TabIndex = 1;
            this.btnAra.Text = "Ara";
            this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
            // 
            // btnEkle
            // 
            this.btnEkle.Location = new System.Drawing.Point(373, 368);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(100, 32);
            this.btnEkle.TabIndex = 15;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // btnDuzenle
            // 
            this.btnDuzenle.Location = new System.Drawing.Point(491, 368);
            this.btnDuzenle.Name = "btnDuzenle";
            this.btnDuzenle.Size = new System.Drawing.Size(100, 32);
            this.btnDuzenle.TabIndex = 16;
            this.btnDuzenle.Text = "Düzenle";
            this.btnDuzenle.Click += new System.EventHandler(this.btnDuzenle_Click);
            // 
            // btnSil
            // 
            this.btnSil.Location = new System.Drawing.Point(615, 370);
            this.btnSil.Name = "btnSil";
            this.btnSil.Size = new System.Drawing.Size(100, 32);
            this.btnSil.TabIndex = 17;
            this.btnSil.Text = "Sil";
            this.btnSil.Click += new System.EventHandler(this.btnSil_Click);
            // 
            // btnOnayla
            // 
            this.btnOnayla.Location = new System.Drawing.Point(660, 330);
            this.btnOnayla.Name = "btnOnayla";
            this.btnOnayla.Size = new System.Drawing.Size(140, 32);
            this.btnOnayla.TabIndex = 18;
            this.btnOnayla.Text = "Onayla";
            this.btnOnayla.Click += new System.EventHandler(this.btnOnayla_Click);
            // 
            // btnReddet
            // 
            this.btnReddet.Location = new System.Drawing.Point(730, 368);
            this.btnReddet.Name = "btnReddet";
            this.btnReddet.Size = new System.Drawing.Size(140, 32);
            this.btnReddet.TabIndex = 19;
            this.btnReddet.Text = "Reddet";
            this.btnReddet.Click += new System.EventHandler(this.btnReddet_Click);
            // 
            // lblPersonel
            // 
            this.lblPersonel.Location = new System.Drawing.Point(12, 298);
            this.lblPersonel.Name = "lblPersonel";
            this.lblPersonel.Size = new System.Drawing.Size(90, 24);
            this.lblPersonel.TabIndex = 3;
            this.lblPersonel.Text = "Personel:";
            // 
            // lblBas
            // 
            this.lblBas.Location = new System.Drawing.Point(370, 298);
            this.lblBas.Name = "lblBas";
            this.lblBas.Size = new System.Drawing.Size(70, 24);
            this.lblBas.TabIndex = 5;
            this.lblBas.Text = "Başlangıç:";
            // 
            // lblBit
            // 
            this.lblBit.Location = new System.Drawing.Point(570, 298);
            this.lblBit.Name = "lblBit";
            this.lblBit.Size = new System.Drawing.Size(40, 24);
            this.lblBit.TabIndex = 7;
            this.lblBit.Text = "Bitiş:";
            // 
            // lblGun
            // 
            this.lblGun.Location = new System.Drawing.Point(12, 338);
            this.lblGun.Name = "lblGun";
            this.lblGun.Size = new System.Drawing.Size(90, 24);
            this.lblGun.TabIndex = 9;
            this.lblGun.Text = "Gün Sayısı:";
            // 
            // lblNeden
            // 
            this.lblNeden.Location = new System.Drawing.Point(210, 338);
            this.lblNeden.Name = "lblNeden";
            this.lblNeden.Size = new System.Drawing.Size(50, 24);
            this.lblNeden.TabIndex = 11;
            this.lblNeden.Text = "Neden:";
            // 
            // lblDurum
            // 
            this.lblDurum.Location = new System.Drawing.Point(12, 378);
            this.lblDurum.Name = "lblDurum";
            this.lblDurum.Size = new System.Drawing.Size(90, 24);
            this.lblDurum.TabIndex = 13;
            this.lblDurum.Text = "Durum:";
            // 
            // IzinYonetimiForm
            // 
            this.ClientSize = new System.Drawing.Size(899, 481);
            this.Controls.Add(this.txtAra);
            this.Controls.Add(this.btnAra);
            this.Controls.Add(this.dgvIzinler);
            this.Controls.Add(this.lblPersonel);
            this.Controls.Add(this.cmbPersonel);
            this.Controls.Add(this.lblBas);
            this.Controls.Add(this.dtpBaslama);
            this.Controls.Add(this.lblBit);
            this.Controls.Add(this.dtpBitis);
            this.Controls.Add(this.lblGun);
            this.Controls.Add(this.nudGunSayisi);
            this.Controls.Add(this.lblNeden);
            this.Controls.Add(this.txtNeden);
            this.Controls.Add(this.lblDurum);
            this.Controls.Add(this.txtDurum);
            this.Controls.Add(this.btnEkle);
            this.Controls.Add(this.btnDuzenle);
            this.Controls.Add(this.btnSil);
            this.Controls.Add(this.btnOnayla);
            this.Controls.Add(this.btnReddet);
            this.MinimumSize = new System.Drawing.Size(880, 520);
            this.Name = "IzinYonetimiForm";
            this.Text = "İzin Yönetimi";
            this.Load += new System.EventHandler(this.IzinYonetimiForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzinler)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudGunSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
