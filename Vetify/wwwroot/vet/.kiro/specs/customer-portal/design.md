# Design Document

## Overview

Bu doküman, Vetify veteriner kliniği yönetim sistemine eklenecek müşteri portalının tasarım detaylarını içerir. Müşteri portalı, mevcut admin sayfalarıyla aynı tasarım dilini kullanarak, müşterilerin kendi hayvanlarını ve randevularını yönetebilecekleri statik HTML sayfalarından oluşacaktır.

### Teknik Stack
- **HTML5**: Semantik ve erişilebilir markup
- **CSS3**: Custom properties ile tema sistemi
- **Bootstrap 5.3.2**: Responsive grid ve component framework
- **Bootstrap Icons 1.11.1**: Icon library
- **Vanilla JavaScript**: Minimal interaktivite (form handling, UI animations)

### Tasarım Prensipleri
1. **Tutarlılık**: Mevcut admin sayfalarıyla birebir aynı tasarım dili
2. **Responsive**: Mobile-first yaklaşım, tüm ekran boyutlarında uyumlu
3. **Erişilebilirlik**: WCAG 2.1 AA standartlarına uygun
4. **Performans**: Minimal JavaScript, optimize edilmiş CSS
5. **Kullanıcı Deneyimi**: Sade, anlaşılır ve kullanımı kolay arayüz

## Architecture

### Sayfa Yapısı

```
Root Directory/
├── login.html (güncellenecek - Vetify branding)
├── register.html (güncellenecek - Vetify branding)
├── customer-dashboard.html (yeni)
├── customer-animals.html (yeni)
├── customer-animal-detail.html (yeni)
├── customer-animal-create.html (yeni)
├── customer-appointments.html (yeni)
├── customer-appointment-create.html (yeni)
├── customer-treatments.html (yeni)
├── customer-payments.html (yeni)
├── customer-profile.html (yeni)
├── styles.css (mevcut - değişiklik yok)
└── script.js (güncellenecek - customer form handlers)
```

### Navigasyon Yapısı

**Admin Navigation** (mevcut):
- Dashboard
- Hayvanlar
- Randevular
- Tedaviler
- Ödemeler
- User Dropdown (Profil, Ayarlar, Çıkış)

**Customer Navigation** (yeni):
- Dashboard
- Hayvanlarım
- Randevularım
- Tedavilerim
- Ödemelerim
- User Dropdown (Profil, Çıkış)

## Components and Interfaces

### 1. Branding Update Component

**Affected Files**: Tüm HTML sayfaları

**Changes**:
```html
<!-- Eski -->
<span class="fw-bold text-primary">VetCare</span>

<!-- Yeni -->
<span class="fw-bold text-primary">Vetify</span>
```

**Title Updates**:
```html
<!-- Eski -->
<title>VetCare - [Sayfa Adı]</title>

<!-- Yeni -->
<title>Vetify - [Sayfa Adı]</title>
```

### 2. Customer Navigation Component

**Structure**:
```html
<nav class="navbar navbar-expand-lg navbar-light bg-white shadow-sm sticky-top">
  <div class="container-fluid px-4">
    <a class="navbar-brand" href="customer-dashboard.html">
      <i class="bi bi-heart-pulse-fill me-2 text-primary"></i>
      <span class="fw-bold text-primary">Vetify</span>
    </a>
    <ul class="navbar-nav ms-auto">
      <li class="nav-item"><a class="nav-link" href="customer-dashboard.html">Dashboard</a></li>
      <li class="nav-item"><a class="nav-link" href="customer-animals.html">Hayvanlarım</a></li>
      <li class="nav-item"><a class="nav-link" href="customer-appointments.html">Randevularım</a></li>
      <li class="nav-item"><a class="nav-link" href="customer-treatments.html">Tedavilerim</a></li>
      <li class="nav-item"><a class="nav-link" href="customer-payments.html">Ödemelerim</a></li>
      <li class="nav-item dropdown">
        <a class="nav-link dropdown-toggle" href="#" id="userDropdown">
          <i class="bi bi-person-circle me-1"></i>
          <span>[Müşteri Adı]</span>
        </a>
        <ul class="dropdown-menu dropdown-menu-end">
          <li><a class="dropdown-item" href="customer-profile.html">Profil</a></li>
          <li><hr class="dropdown-divider"></li>
          <li><a class="dropdown-item text-danger" href="login.html">Çıkış Yap</a></li>
        </ul>
      </li>
    </ul>
  </div>
</nav>
```

