# Implementation Plan

## Task List

- [x] 1. Mevcut sayfaları Vetify markasıyla güncelle





  - Tüm HTML dosyalarında "VetCare" → "Vetify" değişikliği yap
  - Navigation bar'daki marka adını güncelle
  - Page title'ları güncelle (browser tab)
  - Login ve register sayfalarındaki branding'i güncelle
  - _Requirements: 1.1, 1.2, 1.3, 1.4, 1.5_

- [x] 2. Customer Dashboard sayfasını oluştur (customer-dashboard.html)





  - [x] 2.1 Customer navigation component'ini ekle


    - Dashboard, Hayvanlarım, Randevularım, Tedavilerim, Ödemelerim menü öğeleri
    - User dropdown (Profil, Çıkış)
    - Vetify branding
    - _Requirements: 11.1, 11.2, 11.4, 11.5_
  

  - [x] 2.2 Dashboard stat cards'ları oluştur

    - Toplam hayvan sayısı kartı (mock data: 2 hayvan)
    - Planlanmış randevu sayısı kartı (mock data: 1 randevu)
    - Son 30 gün tedavi/ödeme kartı (mock data)
    - Hava durumu widget'ı (İstanbul, 22°C, Parçalı Bulutlu)
    - Döviz kuru widget'ı (USD: ₺34.25, EUR: ₺37.80)
    - _Requirements: 3.1, 3.2, 3.3, 3.4, 3.5, 3.6_
  
  - [x] 2.3 Son aktiviteler ve hızlı işlemler bölümlerini ekle


    - Son randevular tablosu (3-4 örnek)
    - Hızlı işlemler kartı (Yeni Hayvan Ekle, Randevu Al butonları)
    - _Requirements: 3.6_

- [x] 3. Hayvanlarım sayfasını oluştur (customer-animals.html)




  - [x] 3.1 Hayvan listesi tablosunu oluştur


    - Customer navigation ekle
    - Sayfa başlığı ve "Yeni Hayvan Ekle" butonu
    - Hayvan tablosu (Ad, Tür, Cins, Yaş, Kilo, Detay butonu)
    - Mock data: 2 hayvan (Max - Golden Retriever, Luna - Van Kedisi)
    - _Requirements: 4.1, 4.2, 4.3, 4.4, 4.6_
  
  - [x] 3.2 Arama ve filtreleme UI'ını ekle

    - Arama input'u
    - Tür filtresi dropdown
    - Yaş filtresi dropdown
    - Filtreleri temizle butonu
    - _Requirements: 4.6_

- [x] 4. Hayvan Detay sayfasını oluştur (customer-animal-detail.html)







  - [x] 4.1 Hayvan bilgi kartını oluştur

    - Customer navigation ekle
    - Hayvan avatar (büyük)
    - Genel bilgiler (Ad, Tür, Cins, Yaş, Kilo, Kayıt Tarihi)
    - Mock data: Max detayları
    - _Requirements: 5.1, 5.7_
  
  - [x] 4.2 Geçmiş randevular bölümünü ekle


    - Randevu listesi tablosu
    - Mock data: 3 geçmiş randevu
    - _Requirements: 5.2, 5.7_
  
  - [x] 4.3 Geçmiş tedaviler bölümünü ekle

    - Tedavi kartları
    - Mock data: 2 tedavi kaydı
    - _Requirements: 5.3, 5.7_
  
  - [x] 4.4 Ödeme özeti bölümünü ekle

    - Toplam ödeme kartı
    - Kalan borç kartı
    - Mock data: Toplam ₺1,200, Kalan ₺350
    - _Requirements: 5.4, 5.7_
  
  - [x] 4.5 Sağlık geçmişi bölümünü ekle

    - Sağlık notları listesi
    - Mock data: 2-3 sağlık kaydı
    - _Requirements: 5.5, 5.7_

- [x] 5. Hayvan Ekleme sayfasını oluştur (customer-animal-create.html)





  - Customer navigation ekle
  - Hayvan ekleme formu (Ad, Tür, Cins, Yaş, Kilo)
  - Form validation
  - Submit butonu ve success message
  - _Requirements: 4.5, 4.6_

- [x] 6. Randevu Alma sayfasını oluştur (customer-appointment-create.html)





  - [x] 6.1 Randevu formu oluştur


    - Customer navigation ekle
    - Hayvan seçimi dropdown (mock data: Max, Luna)
    - Tarih ve saat input'ları
    - Notlar textarea
    - Submit butonu
    - _Requirements: 6.1, 6.4, 6.7_
  
  - [x] 6.2 Müsaitlik kontrolü UI'ını ekle


    - Conflict warning alert (gizli, JavaScript ile gösterilecek)
    - Tarih/saat seçiminde uyarı gösterme mantığı
    - _Requirements: 6.2, 6.3, 6.7_

