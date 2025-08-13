using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Proje_1
{
    public partial class FormYardim : Form
    {
        private string connStr = "Server=localhost;Database=personel_izin_takip;Uid=root;Pwd='root';";

        public FormYardim()
        {
            InitializeComponent();

            // Load eventi bağla
            this.Load += FormYardim_Load;

            // Eğer designer'da bağlanmadıysa FAQ arama ve selection eventlerini de burada bağla
            txtFaqArama.TextChanged += TxtFaqArama_TextChanged;
            dataGridViewFaq.SelectionChanged += DataGridViewFaq_SelectionChanged;
        }

        private void FormYardim_Load(object sender, EventArgs e)
        {
            labelVersiyon.Text = "Sürüm: 1.0";
            InitializeFaqs();
            LoadKullanimRehberi();
            PrepareIletisimPanel();
            // event bağlamaları (Designer'da yapmadıysan burada bağla)
            txtFaqArama.TextChanged += TxtFaqArama_TextChanged;
            dataGridViewFaq.SelectionChanged += DataGridViewFaq_SelectionChanged;
            lblDestekEmail.LinkClicked += LblDestekEmail_LinkClicked;
            btnKopyalaTel.Click += BtnKopyalaTel_Click;
            btnGeriBildirimGonder.Click += BtnGeriBildirimGonder_Click;
        }

        #region FAQ (Sık Sorulan Sorular)

        private DataTable dtFaq;

        private void InitializeFaqs()
        {
            // Örnek FAQ listesi — istersen veritabanına taşıyabiliriz
            dtFaq = new DataTable();
            dtFaq.Columns.Add("Soru");
            dtFaq.Columns.Add("Cevap");

            dtFaq.Rows.Add("İzin talebi nasıl gönderilir?",
                "İzin Talepleri formundan başlangıç ve bitiş tarihlerini seçin, 'İzin Talep Et' butonuna tıklayın. Yönetici onayına gönderilecektir.");
            dtFaq.Rows.Add("İzin Durumu nedir?",
                "İzin Durumu formunda kalan izin hakkınız, geçmiş izinleriniz ve o gün izinli olup olmadığınız gösterilir.");
            dtFaq.Rows.Add("İzin talebim ne zaman onaylanır?",
                "Yönetici uygun gördüğünde talebi Onaylayacak veya Reddedecektir. Bildirim veya uygulama içi durumdan takip edebilirsiniz.");
            dtFaq.Rows.Add("Şifremi nasıl değiştiririm?",
                "Profil / Şifre Değiştir bölümünden şu anki şifrenizi girip yeni şifrenizi iki kere yazarak değiştirebilirsiniz.");
            dtFaq.Rows.Add("Geçmiş izinlerimde açıklama görünmüyor, ne yapmalıyım?",
                "İzin alırken açıklama girilmemiş olabilir. Yeni bir talep için açıklama giriniz veya yöneticinizle iletişime geçiniz.");

            dataGridViewFaq.DataSource = dtFaq;
            dataGridViewFaq.Columns["Soru"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewFaq.Columns["Cevap"].Visible = false; // cevabı rtb'de göster
            if (dtFaq.Rows.Count > 0)
            {
                dataGridViewFaq.Rows[0].Selected = true;
                ShowFaqAnswer(0);
            }
        }

        private void TxtFaqArama_TextChanged(object sender, EventArgs e)
        {
            try
            {
                var filtre = txtFaqArama.Text.Trim().Replace("'", "''");
                if (string.IsNullOrEmpty(filtre))
                {
                    dataGridViewFaq.DataSource = dtFaq;
                }
                else
                {
                    DataView dv = dtFaq.DefaultView;
                    dv.RowFilter = $"Soru LIKE '%{filtre}%' OR Cevap LIKE '%{filtre}%'";
                    dataGridViewFaq.DataSource = dv.ToTable();
                }
            }
            catch
            {
                // Filtre hatası görmezden gel
            }
        }

        private void DataGridViewFaq_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewFaq.SelectedRows.Count > 0)
            {
                int idx = dataGridViewFaq.SelectedRows[0].Index;
                ShowFaqAnswer(idx);
            }
        }

        private void ShowFaqAnswer(int rowIndex)
        {
            if (rowIndex < 0 || rowIndex >= dataGridViewFaq.Rows.Count) return;
            var row = dataGridViewFaq.Rows[rowIndex].Cells;
            string cevap = row["Cevap"].Value?.ToString() ?? "";
            rtbFaqCevap.Text = cevap;
        }

        #endregion

        #region Kullanım Rehberi

        private void LoadKullanimRehberi()
        {
            rtbKullanim.Clear();
            rtbKullanim.AppendText("Kısa Kullanım Rehberi\n\n");
            rtbKullanim.AppendText("1. Giriş / Oturum Açma\n");
            rtbKullanim.AppendText("- Kullanıcı adı ve şifrenizle giriş yapın.\n\n");
            rtbKullanim.AppendText("2. İzin Talepleri\n");
            rtbKullanim.AppendText("- 'İzin Talepleri' sekmesinden başlangıç ve bitiş tarihlerini seçin ve 'İzin Talep Et' butonuna tıklayın.\n");
            rtbKullanim.AppendText("- Talebiniz yöneticinin onayına gidecektir.\n\n");
            rtbKullanim.AppendText("3. İzin Durumu\n");
            rtbKullanim.AppendText("- 'İzin Durumu' sekmesinde kalan izin hakkınız, geçmiş izinleriniz ve bugün izinli misiniz bilgisi gösterilir.\n\n");
            rtbKullanim.AppendText("4. Yönetici Onayları\n");
            rtbKullanim.AppendText("- Yönetici onayladıktan sonra izinler 'İzinler' tablosuna eklenir ve durum güncellenir.\n\n");
            rtbKullanim.AppendText("5. Yardım / Destek\n");
            rtbKullanim.AppendText("- Hala sorun yaşıyorsanız 'İletişim' sekmesinden geri bildirim yollayabilirsiniz.\n\n");
            rtbKullanim.AppendText("Not: Uygulama veri tabanına bağlanır; oluşan hatalarda konsol veya MessageBox'ta hata mesajı görünebilir.\n");
        }

        #endregion

        #region İletişim / Geri Bildirim

        private void PrepareIletisimPanel()
        {
            // Düzenle: bu epostayı/telefonu kendi projene göre güncelle
            lblDestekEmail.Text = "destek@example.com";
            lblTelefon.Text = "+90 5xx xxx xx xx";
        }

        private void LblDestekEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start($"mailto:{lblDestekEmail.Text}");
            }
            catch
            {
                Clipboard.SetText(lblDestekEmail.Text);
                MessageBox.Show("E-posta adresi panoya kopyalandı: " + lblDestekEmail.Text);
            }
        }

        private void BtnKopyalaTel_Click(object sender, EventArgs e)
        {
            try
            {
                Clipboard.SetText(lblTelefon.Text);
                MessageBox.Show("Telefon numarası panoya kopyalandı: " + lblTelefon.Text);
            }
            catch
            {
                MessageBox.Show("Telefon kopyalanamadı.");
            }
        }

        private void BtnGeriBildirimGonder_Click(object sender, EventArgs e)
        {
            string konu = txtGeriBildirimKonu.Text.Trim();
            string mesaj = txtGeriBildirimMesaj.Text.Trim();

            if (string.IsNullOrWhiteSpace(konu) || string.IsNullOrWhiteSpace(mesaj))
            {
                MessageBox.Show("Lütfen konu ve mesaj alanlarını doldurun.");
                return;
            }

            try
            {
                using (var cnn = new MySqlConnection(connStr))
                {
                    cnn.Open();
                    using (var cmd = new MySqlCommand(
                        "INSERT INTO yardim_talepleri (personel_id, konu, mesaj, tarih, durum) VALUES (@pid, @konu, @mesaj, NOW(), 'Yeni')",
                        cnn))
                    {
                        // Eğer bağlamda personel_id yoksa null gönder
                        cmd.Parameters.AddWithValue("@pid", DBNull.Value);
                        cmd.Parameters.AddWithValue("@konu", konu);
                        cmd.Parameters.AddWithValue("@mesaj", mesaj);
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Geri bildiriminiz gönderildi. Teşekkürler.");
                txtGeriBildirimKonu.Clear();
                txtGeriBildirimMesaj.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Geri bildirim gönderilirken hata oluştu: " + ex.Message);
            }
        }
        #endregion
    }
}