### 3. Dashboard Stat Cards

**Weather Widget Card**:
```html
<div class="stat-card">
  <div class="stat-icon bg-info-soft">
    <i class="bi bi-cloud-sun text-info"></i>
  </div>
  <div class="stat-content">
    <h3 class="stat-value">22°C</h3>
    <p class="stat-label">Hava Durumu</p>
    <span class="stat-change">İstanbul, Parçalı Bulutlu</span>
  </div>
</div>
```

**Currency Widget Card**:
```html
<div class="stat-card">
  <div class="stat-icon bg-warning-soft">
    <i class="bi bi-currency-exchange text-warning"></i>
  </div>
  <div class="stat-content">
    <h3 class="stat-value">₺34.25</h3>
    <p class="stat-label">USD Kuru</p>
    <span class="stat-change">EUR: ₺37.80</span>
  </div>
</div>
```

### 4. Animal List Component

**Table Structure** (customer-animals.html):
```html
<table class="table table-hover align-middle mb-0">
  <thead>
    <tr>
      <th>Hayvan Adı</th>
      <th>Tür</th>
      <th>Cins</th>
      <th>Yaş</th>
      <th>Kilo</th>
      <th>İşlemler</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>
        <div class="d-flex align-items-center">
          <div class="animal-avatar bg-primary-soft">
            <i class="bi bi-heart-fill text-primary"></i>
          </div>
          <strong>Max</strong>
        </div>
      </td>
      <td><span class="badge bg-primary">Köpek</span></td>
      <td>Golden Retriever</td>
      <td>5 yaş</td>
      <td>32 kg</td>
      <td>
        <a href="customer-animal-detail.html" class="btn btn-sm btn-outline-primary">
          <i class="bi bi-eye"></i> Detay
        </a>
      </td>
    </tr>
  </tbody>
</table>
```

### 5. Animal Detail Component

**Info Cards Layout**:
```html
<div class="row g-4">
  <!-- Sol: Hayvan Bilgileri -->
  <div class="col-lg-4">
    <div class="card custom-card">
      <div class="card-body text-center">
        <div class="animal-avatar-large bg-primary-soft mx-auto mb-3">
          <i class="bi bi-heart-fill text-primary"></i>
        </div>
        <h3>Max</h3>
        <p class="text-muted">Golden Retriever</p>
      </div>
    </div>
    
    <div class="card custom-card mt-4">
      <div class="card-header">
        <h5 class="card-title mb-0">Genel Bilgiler</h5>
      </div>
      <div class="card-body">
        <div class="info-item">
          <i class="bi bi-calendar text-primary"></i>
          <div>
            <p class="info-label">Yaş</p>
            <p class="info-value">5 yaş</p>
          </div>
        </div>
        <!-- Diğer bilgiler -->
      </div>
    </div>
  </div>
  
  <!-- Sağ: Randevular, Tedaviler, Ödemeler -->
  <div class="col-lg-8">
    <!-- Tabs veya Accordion -->
  </div>
</div>
```

### 6. Appointment Create Form

**Form Structure**:
```html
<form id="customerAppointmentForm">
  <div class="mb-3">
    <label class="form-label">Hayvan Seçin</label>
    <select class="form-select form-select-lg" required>
      <option value="">Hayvan seçin...</option>
      <option value="1">Max - Golden Retriever</option>
      <option value="2">Luna - Van Kedisi</option>
    </select>
  </div>
  
  <div class="row">
    <div class="col-md-6 mb-3">
      <label class="form-label">Randevu Tarihi</label>
      <input type="date" class="form-control form-control-lg" required>
    </div>
    <div class="col-md-6 mb-3">
      <label class="form-label">Randevu Saati</label>
      <input type="time" class="form-control form-control-lg" required>
    </div>
  </div>
  
  <div class="alert alert-warning" id="conflictWarning" style="display: none;">
    <i class="bi bi-exclamation-triangle me-2"></i>
    Bu tarih ve saatte başka bir randevu bulunmaktadır.
  </div>
  
  <div class="mb-3">
    <label class="form-label">Notlar (Opsiyonel)</label>
    <textarea class="form-control" rows="3"></textarea>
  </div>
  
  <button type="submit" class="btn btn-primary btn-lg w-100">
    <i class="bi bi-calendar-check me-2"></i>Randevu Oluştur
  </button>
</form>
```