- [x] 7. Randevularım sayfasını oluştur (customer-appointments.html)






  - [x] 7.1 Randevu listesi tablosunu oluştur

    - Customer navigation ekle
    - Sayfa başlığı ve "Yeni Randevu Al" butonu
    - Randevu tablosu (Tarih, Saat, Hayvan, Durum, Notlar, İşlemler)
    - Status badge'leri (Scheduled, Approved, Completed, Cancelled)
    - Mock data: 5 randevu (farklı statuslerde)
    - _Requirements: 7.1, 7.2, 7.3, 7.7_
  

  - [x] 7.2 İptal butonu mantığını ekle





    - Sadece "Scheduled" randevularda iptal butonu göster
    - Diğer statuslerde iptal butonu gizle
    - İptal butonu click handler
    - _Requirements: 7.5, 7.6, 7.7_

  
  - [x] 7.3 Randevu detayları ve tedavileri göster




    - Her randevu için tedavi bilgisi (varsa)
    - Tedavi notları ve maliyeti
    - Mock data: 2 randevuda tedavi bilgisi
    - _Requirements: 7.4, 7.7_

- [x] 8. Tedavilerim sayfasını oluştur (customer-treatments.html)





  - Customer navigation ekle
  - Tedavi kartları listesi
  - Her kart: Tarih, Hayvan, Randevu bilgisi, Tedavi tipi, Notlar, Maliyet
  - Mock data: 4 tedavi kaydı
  - _Requirements: 8.1, 8.2, 8.3, 8.4, 8.5, 8.7_

- [x] 9. Ödemelerim sayfasını oluştur (customer-payments.html)





  - [x] 9.1 Ödeme listesi kartlarını oluştur


    - Customer navigation ekle
    - Ödeme kartları (Tarih, Randevu, Tutar TRY)
    - Mock data: 4 ödeme kaydı
    - _Requirements: 9.1, 9.3, 9.4, 9.7_
  
  - [x] 9.2 Döviz kuru gösterimini ekle

    - Her ödeme kartında USD ve EUR karşılığı
    - Mock exchange rates: USD ₺34.25, EUR ₺37.80
    - _Requirements: 9.5, 9.7_
  

  - [x] 9.3 Kalan borç kartını ekle

    - Toplam borç gösterimi (TRY, USD, EUR)
    - Vurgulu tasarım (border-danger)
    - Mock data: ₺1,250 borç
    - _Requirements: 9.2, 9.7_

- [x] 10. Profil sayfasını oluştur (customer-profile.html)







  - [x] 10.1 Profil bilgileri formunu oluştur

    - Customer navigation ekle
    - Ad Soyad, E-posta, Telefon input'ları
    - Mock data: Ahmet Yılmaz, ahmet@example.com, 0532 123 45 67
    - Güncelle butonu
    - _Requirements: 10.1, 10.2, 10.3, 10.7_

  

  - [x] 10.2 Şifre değiştirme formunu oluştur

    - Mevcut şifre input'u
    - Yeni şifre input'u
    - Yeni şifre tekrar input'u
    - Şifreyi Değiştir butonu
    - _Requirements: 10.4, 10.5, 10.6, 10.7_

- [x] 11. Login sayfasını güncelle (login.html)





  - Vetify branding'i ekle (zaten task 1'de yapılacak)
  - Customer login seçeneği ekle (opsiyonel - görsel ayrım)
  - Customer dashboard'a yönlendirme butonu
  - _Requirements: 2.1, 2.2, 2.3_

- [x] 12. JavaScript form handler'larını ekle (script.js)





  - [x] 12.1 Customer appointment form handler

    - Form submit event listener
    - Success message gösterimi
    - Randevularım sayfasına yönlendirme
    - _Requirements: 6.4_
  
  - [x] 12.2 Customer animal create form handler

    - Form submit event listener
    - Success message gösterimi
    - Hayvanlarım sayfasına yönlendirme
    - _Requirements: 4.5_
  
  - [x] 12.3 Profile update form handlers


    - Profil güncelleme form handler
    - Şifre değiştirme form handler
    - Success message gösterimi
    - _Requirements: 10.2, 10.3, 10.5, 10.6_
  
  - [x] 12.4 Appointment cancel handler

    - İptal butonu click handler
    - Confirmation dialog
    - Success message gösterimi
    - _Requirements: 7.5, 7.6_
  
  - [x] 12.5 Conflict warning handler

    - Tarih/saat değişikliğinde event listener
    - Random conflict simulation
    - Warning alert göster/gizle
    - _Requirements: 6.2, 6.3_

- [x] 13. Responsive tasarım kontrolü ve düzeltmeleri





  - Tüm customer sayfalarını mobile'da test et (320px-767px)
  - Tablet görünümünü test et (768px-991px)
  - Desktop görünümünü test et (992px+)
  - Gerekli CSS düzeltmelerini yap
  - _Requirements: 3.6, 4.6, 5.7, 6.7, 7.7, 8.7, 9.7, 10.7, 12.5_

- [x] 14. Tasarım tutarlılığı kontrolü





  - Admin ve customer sayfalarını yan yana karşılaştır
  - Renk, font, spacing tutarlılığını kontrol et
  - Component stilleri tutarlılığını kontrol et
  - Gerekli düzeltmeleri yap
  - _Requirements: 12.1, 12.2, 12.3, 12.4, 12.5_
