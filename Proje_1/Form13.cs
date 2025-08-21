using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Proje_1
{
    public partial class FormIzinIstatistikleri : Form
    {
        // Burayı kendi veritabanı bilgilerine göre güncelle
        private readonly string connStr = "Server=localhost;Database=personel_izin_takip;Uid=root;Pwd=root;SslMode=none;";

        // Çizim için saklanan veriler
        private string[] labels = new string[0];
        private double[] values = new double[0];
        private RectangleF[] barRects = new RectangleF[0];

        // Tooltip için
        private ToolTip tooltip = new ToolTip();
        private int lastHoverIndex = -1;

        public FormIzinIstatistikleri()
        {
            InitializeComponent();

            // Tooltip davranışı (isteğe göre ayarla)
            tooltip.AutoPopDelay = 3000;
            tooltip.InitialDelay = 400;
            tooltip.ReshowDelay = 100;
            tooltip.ShowAlways = true;
        }

        private void FormIzinIstatistikleri_Load(object sender, EventArgs e)
        {
            LoadDataAndRefresh();
        }

        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadDataAndRefresh();
        }

        private void LoadDataAndRefresh()
        {
            // SQL ile yıllık-aylık gruplanmış onaylı ve bitiş tarihi geçmiş izinleri çek
            string sql = @"
                SELECT
                    DATE_FORMAT(bitis_tarihi, '%Y-%m') AS yil_ay,
                    COUNT(*) AS izin_sayisi
                FROM izin_talepleri
                WHERE bitis_tarihi < CURDATE()
                  AND (
                        durum = 'Onaylandı'
                     OR durum = 'Onaylandi'
                     OR durum = 'onaylandı'
                     OR durum = 'onaylandi'
                     OR durum = '1'
                     OR durum = 1
                  )
                GROUP BY yil_ay
                ORDER BY yil_ay;";

            try
            {
                using (var conn = new MySqlConnection(connStr))
                {
                    conn.Open();
                    using (var da = new MySqlDataAdapter(sql, conn))
                    {
                        var dt = new DataTable();
                        da.Fill(dt);

                        if (dt.Rows.Count == 0)
                        {
                            labels = new string[0];
                            values = new double[0];
                            barRects = new RectangleF[0];
                            pnlChart.Invalidate();
                            MessageBox.Show("Onaylı ve süresi geçmiş izin bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        labels = dt.AsEnumerable().Select(r => r.Field<string>("yil_ay")).ToArray();
                        values = dt.AsEnumerable().Select(r => Convert.ToDouble(r["izin_sayisi"])).ToArray();
                        barRects = new RectangleF[values.Length];
                    }
                }
            }
            catch (Exception ex)
            {
                labels = new string[0];
                values = new double[0];
                barRects = new RectangleF[0];
                MessageBox.Show("Veri yüklenirken hata oluştu:\n" + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // yeniden çiz
            pnlChart.Invalidate();
        }

        private void pnlChart_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.Clear(Color.White);
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var rect = pnlChart.ClientRectangle;
            int marginLeft = 70;
            int marginRight = 20;
            int marginTop = 30;
            int marginBottom = 70;

            int chartX = rect.Left + marginLeft;
            int chartY = rect.Top + marginTop;
            int chartWidth = rect.Width - marginLeft - marginRight;
            int chartHeight = rect.Height - marginTop - marginBottom;

            // Başlık
            using (var titleFont = new Font("Segoe UI", 10, FontStyle.Bold))
            using (var titleBrush = new SolidBrush(Color.Black))
            {
                g.DrawString("Aylara Göre İzin İstatistikleri", titleFont, titleBrush, chartX, 4);
            }

            if (values == null || values.Length == 0)
            {
                using (var f = new Font("Segoe UI", 10))
                using (var b = new SolidBrush(Color.Gray))
                {
                    string msg = "Veri bulunamadı.";
                    var sz = g.MeasureString(msg, f);
                    g.DrawString(msg, f, b, rect.Width / 2 - sz.Width / 2, rect.Height / 2 - sz.Height / 2);
                }
                return;
            }

            // Y ekseni max ve adım
            double maxVal = values.Max();
            if (maxVal <= 0) maxVal = 1;
            int yTicks = 5;

            // Güzel bir maksimum değer bul
            double magnitude = Math.Pow(10, Math.Floor(Math.Log10(maxVal)));
            double niceMax = Math.Ceiling(maxVal / magnitude) * magnitude;
            if (niceMax == 0) niceMax = maxVal;
            double tickStep = niceMax / yTicks;

            // Y ızgara ve etiketler
            using (var gridPen = new Pen(Color.FromArgb(220, 220, 220)))
            using (var font = new Font("Segoe UI", 8))
            using (var textBrush = new SolidBrush(Color.Black))
            {
                for (int i = 0; i <= yTicks; i++)
                {
                    double val = i * tickStep;
                    int y = chartY + chartHeight - (int)Math.Round((val / niceMax) * chartHeight);
                    g.DrawLine(gridPen, chartX, y, chartX + chartWidth, y);
                    string label = val.ToString("0");
                    var size = g.MeasureString(label, font);
                    g.DrawString(label, font, textBrush, chartX - 10 - size.Width, y - size.Height / 2);
                }
            }

            // Barları çiz
            int n = values.Length;
            float barWidth = Math.Max(8f, (float)(chartWidth / (double)n * 0.6));
            float gap = (chartWidth - n * barWidth) / (n + 1);

            using (var barBrush = new SolidBrush(Color.FromArgb(100, 149, 237))) // cornflower
            using (var borderPen = new Pen(Color.FromArgb(60, 90, 160)))
            using (var font = new Font("Segoe UI", 8))
            using (var textBrush = new SolidBrush(Color.Black))
            {
                for (int i = 0; i < n; i++)
                {
                    float x = chartX + gap + i * (barWidth + gap);
                    float height = (float)((values[i] / niceMax) * chartHeight);
                    float y = chartY + chartHeight - height;
                    var r = new RectangleF(x, y, barWidth, height);

                    g.FillRectangle(barBrush, r);
                    g.DrawRectangle(borderPen, x, y, barWidth, height);

                    // bar rect kaydet (tooltip için)
                    barRects[i] = r;

                    // değer üstünde göster
                    string valTxt = values[i].ToString("0");
                    var vsz = g.MeasureString(valTxt, font);
                    float vx = x + barWidth / 2 - vsz.Width / 2;
                    float vy = y - vsz.Height - 2;
                    g.DrawString(valTxt, font, textBrush, vx, vy);

                    // X etiketleri
                    string lbl = labels[i];
                    var lsz = g.MeasureString(lbl, font);
                    float lx = x + barWidth / 2 - lsz.Width / 2;
                    float ly = chartY + chartHeight + 6;

                    // Eğer etiket çok genişse hafifçe döndür
                    if (lsz.Width > barWidth + 6)
                    {
                        g.TranslateTransform(lx + lsz.Width / 2, ly + lsz.Height / 2);
                        g.RotateTransform(-45);
                        g.DrawString(lbl, font, textBrush, -lsz.Width / 2, -lsz.Height / 2);
                        g.ResetTransform();
                    }
                    else
                    {
                        g.DrawString(lbl, font, textBrush, lx, ly);
                    }
                }
            }

            // Ekseni çiz (kenarlar)
            using (var axisPen = new Pen(Color.Black, 1.2f))
            {
                g.DrawLine(axisPen, chartX, chartY, chartX, chartY + chartHeight); // Y
                g.DrawLine(axisPen, chartX, chartY + chartHeight, chartX + chartWidth, chartY + chartHeight); // X
            }
        }

        private void pnlChart_MouseMove(object sender, MouseEventArgs e)
        {
            if (barRects == null || barRects.Length == 0) return;

            for (int i = 0; i < barRects.Length; i++)
            {
                if (barRects[i].Contains(e.Location))
                {
                    if (lastHoverIndex != i)
                    {
                        lastHoverIndex = i;
                        tooltip.Show($"{labels[i]}: {values[i]:0}", pnlChart, e.Location.X + 12, e.Location.Y + 12, 2000);
                    }
                    return;
                }
            }

            // eğer hiçbiri değilse tooltip gizle
            lastHoverIndex = -1;
            tooltip.Hide(pnlChart);
        }
    }
}