### 7. Appointments List Component

**Status-Based Display**:
```html
<table class="table table-hover align-middle mb-0">
  <thead>
    <tr>
      <th>Tarih</th>
      <th>Saat</th>
      <th>Hayvan</th>
      <th>Durum</th>
      <th>Notlar</th>
      <th>İşlemler</th>
    </tr>
  </thead>
  <tbody>
    <tr>
      <td>15 Kasım 2025</td>
      <td><span class="badge bg-light text-dark">10:00</span></td>
      <td><strong>Max</strong></td>
      <td><span class="badge bg-secondary">Planlandı</span></td>
      <td>Aşı kontrolü</td>
      <td>
        <button class="btn btn-sm btn-outline-danger">
          <i class="bi bi-x-circle"></i> İptal Et
        </button>
      </td>
    </tr>
    <tr>
      <td>10 Kasım 2025</td>
      <td><span class="badge bg-light text-dark">14:00</span></td>
      <td><strong>Luna</strong></td>
      <td><span class="badge bg-success">Tamamlandı</span></td>
      <td>Rutin kontrol</td>
      <td>
        <a href="customer-animal-detail.html" class="btn btn-sm btn-outline-primary">
          <i class="bi bi-eye"></i> Detay
        </a>
      </td>
    </tr>
  </tbody>
</table>
```

### 8. Treatments List Component

**Treatment Display**:
```html
<div class="card custom-card mb-3">
  <div class="card-body">
    <div class="row align-items-center">
      <div class="col-md-2">
        <div class="text-center">
          <div class="stat-icon bg-success-soft mx-auto mb-2">
            <i class="bi bi-bandaid text-success"></i>
          </div>
          <small class="text-muted">10 Kas 2025</small>
        </div>
      </div>
      <div class="col-md-6">
        <h6 class="mb-1">Aşı Uygulaması</h6>
        <p class="text-muted mb-1">Hayvan: <strong>Max</strong></p>
        <p class="text-muted mb-0">Randevu: #234 - 10 Kasım 2025, 14:00</p>
      </div>
      <div class="col-md-4 text-md-end">
        <h5 class="text-primary mb-1">₺450</h5>
        <small class="text-muted">Kuduz + Karma Aşı</small>
      </div>
    </div>
  </div>
</div>
```

### 9. Payments List Component

**Payment Display with Currency**:
```html
<div class="card custom-card mb-3">
  <div class="card-body">
    <div class="row align-items-center">
      <div class="col-md-2">
        <div class="text-center">
          <div class="stat-icon bg-warning-soft mx-auto mb-2">
            <i class="bi bi-credit-card text-warning"></i>
          </div>
          <small class="text-muted">10 Kas 2025</small>
        </div>
      </div>
      <div class="col-md-5">
        <h6 class="mb-1">Randevu Ödemesi</h6>
        <p class="text-muted mb-0">Randevu: #234 - Max</p>
      </div>
      <div class="col-md-5 text-md-end">
        <h5 class="text-success mb-1">₺450</h5>
        <div class="d-flex justify-content-end gap-3">
          <small class="text-muted">$13.14 USD</small>
          <small class="text-muted">€11.90 EUR</small>
        </div>
      </div>
    </div>
  </div>
</div>

<!-- Kalan Borç Kartı -->
<div class="card custom-card border-danger">
  <div class="card-body">
    <div class="d-flex justify-content-between align-items-center">
      <div>
        <h6 class="text-danger mb-1">Kalan Borç</h6>
        <p class="text-muted mb-0">Toplam ödenmemiş tutar</p>
      </div>
      <div class="text-end">
        <h4 class="text-danger mb-1">₺1,250</h4>
        <div class="d-flex gap-3">
          <small class="text-muted">$36.50 USD</small>
          <small class="text-muted">€33.07 EUR</small>
        </div>
      </div>
    </div>
  </div>
</div>
```

### 10. Profile Form Component

