README – Personel İzin Takip Sistemi
1. Projenin Amacı

Bu proje, kurum ve işletmelerde personel izin süreçlerini dijital ortamda yönetmek amacıyla geliştirilmiştir. Geleneksel yöntemlerde manuel olarak yürütülen izin takip işlemleri; zaman kaybına, veri kayıplarına ve yönetimsel hatalara sebep olmaktadır. Bu sistem, kullanıcı dostu bir arayüz ve güvenilir bir veri tabanı altyapısı ile izin yönetimini kolaylaştırmayı hedeflemektedir.

2. Projenin Kapsamı

-Sistem; yönetici ve personel olmak üzere iki farklı kullanıcı tipine sahiptir.

-Personel Kullanıcıları:

-İzin talebi oluşturabilir.

-Mevcut izin durumlarını görüntüleyebilir.

-Geçmiş izin kayıtlarını inceleyebilir.

-Şifre güncelleme ve kişisel bilgiler üzerinde düzenleme yapabilir.

-Yönetici Kullanıcıları:

-Tüm personellerin izin taleplerini görüntüleyebilir.

-Onaylama, reddetme ve düzenleme işlemleri gerçekleştirebilir.

-Personel listelerini yönetebilir.

-İstatistiksel raporlar alabilir.

3. Kullanılan Teknolojiler

+Programlama Dili: C# (.NET Framework – Windows Forms)

+Veritabanı: MySQL

+IDE: Visual Studio 2022

+Versiyon Kontrol: Git & GitHub

4. Sistem Mimarisi

Veri Tabanı Katmanı:

*Personel bilgileri

*İzin türleri

*İzin talepleri

*Yönetici hesapları

Uygulama Katmanı:

*Form tabanlı kullanıcı arayüzleri

*Veritabanı bağlantıları (MySql.Data.MySqlClient)

*Yetkilendirme ve kullanıcı giriş işlemleri

Sunum Katmanı:

*Personel ve yönetici için ayrı ana menüler

*Kolay erişim sağlayan butonlar ve menüler

*Grafiksel raporlar (izin istatistikleri)

5. Kurulum Adımları

Gerekli Ortam:

-Visual Studio 2022 veya üstü

-MySQL Server ve MySQL Workbench

-Git kurulu bilgisayar

Adımlar:

Proje dosyalarını GitHub’dan klonlayın:

1-git clone https://github.com/kullaniciadi/personel-izin-takip.git


2- MySQL üzerinde personel_izin_takip isimli veritabanı oluşturun.

3- İlgili tabloları çalıştırarak veritabanını yapılandırın.

4- Uygulamayı çalıştırarak giriş ekranına erişin.

6. Projenin Katkıları

Bu proje, kurumlarda izin yönetimini dijitalleştirerek:

Zaman tasarrufu sağlar.

Hata oranını düşürür.

Veri güvenliği ve bütünlüğü artırır.

Yönetimsel raporlama imkânı sunar.

7. Geliştirici Notları

Bu proje eğitim amaçlı geliştirilmiştir.

İleri sürümlerde web tabanlı sürüm ve mobil uygulama desteği planlanmaktadır.

Katkıda bulunmak isteyenler pull request gönderebilir.
