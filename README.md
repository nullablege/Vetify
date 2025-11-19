# 🐾 Vetify - Veteriner Kliniği Yönetim Sistemi

Modern ve kullanıcı dostu bir veteriner kliniği yönetim sistemi. ASP.NET Core MVC ile geliştirilmiş, tam özellikli bir web uygulaması.
NOT : Projenin amacı ; Katmanlı mimari mantığını tamamen oturtmak ve bunu ispatlamaktır. Herhangi bir şekilde projenin product ready olarak sunulması gibi bir durum söz konusu değildir. 
İlerleyen zamanlarda product ready olacak şekilde güncellemeler devam edebilir.

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
- **Gerçek Zamanlı Hava Durumu**
  - Klinik konumu hava durumu
  - Kullanıcı konumu hava durumu
  - Sıcaklık ve hava durumu açıklaması
- **Mesafe ve Süre Hesaplama**
  - Kullanıcı konumundan kliniğe mesafe (km)
  - Tahmini varış süresi
  - Haversine formülü ile hassas hesaplama
- **Güncel Döviz Kurları**
  - USD/TRY kuru
  - EUR/TRY kuru
  - 3 saatlik önbellek sistemi

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

### Entegre API Servisleri
- **Met.no Weather API** - Gerçek zamanlı hava durumu verileri
- **BigDataCloud Reverse Geocoding API** - Konum bilgisi ve şehir adları
- **ExchangeRate API** - Güncel döviz kurları (USD, EUR)
- **Geolocation API** - Kullanıcı konumu ve mesafe hesaplama

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

## 🌐 API Entegrasyonları

Proje, kullanıcı deneyimini zenginleştirmek için çeşitli üçüncü parti API'ler kullanmaktadır:

### 🌤️ Met.no Weather API
- **Amaç:** Gerçek zamanlı hava durumu verileri
- **Kullanım:** Klinik ve kullanıcı konumu için hava durumu gösterimi
- **Özellikler:**
  - Sıcaklık bilgisi
  - Hava durumu açıklaması (Açık, Bulutlu, Yağmurlu, vb.)
  - 1 ve 6 saatlik tahminler
- **Endpoint:** `https://api.met.no/weatherapi/locationforecast/2.0/compact`
- **Önbellek:** 3 saat (Cookie tabanlı)

### 📍 BigDataCloud Reverse Geocoding API
- **Amaç:** Koordinatlardan şehir ve konum bilgisi alma
- **Kullanım:** Kullanıcı ve klinik konumlarının şehir adlarını gösterme
- **Özellikler:**
  - Türkçe konum adları
  - Şehir ve mahalle bilgisi
  - Yüksek doğruluk oranı
- **Endpoint:** `https://api.bigdatacloud.net/data/reverse-geocode-client`
- **Önbellek:** 3 saat (Cookie tabanlı)

### 💱 ExchangeRate API
- **Amaç:** Güncel döviz kurları
- **Kullanım:** Müşteri dashboard'unda USD ve EUR kurlarını gösterme
- **Özellikler:**
  - TRY bazlı döviz kurları
  - Günlük güncelleme
  - Otomatik kur hesaplama
- **Endpoint:** `https://api.exchangerate-api.com/v4/latest/TRY`
- **Önbellek:** 3 saat (Cookie tabanlı)

### 🗺️ Geolocation API
- **Amaç:** Kullanıcı konumu tespiti
- **Kullanım:** Kliniğe olan mesafe ve tahmini varış süresini hesaplama
- **Özellikler:**
  - Haversine formülü ile hassas mesafe hesaplama
  - Tahmini seyahat süresi (ortalama 20 km/saat)
  - Kullanıcı izni ile konum erişimi
- **Teknoloji:** Browser Geolocation API
- **Önbellek:** 3 saat (Cookie tabanlı)

### 🔧 API Yönetimi

