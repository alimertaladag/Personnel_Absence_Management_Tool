namespace Proje_1
{
    partial class FormIzinIstatistikleri
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Button btnYenile;
        private System.Windows.Forms.Label lblInfo;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlChart = new System.Windows.Forms.Panel();
            this.btnYenile = new System.Windows.Forms.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pnlChart
            // 
            this.pnlChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Location = new System.Drawing.Point(9, 34);
            this.pnlChart.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Size = new System.Drawing.Size(720, 412);
            this.pnlChart.TabIndex = 0;
            this.pnlChart.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlChart_Paint);
            this.pnlChart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pnlChart_MouseMove);
            // 
            // btnYenile
            // 
            this.btnYenile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnYenile.Location = new System.Drawing.Point(673, 7);
            this.btnYenile.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnYenile.Name = "btnYenile";
            this.btnYenile.Size = new System.Drawing.Size(56, 22);
            this.btnYenile.TabIndex = 1;
            this.btnYenile.Text = "Yenile";
            this.btnYenile.UseVisualStyleBackColor = true;
            this.btnYenile.Click += new System.EventHandler(this.btnYenile_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(9, 12);
            this.lblInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(256, 13);
            this.lblInfo.TabIndex = 2;
            this.lblInfo.Text = "İzin İstatistikleri (Onaylı ve süresi geçmiş izinler - Aylık)";
            // 
            // FormIzinIstatistikleri
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 456);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnYenile);
            this.Controls.Add(this.pnlChart);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormIzinIstatistikleri";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "İzin İstatistikleri";
            this.Load += new System.EventHandler(this.FormIzinIstatistikleri_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