**Profile Update Form**:
```html
<div class="row g-4">
  <div class="col-lg-6">
    <div class="card custom-card">
      <div class="card-header">
        <h5 class="card-title mb-0">Profil Bilgileri</h5>
      </div>
      <div class="card-body">
        <form id="profileUpdateForm">
          <div class="mb-3">
            <label class="form-label">Ad Soyad</label>
            <input type="text" class="form-control" value="Ahmet Yılmaz" required>
          </div>
          <div class="mb-3">
            <label class="form-label">E-posta</label>
            <input type="email" class="form-control" value="ahmet@example.com" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Telefon</label>
            <input type="tel" class="form-control" value="0532 123 45 67" required>
          </div>
          <button type="submit" class="btn btn-primary">
            <i class="bi bi-check-circle me-2"></i>Bilgileri Güncelle
          </button>
        </form>
      </div>
    </div>
  </div>
  
  <div class="col-lg-6">
    <div class="card custom-card">
      <div class="card-header">
        <h5 class="card-title mb-0">Şifre Değiştir</h5>
      </div>
      <div class="card-body">
        <form id="passwordChangeForm">
          <div class="mb-3">
            <label class="form-label">Mevcut Şifre</label>
            <input type="password" class="form-control" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Yeni Şifre</label>
            <input type="password" class="form-control" required>
          </div>
          <div class="mb-3">
            <label class="form-label">Yeni Şifre (Tekrar)</label>
            <input type="password" class="form-control" required>
          </div>
          <button type="submit" class="btn btn-warning">
            <i class="bi bi-shield-lock me-2"></i>Şifreyi Değiştir
          </button>
        </form>
      </div>
    </div>
  </div>
</div>
```

## Data Models

### Mock Data Structure

**Customer Data**:
```javascript
const customerData = {
  id: 1,
  name: "Ahmet Yılmaz",
  email: "ahmet@example.com",
  phone: "0532 123 45 67",
  animals: [
    {
      id: 1,
      name: "Max",
      species: "Köpek",
      breed: "Golden Retriever",
      age: 5,
      weight: 32,
      registrationDate: "12.01.2023"
    },
    {
      id: 2,
      name: "Luna",
      species: "Kedi",
      breed: "Van",
      age: 2,
      weight: 3.8,
      registrationDate: "10.03.2023"
    }
  ]
};
```

**Appointment Data**:
```javascript
const appointments = [
  {
    id: 234,
    animalId: 1,
    animalName: "Max",
    date: "2025-11-15",
    time: "10:00",
    status: "Scheduled", // Scheduled, Approved, Completed, Cancelled
    notes: "Aşı kontrolü",
    treatments: []
  },
  {
    id: 233,
    animalId: 2,
    animalName: "Luna",
    date: "2025-11-10",
    time: "14:00",
    status: "Completed",
    notes: "Rutin kontrol",
    treatments: [
      {
        id: 1,
        type: "Aşı Uygulaması",
        notes: "Kuduz + Karma Aşı",
        cost: 450
      }
    ]
  }
];
```

**Treatment Data**:
```javascript
const treatments = [
  {
    id: 1,
    appointmentId: 233,
    animalId: 2,
    animalName: "Luna",
    date: "2025-11-10",
    type: "Aşı Uygulaması",
    notes: "Kuduz + Karma Aşı",
    cost: 450
  }
];
```

**Payment Data**:
```javascript
const payments = [
  {
    id: 1,
    appointmentId: 233,
    animalName: "Max",
    date: "2025-11-10",
    amount: 450,
    amountUSD: 13.14,
    amountEUR: 11.90
  }
];

const debt = {
  totalTRY: 1250,
  totalUSD: 36.50,
  totalEUR: 33.07
};
```

**Weather Data**:
```javascript
const weatherData = {
  temperature: 22,
  condition: "Parçalı Bulutlu",
  location: "İstanbul"
};
```

**Currency Data**:
```javascript
const currencyRates = {
  USD: 34.25,
  EUR: 37.80
};
```

## Error Handling

### Form Validation

**Client-Side Validation**:
- HTML5 required attributes
- Pattern validation for phone numbers
- Min/max date validation for appointments
- Password strength validation

