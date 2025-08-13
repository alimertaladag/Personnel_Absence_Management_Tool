namespace Proje_1
{
    partial class FormYardim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

                /// <summary>
                 /// Required method for Designer support - do not modify
                 /// the contents of this method with the code editor.
                 /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageFaq = new System.Windows.Forms.TabPage();
            this.txtFaqArama = new System.Windows.Forms.TextBox();
            this.dataGridViewFaq = new System.Windows.Forms.DataGridView();
            this.rtbFaqCevap = new System.Windows.Forms.RichTextBox();
            this.tabPageRehber = new System.Windows.Forms.TabPage();
            this.rtbKullanim = new System.Windows.Forms.RichTextBox();
            this.tabPageIletisim = new System.Windows.Forms.TabPage();
            this.lblDestekEmail = new System.Windows.Forms.LinkLabel();
            this.lblTelefon = new System.Windows.Forms.Label();
            this.btnKopyalaTel = new System.Windows.Forms.Button();
            this.groupBoxGeriBildirim = new System.Windows.Forms.GroupBox();
            this.txtGeriBildirimKonu = new System.Windows.Forms.TextBox();
            this.txtGeriBildirimMesaj = new System.Windows.Forms.TextBox();
            this.btnGeriBildirimGonder = new System.Windows.Forms.Button();
            this.labelVersiyon = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tabControl1.SuspendLayout();
            this.tabPageFaq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaq)).BeginInit();
            this.tabPageRehber.SuspendLayout();
            this.tabPageIletisim.SuspendLayout();
            this.groupBoxGeriBildirim.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageFaq);
            this.tabControl1.Controls.Add(this.tabPageRehber);
            this.tabControl1.Controls.Add(this.tabPageIletisim);
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(651, 451);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPageFaq
            // 
            this.tabPageFaq.Controls.Add(this.txtFaqArama);
            this.tabPageFaq.Controls.Add(this.dataGridViewFaq);
            this.tabPageFaq.Controls.Add(this.rtbFaqCevap);
            this.tabPageFaq.Location = new System.Drawing.Point(4, 22);
            this.tabPageFaq.Name = "tabPageFaq";
            this.tabPageFaq.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageFaq.Size = new System.Drawing.Size(643, 425);
            this.tabPageFaq.TabIndex = 0;
            this.tabPageFaq.Text = "SSS (Sık Sorulan Sorular)";
            this.tabPageFaq.UseVisualStyleBackColor = true;
            // 
            // txtFaqArama
            // 
            this.txtFaqArama.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFaqArama.Location = new System.Drawing.Point(13, 13);
            this.txtFaqArama.Name = "txtFaqArama";
            this.txtFaqArama.Size = new System.Drawing.Size(618, 20);
            this.txtFaqArama.TabIndex = 0;
            // 
            // dataGridViewFaq
            // 
            this.dataGridViewFaq.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFaq.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewFaq.Location = new System.Drawing.Point(13, 43);
            this.dataGridViewFaq.MultiSelect = false;
            this.dataGridViewFaq.Name = "dataGridViewFaq";
            this.dataGridViewFaq.ReadOnly = true;
            this.dataGridViewFaq.RowTemplate.Height = 25;
            this.dataGridViewFaq.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFaq.Size = new System.Drawing.Size(617, 225);
            this.dataGridViewFaq.TabIndex = 1;
            // 
            // rtbFaqCevap
            // 
            this.rtbFaqCevap.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbFaqCevap.Location = new System.Drawing.Point(13, 277);
            this.rtbFaqCevap.Name = "rtbFaqCevap";
            this.rtbFaqCevap.ReadOnly = true;
            this.rtbFaqCevap.Size = new System.Drawing.Size(618, 131);
            this.rtbFaqCevap.TabIndex = 2;
            this.rtbFaqCevap.Text = "";
            // 
            // tabPageRehber
            // 
            this.tabPageRehber.Controls.Add(this.rtbKullanim);
            this.tabPageRehber.Location = new System.Drawing.Point(4, 22);
            this.tabPageRehber.Name = "tabPageRehber";
            this.tabPageRehber.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRehber.Size = new System.Drawing.Size(643, 425);
            this.tabPageRehber.TabIndex = 1;
            this.tabPageRehber.Text = "Kullanım Rehberi";
            this.tabPageRehber.UseVisualStyleBackColor = true;
            // 
            // rtbKullanim
            // 
            this.rtbKullanim.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbKullanim.Location = new System.Drawing.Point(13, 13);
            this.rtbKullanim.Name = "rtbKullanim";
            this.rtbKullanim.ReadOnly = true;
            this.rtbKullanim.Size = new System.Drawing.Size(618, 395);
            this.rtbKullanim.TabIndex = 0;
            this.rtbKullanim.Text = "";
            // 
            // tabPageIletisim
            // 
            this.tabPageIletisim.Controls.Add(this.lblDestekEmail);
            this.tabPageIletisim.Controls.Add(this.lblTelefon);
            this.tabPageIletisim.Controls.Add(this.btnKopyalaTel);
            this.tabPageIletisim.Controls.Add(this.groupBoxGeriBildirim);
            this.tabPageIletisim.Location = new System.Drawing.Point(4, 22);
            this.tabPageIletisim.Name = "tabPageIletisim";
            this.tabPageIletisim.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageIletisim.Size = new System.Drawing.Size(643, 425);
            this.tabPageIletisim.TabIndex = 2;
            this.tabPageIletisim.Text = "İletişim / Geri Bildirim";
            this.tabPageIletisim.UseVisualStyleBackColor = true;
            // 
            // lblDestekEmail
            // 
            this.lblDestekEmail.AutoSize = true;
            this.lblDestekEmail.Location = new System.Drawing.Point(17, 17);
            this.lblDestekEmail.Name = "lblDestekEmail";
            this.lblDestekEmail.Size = new System.Drawing.Size(112, 13);
            this.lblDestekEmail.TabIndex = 0;
            this.lblDestekEmail.TabStop = true;
            this.lblDestekEmail.Text = "destek@example.com";
            // 
            // lblTelefon
            // 
            this.lblTelefon.AutoSize = true;
            this.lblTelefon.Location = new System.Drawing.Point(17, 43);
            this.lblTelefon.Name = "lblTelefon";
            this.lblTelefon.Size = new System.Drawing.Size(88, 13);
            this.lblTelefon.TabIndex = 1;
            this.lblTelefon.Text = "+90 5xx xxx xx xx";
            // 
            // btnKopyalaTel
            // 
            this.btnKopyalaTel.Location = new System.Drawing.Point(129, 39);
            this.btnKopyalaTel.Name = "btnKopyalaTel";
            this.btnKopyalaTel.Size = new System.Drawing.Size(77, 22);
            this.btnKopyalaTel.TabIndex = 2;
            this.btnKopyalaTel.Text = "Kopyala";
            this.btnKopyalaTel.UseVisualStyleBackColor = true;
            // 
            // groupBoxGeriBildirim
            // 
            this.groupBoxGeriBildirim.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxGeriBildirim.Controls.Add(this.txtGeriBildirimKonu);
            this.groupBoxGeriBildirim.Controls.Add(this.txtGeriBildirimMesaj);
            this.groupBoxGeriBildirim.Controls.Add(this.btnGeriBildirimGonder);
            this.groupBoxGeriBildirim.Location = new System.Drawing.Point(17, 78);
            this.groupBoxGeriBildirim.Name = "groupBoxGeriBildirim";
            this.groupBoxGeriBildirim.Size = new System.Drawing.Size(609, 321);
            this.groupBoxGeriBildirim.TabIndex = 3;
            this.groupBoxGeriBildirim.TabStop = false;
            this.groupBoxGeriBildirim.Text = "Geri Bildirim / Destek Talebi";
            // 
            // txtGeriBildirimKonu
            // 
            this.txtGeriBildirimKonu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeriBildirimKonu.Location = new System.Drawing.Point(13, 22);
            this.txtGeriBildirimKonu.Name = "txtGeriBildirimKonu";
            this.txtGeriBildirimKonu.Size = new System.Drawing.Size(583, 20);
            this.txtGeriBildirimKonu.TabIndex = 0;
            // 
            // txtGeriBildirimMesaj
            // 
            this.txtGeriBildirimMesaj.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGeriBildirimMesaj.Location = new System.Drawing.Point(13, 52);
            this.txtGeriBildirimMesaj.Multiline = true;
            this.txtGeriBildirimMesaj.Name = "txtGeriBildirimMesaj";
            this.txtGeriBildirimMesaj.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGeriBildirimMesaj.Size = new System.Drawing.Size(583, 217);
            this.txtGeriBildirimMesaj.TabIndex = 1;
            // 
            // btnGeriBildirimGonder
            // 
            this.btnGeriBildirimGonder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGeriBildirimGonder.Location = new System.Drawing.Point(514, 277);
            this.btnGeriBildirimGonder.Name = "btnGeriBildirimGonder";
            this.btnGeriBildirimGonder.Size = new System.Drawing.Size(81, 26);
            this.btnGeriBildirimGonder.TabIndex = 2;
            this.btnGeriBildirimGonder.Text = "Gönder";
            this.btnGeriBildirimGonder.UseVisualStyleBackColor = true;
            // 
            // labelVersiyon
            // 
            this.labelVersiyon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelVersiyon.AutoSize = true;
            this.labelVersiyon.Location = new System.Drawing.Point(10, 468);
            this.labelVersiyon.Name = "labelVersiyon";
            this.labelVersiyon.Size = new System.Drawing.Size(58, 13);
            this.labelVersiyon.TabIndex = 1;
            this.labelVersiyon.Text = "Sürüm: 1.0";
            // 
            // FormYardim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 491);
            this.Controls.Add(this.labelVersiyon);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(688, 530);
            this.Name = "FormYardim";
            this.Text = "Yardım - Destek";
            this.tabControl1.ResumeLayout(false);
            this.tabPageFaq.ResumeLayout(false);
            this.tabPageFaq.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFaq)).EndInit();
            this.tabPageRehber.ResumeLayout(false);
            this.tabPageIletisim.ResumeLayout(false);
            this.tabPageIletisim.PerformLayout();
            this.groupBoxGeriBildirim.ResumeLayout(false);
            this.groupBoxGeriBildirim.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

                #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageFaq;
        private System.Windows.Forms.TextBox txtFaqArama;
        private System.Windows.Forms.DataGridView dataGridViewFaq;
        private System.Windows.Forms.RichTextBox rtbFaqCevap;
        private System.Windows.Forms.TabPage tabPageRehber;
        private System.Windows.Forms.RichTextBox rtbKullanim;
        private System.Windows.Forms.TabPage tabPageIletisim;
        private System.Windows.Forms.LinkLabel lblDestekEmail;
        private System.Windows.Forms.Label lblTelefon;
        private System.Windows.Forms.Button btnKopyalaTel;
        private System.Windows.Forms.GroupBox groupBoxGeriBildirim;
        private System.Windows.Forms.TextBox txtGeriBildirimKonu;
        private System.Windows.Forms.TextBox txtGeriBildirimMesaj;
        private System.Windows.Forms.Button btnGeriBildirimGonder;
        private System.Windows.Forms.Label labelVersiyon;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
