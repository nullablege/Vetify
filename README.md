# 🐾 Vetify - Veteriner Kliniği Yönetim Sistemi

Modern ve kullanıcı dostu bir veteriner kliniği yönetim sistemi. ASP.NET Core MVC ile geliştirilmiş, tam özellikli bir web uygulaması.

[![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![ASP.NET Core](https://img.shields.io/badge/ASP.NET%20Core-MVC-512BD4?style=flat)](https://docs.microsoft.com/aspnet/core)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4?style=flat)](https://docs.microsoft.com/ef/core)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5.3.2-7952B3?style=flat&logo=bootstrap)](https://getbootstrap.com/)
[![SQL Server](https://img.shields.io/badge/SQL%20Server-Database-CC2927?style=flat&logo=microsoft-sql-server)](https://www.microsoft.com/sql-server)

## 📋 İçindekiler

- [Proje Hakkında](#-proje-hakkında)
- [Özellikler](#-özellikler)
- [Teknolojiler](#-teknolojiler)
- [Mimari](#-mimari)
- [Kurulum](#-kurulum)
- [Kullanım](#-kullanım)
- [Ekran Görüntüleri](#-ekran-görüntüleri)
- [Veritabanı Şeması](#-veritabanı-şeması)
- [Güvenlik](#-güvenlik)
- [Katkıda Bulunma](#-katkıda-bulunma)
- [Lisans](#-lisans)
- [İletişim](#-iletişim)

## 🎯 Proje Hakkında

Vetify, veteriner kliniklerinin günlük operasyonlarını dijitalleştiren, modern ve kullanıcı dostu bir yönetim sistemidir. Hayvan sahipleri ve veterinerler için ayrı paneller sunarak, randevu yönetiminden tedavi takibine, ödeme işlemlerinden sağlık kayıtlarına kadar tüm süreçleri tek bir platformda toplar.

### 🎓 Geliştirici

**Ege Aytaç**
- GitHub: [@nullablege](https://github.com/nullablege)
- Proje: [Vetify](https://github.com/nullablege/Vetify)

## ✨ Özellikler

### 👨‍⚕️ Veteriner Paneli (Admin)

#### 📊 Dashboard
- Gerçek zamanlı istatistikler
- Toplam hayvan sayısı
- Bugünkü randevu sayısı ve tamamlanma oranı
- Bekleyen randevu sayısı
- Aylık gelir takibi
- Bugünkü randevu listesi

#### 🐕 Hayvan Yönetimi
- Hayvan kayıt sistemi (Ad, Tür, Cins, Yaş, Kilo, vb.)
- Hayvan profil detayları
- Hayvan sahipleri ile ilişkilendirme
- Hayvan arama ve filtreleme
- Hayvan düzenleme ve silme

#### 📅 Randevu Yönetimi
- Randevu oluşturma
- Randevu düzenleme
- Randevu iptal etme
- Randevu durumu takibi (Planlandı, Tamamlandı, İptal Edildi)
- Tarih ve saat bazlı randevu planlama
- Müşteri ve hayvan bazlı randevu görüntüleme

#### 💊 Tedavi Yönetimi
- Tedavi kayıt sistemi
- Tedavi türleri (Aşılama, Ameliyat, Kontrol, Diş Tedavisi, İlaç Tedavisi, Acil Müdahale)
- Tedavi detayları ve notlar
- Tedavi ücretlendirmesi
- Randevu bazlı tedavi takibi
- Tedavi düzenleme ve silme

#### 💰 Ödeme Yönetimi
- Ödeme kayıt sistemi
- Ödeme yöntemleri (Nakit, Kredi Kartı, Havale/EFT)
- Ödeme durumu takibi (Ödendi, Kısmi Ödeme, Ödenmedi)
- Bu ay toplam gelir
- Bugün alınan ödemeler
- Bekleyen borç takibi
- Yıllık gelir istatistikleri
- Randevu bazlı ödeme görüntüleme

### 👤 Müşteri Paneli

#### 📊 Dashboard
- Toplam hayvan sayısı
- Planlanmış randevu sayısı
- Son 30 gün ödeme tutarı
- Son 30 gün tedavi sayısı
- Güncel borç durumu
- Son randevular listesi

#### 🐾 Hayvanlarım
- Kendi hayvanlarını görüntüleme
- Yeni hayvan ekleme
- Hayvan detay sayfası
- Hayvan bazlı randevu geçmişi
- Hayvan bazlı tedavi geçmişi
- Hayvan bazlı ödeme geçmişi

#### 📅 Randevularım
- Randevu alma
- Randevu görüntüleme
- Randevu iptal etme
- Randevu durumu takibi

#### 💊 Tedavilerim
- Geçmiş tedavileri görüntüleme
- Tedavi detayları
- Tedavi ücretleri

#### 💳 Ödemelerim
- Ödeme geçmişi
- Toplam ödenecek tutar
- Ödeme detayları

### 🔐 Kimlik Doğrulama ve Yetkilendirme

- **ASP.NET Core Identity** entegrasyonu
- Rol tabanlı yetkilendirme (Admin, Customer)
- Güvenli şifre politikaları
- Email bazlı kullanıcı yönetimi
- Oturum yönetimi (30 gün)
- "Beni Hatırla" özelliği
- Yetkisiz erişim koruması

## 🛠 Teknolojiler

### Backend
- **ASP.NET Core 8.0 MVC** - Web framework
- **Entity Framework Core** - ORM
- **ASP.NET Core Identity** - Kimlik doğrulama ve yetkilendirme
- **SQL Server** - Veritabanı
- **LINQ** - Veri sorgulama
- **Async/Await** - Asenkron programlama

### Frontend
- **Bootstrap 5.3.2** - UI Framework
- **Bootstrap Icons** - İkon kütüphanesi
- **JavaScript (Vanilla)** - İstemci tarafı etkileşimler
- **Razor View Engine** - Dinamik HTML oluşturma
- **CSS3** - Özel stil düzenlemeleri

### Mimari ve Tasarım Desenleri
- **N-Tier Architecture** (3 Katmanlı Mimari)
- **Repository Pattern** - Veri erişim katmanı
- **Dependency Injection** - Bağımlılık yönetimi
- **Generic Repository** - Genel veri işlemleri
- **Service Layer Pattern** - İş mantığı katmanı

## 🏗 Mimari

Proje, **3 Katmanlı Mimari (N-Tier Architecture)** kullanılarak geliştirilmiştir:

```
Vetify/
│
├── Vetify (Presentation Layer)          # Sunum Katmanı
│   ├── Controllers/                     # MVC Controllers
│   ├── Views/                           # Razor Views
│   ├── Models/                          # View Models
│   ├── wwwroot/                         # Statik dosyalar
│   └── Program.cs                       # Uygulama başlangıcı
│
├── BL (Business Logic Layer)            # İş Mantığı Katmanı
│   ├── Abstract/                        # Service Interface'leri
│   └── Concrete/                        # Service Implementasyonları
│
├── DAL (Data Access Layer)              # Veri Erişim Katmanı
│   ├── Abstract/                        # Repository Interface'leri
│   ├── Concrete/                        # Repository Implementasyonları
│   └── Context.cs                       # DbContext
│
└── EL (Entity Layer)                    # Varlık Katmanı
    ├── Entities/                        # Domain Modelleri
    └── Enums/                           # Enum Tanımlamaları
```

### Katman Açıklamaları

#### 1. **Presentation Layer (Vetify)**
- Kullanıcı arayüzü ve etkileşimleri
- MVC Controllers
- Razor Views
- View Models
- Routing ve middleware yapılandırması

#### 2. **Business Logic Layer (BL)**
- İş kuralları ve validasyonlar
- Service pattern implementasyonu
- CRUD operasyonları
- İş mantığı soyutlaması

#### 3. **Data Access Layer (DAL)**
- Veritabanı işlemleri
- Repository pattern implementasyonu
- Entity Framework Core yapılandırması
- Generic repository

#### 4. **Entity Layer (EL)**
- Domain modelleri
- Veritabanı entity'leri
- Enum tanımlamaları
- İlişki yapılandırmaları

## 📦 Kurulum

### Gereksinimler

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/sql-server/sql-server-downloads) (LocalDB, Express veya tam sürüm)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [Visual Studio Code](https://code.visualstudio.com/)

### Adım Adım Kurulum

1. **Projeyi Klonlayın**
```bash
git clone https://github.com/nullablege/Vetify.git
cd Vetify
```

2. **Veritabanı Bağlantı Dizesini Yapılandırın**

`Vetify/appsettings.json` dosyasını açın ve bağlantı dizesini düzenleyin:

```json
{
  "ConnectionStrings": {
    "Default": "Server=(localdb)\\mssqllocaldb;Database=VetifyDb;Trusted_Connection=true;TrustServerCertificate=true"
  }
}
```

**Alternatif Bağlantı Dizeleri:**

SQL Server Express için:
```json
"Default": "Server=.\\SQLEXPRESS;Database=VetifyDb;Trusted_Connection=true;TrustServerCertificate=true"
```

SQL Server (Windows Authentication):
```json
"Default": "Server=localhost;Database=VetifyDb;Trusted_Connection=true;TrustServerCertificate=true"
```

SQL Server (SQL Authentication):
```json
"Default": "Server=localhost;Database=VetifyDb;User Id=sa;Password=YourPassword;TrustServerCertificate=true"
```

3. **NuGet Paketlerini Yükleyin**
```bash
dotnet restore
```

4. **Veritabanını Oluşturun**

Package Manager Console'da (Visual Studio):
```powershell
Update-Database
```

veya Terminal'de:
```bash
dotnet ef database update
```

5. **Uygulamayı Çalıştırın**
```bash
dotnet run --project Vetify
```

Tarayıcınızda `https://localhost:5001` adresine gidin.

## 🚀 Kullanım

### Admin Girişi

Uygulama ilk çalıştırıldığında otomatik olarak bir admin hesabı oluşturulur:

```
Email: admin@admin.com
Şifre: admin
```

**⚠️ Önemli:** Üretim ortamında bu bilgileri mutlaka değiştirin!

### Müşteri Kaydı

1. Ana sayfada "Kayıt Ol" butonuna tıklayın
2. Gerekli bilgileri doldurun
3. Kayıt olduktan sonra otomatik olarak giriş yapılır
4. Müşteri paneline yönlendirilirsiniz

### Temel İş Akışı

#### Veteriner (Admin) İçin:

1. **Hayvan Kaydı**
   - Hayvanlar → Yeni Hayvan Ekle
   - Hayvan bilgilerini ve sahibini seçin
   - Kaydet

2. **Randevu Oluşturma**
   - Randevular → Yeni Randevu Oluştur
   - Müşteri ve hayvanı seçin
   - Tarih ve saat belirleyin
   - Kaydet

3. **Tedavi Kaydı**
   - Tedaviler → Yeni Tedavi Ekle
   - Randevuyu seçin
   - Tedavi türü ve detayları girin
   - Ücret belirleyin
   - Kaydet

4. **Ödeme Alma**
   - Ödemeler → Yeni Ödeme Kaydet
   - Randevuyu seçin
   - Ödeme tutarı ve yöntemi girin
   - Kaydet

#### Müşteri İçin:

1. **Hayvan Ekleme**
   - Hayvanlarım → Yeni Hayvan Ekle
   - Hayvan bilgilerini girin
   - Kaydet

2. **Randevu Alma**
   - Randevularım → Randevu Al
   - Hayvanınızı seçin
   - Tarih ve saat belirleyin
   - Kaydet

3. **Takip**
   - Dashboard'dan genel durumu görüntüleyin
   - Tedavilerim'den geçmiş tedavileri inceleyin
   - Ödemelerim'den borç durumunu kontrol edin

## 📸 Ekran Görüntüleri

### Veteriner Paneli
- Dashboard: Genel istatistikler ve bugünkü randevular
- Hayvan Yönetimi: Tüm hayvanların listesi ve detayları
- Randevu Yönetimi: Randevu oluşturma ve düzenleme
- Tedavi Yönetimi: Tedavi kayıtları ve detayları
- Ödeme Yönetimi: Ödeme takibi ve istatistikler

### Müşteri Paneli
- Dashboard: Kişisel istatistikler
- Hayvanlarım: Hayvan listesi ve detayları
- Randevularım: Randevu alma ve görüntüleme
- Tedavilerim: Tedavi geçmişi
- Ödemelerim: Ödeme geçmişi ve borç durumu

## 🗄 Veritabanı Şeması

### Ana Tablolar

#### Kullanici (AspNetUsers)
- Identity tablosu
- Kullanıcı bilgileri
- Roller (Admin, Customer)

#### Hayvan
- Id, Ad, Tur, Cins, DogumTarihi, Kilo
- Cinsiyet, Renk, Notlar
- SahipId (FK → Kullanici)

#### Randevu
- Id, RandevuZamani, Durum, Notlar
- HayvanId (FK → Hayvan)
- MusteriId (FK → Kullanici)

#### Tedavi
- Id, TedaviTuru, TedaviTarihi, Ucret
- Aciklama
- RandevuId (FK → Randevu)

#### Odeme
- Id, Tutar, OdemeYontemi, OdemeTarihi
- Durum, Notlar
- RandevuId (FK → Randevu)
- MusteriId (FK → Kullanici)

#### SaglikKaydi
- Id, Tarih, Konu, Detay
- HayvanId (FK → Hayvan)

#### Fatura
- Id, FaturaTarihi, ToplamTutar
- RandevuId (FK → Randevu)

### İlişkiler

```
Kullanici (1) ─── (N) Hayvan
Kullanici (1) ─── (N) Randevu
Kullanici (1) ─── (N) Odeme
Hayvan (1) ─── (N) Randevu
Hayvan (1) ─── (N) SaglikKaydi
Randevu (1) ─── (N) Tedavi
Randevu (1) ─── (N) Odeme
Randevu (1) ─── (1) Fatura
```

## 🔒 Güvenlik

### Kimlik Doğrulama
- **ASP.NET Core Identity** ile güvenli kimlik doğrulama
- Email bazlı kullanıcı yönetimi
- Şifre hashleme (PBKDF2)
- Güvenli cookie tabanlı oturum yönetimi

### Yetkilendirme
- Rol tabanlı erişim kontrolü
- `[Authorize(Roles = "Admin")]` - Sadece admin erişimi
- `[Authorize(Roles = "Customer")]` - Sadece müşteri erişimi
- Yetkisiz erişim engelleme

### Şifre Politikaları
```csharp
options.Password.RequireDigit = false;
options.Password.RequireUppercase = false;
options.Password.RequireLowercase = false;
options.Password.RequireNonAlphanumeric = false;
options.Password.RequiredLength = 6;
```

**Not:** Üretim ortamında daha güçlü şifre politikaları kullanılmalıdır.

### Güvenlik Önlemleri
- HTTPS zorunluluğu
- Anti-forgery token koruması
- SQL Injection koruması (Entity Framework)
- XSS koruması (Razor encoding)
- CSRF koruması

## 🎨 Özelleştirme

### Tema Değişikliği
`wwwroot/vet/styles.css` dosyasını düzenleyerek tema renklerini değiştirebilirsiniz.

### Şifre Politikası
`Program.cs` dosyasında Identity yapılandırmasını düzenleyin:

```csharp
builder.Services.AddIdentity<Kullanici, IdentityRole<int>>(options =>
{
    options.Password.RequireDigit = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = true;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequiredLength = 8;
})
```

### Oturum Süresi
`Program.cs` dosyasında cookie yapılandırmasını düzenleyin:

```csharp
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromDays(7); // 7 gün
})
```

## 🧪 Test

### Manuel Test
1. Admin hesabı ile giriş yapın
2. Bir müşteri hesabı oluşturun
3. Müşteri için hayvan ekleyin
4. Randevu oluşturun
5. Tedavi kaydedin
6. Ödeme alın
7. Müşteri hesabı ile giriş yapıp verileri kontrol edin

## 📈 Gelecek Geliştirmeler

- [ ] Fatura oluşturma ve yazdırma
- [ ] Email bildirimleri
- [ ] SMS hatırlatmaları
- [ ] Raporlama modülü
- [ ] Stok yönetimi
- [ ] Personel yönetimi
- [ ] Takvim görünümü
- [ ] Dosya yükleme (röntgen, test sonuçları)
- [ ] API geliştirme
- [ ] Mobil uygulama

## 🤝 Katkıda Bulunma

Katkılarınızı bekliyorum! Lütfen şu adımları izleyin:

1. Projeyi fork edin
2. Feature branch oluşturun (`git checkout -b feature/AmazingFeature`)
3. Değişikliklerinizi commit edin (`git commit -m 'Add some AmazingFeature'`)
4. Branch'inizi push edin (`git push origin feature/AmazingFeature`)
5. Pull Request oluşturun

## 📝 Lisans

Bu proje MIT lisansı altında lisanslanmıştır. Detaylar için [LICENSE](LICENSE) dosyasına bakın.

## 📧 İletişim

**Ege Aytaç**

- GitHub: [@nullablege](https://github.com/nullablege)
- Proje Linki: [https://github.com/nullablege/Vetify](https://github.com/nullablege/Vetify)

## 🙏 Teşekkürler

Bu projeyi geliştirirken kullanılan teknolojiler ve kütüphaneler:

- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Bootstrap](https://getbootstrap.com/)
- [Bootstrap Icons](https://icons.getbootstrap.com/)

---

⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!

**Made with ❤️ by Ege Aytaç**