**Error Display**:
```html
<div class="alert alert-danger" role="alert">
  <i class="bi bi-exclamation-triangle me-2"></i>
  [Hata mesajı]
</div>
```

### Success Messages

```html
<div class="alert alert-success" role="alert">
  <i class="bi bi-check-circle me-2"></i>
  [Başarı mesajı]
</div>
```

### Empty States

**No Animals**:
```html
<div class="text-center py-5">
  <i class="bi bi-inbox" style="font-size: 4rem; color: var(--text-secondary);"></i>
  <h4 class="mt-3">Henüz hayvan kaydınız bulunmuyor</h4>
  <p class="text-muted">Yeni bir hayvan ekleyerek başlayın</p>
  <a href="customer-animal-create.html" class="btn btn-primary">
    <i class="bi bi-plus-circle me-2"></i>Hayvan Ekle
  </a>
</div>
```

## Testing Strategy

### Browser Compatibility
- Chrome (latest)
- Firefox (latest)
- Safari (latest)
- Edge (latest)

### Responsive Breakpoints
- Mobile: 320px - 767px
- Tablet: 768px - 991px
- Desktop: 992px+

### Manual Testing Checklist

**Visual Testing**:
- [ ] Tüm sayfalar mevcut admin sayfalarıyla aynı görünüyor
- [ ] Renkler, fontlar, spacing tutarlı
- [ ] Icons doğru yerde ve boyutta
- [ ] Responsive tasarım tüm breakpoint'lerde çalışıyor

**Functional Testing**:
- [ ] Navigation linkleri doğru sayfalara yönlendiriyor
- [ ] Form submit işlemleri success message gösteriyor
- [ ] Dropdown menüler açılıyor
- [ ] Filtreleme butonları çalışıyor (UI only)
- [ ] Modal'lar açılıp kapanıyor

**Accessibility Testing**:
- [ ] Keyboard navigation çalışıyor
- [ ] Focus states görünür
- [ ] Alt text'ler mevcut
- [ ] Color contrast yeterli
- [ ] Screen reader uyumlu

### Test Data Requirements

Her sayfa için minimum 3-5 örnek veri:
- **Animals**: 5 farklı hayvan (3 köpek, 2 kedi)
- **Appointments**: 8 randevu (2 Scheduled, 1 Approved, 4 Completed, 1 Cancelled)
- **Treatments**: 5 tedavi kaydı
- **Payments**: 4 ödeme kaydı + 1 borç kartı

## Design Decisions and Rationales

### 1. Statik HTML Yaklaşımı
**Karar**: Backend olmadan, tüm veriler HTML içinde mock data olarak
**Sebep**: Hızlı prototipleme, basit deployment, backend bağımlılığı yok

### 2. Aynı Tasarım Dili
**Karar**: Admin ve customer sayfaları aynı CSS kullanıyor
**Sebep**: Tutarlılık, bakım kolaylığı, tek bir styles.css dosyası

### 3. Bootstrap Framework
**Karar**: Bootstrap 5.3.2 kullanımı
**Sebep**: Mevcut sistemle uyumluluk, responsive grid, hazır componentler

### 4. Minimal JavaScript
**Karar**: Sadece form handling ve basit UI interactions
**Sebep**: Performans, basitlik, framework bağımlılığı yok

### 5. Customer Navigation Ayrımı
**Karar**: Customer'lar için ayrı navigation menüsü
**Sebep**: Rol bazlı erişim kontrolü simülasyonu, kullanıcı deneyimi

### 6. Weather ve Currency Widgets
**Karar**: Statik HTML ile gösterim
**Sebep**: API entegrasyonu yok, görsel tasarım odaklı

### 7. Appointment Status Flow
**Karar**: Sadece "Scheduled" randevular iptal edilebilir
**Sebep**: Gerçek dünya iş mantığını simüle etme

### 8. Currency Display
**Karar**: TRY, USD, EUR gösterimi
**Sebep**: Uluslararası müşteriler için faydalı bilgi

### 9. Responsive Tables
**Karar**: Mobile'da scroll, tablet ve üstünde full table
**Sebep**: Veri yoğunluğu, okunabilirlik

### 10. Empty States
**Karar**: Boş durumlar için friendly mesajlar ve CTA butonları
**Sebep**: Kullanıcı yönlendirmesi, ilk kullanım deneyimi