**Önbellek Stratejisi:**
- Tüm API çağrıları cookie tabanlı önbellek kullanır
- Önbellek süresi: 3 saat
- Gereksiz API çağrılarını önler
- Sayfa yüklenme hızını artırır

**Hata Yönetimi:**
- API hatalarında varsayılan değerler gösterilir
- Console'da detaylı hata logları
- Kullanıcı deneyimini kesintiye uğratmaz

**Performans:**
- Asenkron API çağrıları (async/await)
- Paralel veri yükleme
- Önbellek ile hızlı sayfa yükleme

## 🙏 Teşekkürler

Bu projeyi geliştirirken kullanılan teknolojiler, kütüphaneler ve API servisleri:

### Framework ve Kütüphaneler
- [ASP.NET Core](https://docs.microsoft.com/aspnet/core)
- [Entity Framework Core](https://docs.microsoft.com/ef/core)
- [Bootstrap](https://getbootstrap.com/)
- [Bootstrap Icons](https://icons.getbootstrap.com/)

### API Servisleri
- [Met.no Weather API](https://api.met.no/) - Hava durumu verileri
- [BigDataCloud](https://www.bigdatacloud.com/) - Reverse geocoding
- [ExchangeRate API](https://www.exchangerate-api.com/) - Döviz kurları


---
Görseller : 
Kullanıcı Görselleri :
<img width="1667" height="944" alt="Screenshot_87" src="https://github.com/user-attachments/assets/69f386b9-7501-49ab-884d-5e6907bc6b73" />
<img width="1542" height="699" alt="Screenshot_86" src="https://github.com/user-attachments/assets/56e1b7db-b227-4882-a0b6-8d2f2a796de0" />
<img width="1525" height="854" alt="Screenshot_85" src="https://github.com/user-attachments/assets/b8733f66-152a-4fe0-a16b-e5966b4c8f79" />
<img width="1580" height="1014" alt="Screenshot_84" src="https://github.com/user-attachments/assets/6aa0f737-97f0-4fad-bb14-c0dd6aa0daf7" />
<img width="1498" height="666" alt="Screenshot_83" src="https://github.com/user-attachments/assets/62b3c777-858f-420c-a81c-020114825ef2" />
<img width="1568" height="1148" alt="Screenshot_82" src="https://github.com/user-attachments/assets/3cc25531-4b84-4b86-9bfd-3302633cc66e" />

Yetkili Görselleri : 
<img width="1664" height="803" alt="Screenshot_95" src="https://github.com/user-attachments/assets/984b6df3-9b22-4b91-83e7-4fb98b03a547" />
<img width="1603" height="1027" alt="Screenshot_94" src="https://github.com/user-attachments/assets/ff2003b4-8036-4f9c-aa46-4f3fde3326f1" />
<img width="1662" height="1181" alt="Screenshot_93" src="https://github.com/user-attachments/assets/10a42a80-dd7a-4e8d-b123-fb3e2ed33754" />
<img width="1591" height="1200" alt="Screenshot_92" src="https://github.com/user-attachments/assets/48bbdb30-2b31-4b2d-8ee5-32a708b1f957" />
<img width="1524" height="956" alt="Screenshot_91" src="https://github.com/user-attachments/assets/5d91cd25-5e5d-434e-af20-c146b16f2ac2" />
<img width="1604" height="1193" alt="Screenshot_90" src="https://github.com/user-attachments/assets/27448e9b-985c-4159-8de7-d341a0cdbee9" />
<img width="1635" height="707" alt="Screenshot_89" src="https://github.com/user-attachments/assets/31b95da2-b8d3-48f1-97fa-472735db997a" />
<img width="1645" height="806" alt="Screenshot_88" src="https://github.com/user-attachments/assets/3374c9d9-46e1-4aa1-8bab-0d4e1bfa25bb" />



⭐ Bu projeyi beğendiyseniz yıldız vermeyi unutmayın!


**Made with ❤️ by Ege Aytaç**
