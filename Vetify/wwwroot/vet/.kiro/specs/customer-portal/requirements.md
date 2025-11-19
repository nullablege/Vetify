# Requirements Document

## Introduction

Bu doküman, Vetify veteriner kliniği yönetim sistemine eklenecek müşteri portalı özelliklerini tanımlar. Müşteri portalı, klinik müşterilerinin kendi hayvanlarını yönetmelerine, randevu almalarına, tedavi geçmişlerini görüntülemelerine ve ödemeleri takip etmelerine olanak sağlayacaktır. Ayrıca, mevcut sistemdeki tüm sayfalarda marka adı "VetCare"den "Vetify"ye güncellenecektir.

**Teknik Kısıtlamalar:**
- Backend işlevselliği bulunmayacak
- Tüm sayfalar statik HTML olarak oluşturulacak
- Test verileri HTML içinde statik olarak tanımlanacak
- JavaScript framework kullanılmayacak
- Mevcut sistemle aynı teknoloji stack kullanılacak (Bootstrap 5, vanilla JavaScript)
- Tasarım dili mevcut admin sayfalarıyla birebir aynı olacak

## Glossary

- **Customer Portal**: Müşterilerin kendi hesaplarına giriş yaparak hayvanlarını ve randevularını yönetebilecekleri web arayüzü
- **Vetify System**: Veteriner kliniği yönetim sistemi (eski adı: VetCare)
- **Customer User**: Klinik müşterisi kullanıcı rolü
- **Admin User**: Klinik yöneticisi/veteriner kullanıcı rolü
- **Animal**: Müşteriye ait evcil hayvan kaydı
- **Appointment**: Randevu kaydı
- **Treatment**: Tedavi kaydı
- **Payment**: Ödeme kaydı
- **Medical History**: Hayvanın sağlık geçmişi
- **Weather Widget**: Klinik lokasyonu için hava durumu gösterimi
- **Currency Widget**: Döviz kuru gösterimi (TRY/USD, TRY/EUR)
- **Responsive Design**: Tüm ekran boyutlarında uyumlu çalışan tasarım
- **Static HTML**: Backend olmadan, sabit HTML içeriği ile oluşturulan sayfa
- **Mock Data**: Test amaçlı HTML içinde tanımlanan örnek veriler

## Requirements

### Requirement 1: Marka Adı Güncelleme

**User Story:** As a system administrator, I want all pages to display "Vetify" as the brand name, so that the system reflects the correct brand identity

#### Acceptance Criteria

1. THE Vetify System SHALL display "Vetify" as the brand name in the navigation bar on all pages
2. THE Vetify System SHALL display "Vetify" as the page title prefix in browser tabs on all pages
3. THE Vetify System SHALL display "Vetify" in the login page branding section
4. THE Vetify System SHALL display "Vetify" in the registration page branding section
5. THE Vetify System SHALL maintain consistent brand styling across all pages

### Requirement 2: Müşteri Kimlik Doğrulama

**User Story:** As a customer, I want to log in to my account with my credentials, so that I can access my personal information and my animals' data

#### Acceptance Criteria

1. THE Vetify System SHALL provide a login page with customer login option
2. THE Vetify System SHALL provide a visual distinction between customer and admin login options
3. WHEN a user clicks customer login button, THE Vetify System SHALL navigate to the customer dashboard page
4. THE Vetify System SHALL display customer-specific navigation after login
5. THE Vetify System SHALL provide a logout link that returns to the login page

### Requirement 3: Müşteri Anasayfası (Dashboard)

**User Story:** As a customer, I want to see an overview of my animals and appointments on my dashboard, so that I can quickly access important information

#### Acceptance Criteria

1. THE Vetify System SHALL display the total count of animals with Mock Data
2. THE Vetify System SHALL display the count of scheduled appointments with Mock Data
3. THE Vetify System SHALL display treatments and payments from the last 30 days with Mock Data
4. THE Vetify System SHALL display weather information for the clinic location using Static HTML
5. THE Vetify System SHALL display currency exchange rates (TRY/USD, TRY/EUR) using Static HTML
6. THE Vetify System SHALL render the customer dashboard with Responsive Design matching admin pages

### Requirement 4: Hayvanlarım Sayfası

**User Story:** As a customer, I want to view a list of my animals, so that I can manage and access their information

#### Acceptance Criteria

1. THE Vetify System SHALL display a list of animals with Mock Data
2. THE Vetify System SHALL display animal name, species, breed, age, and weight for each animal
3. WHEN a user clicks on an animal, THE Vetify System SHALL navigate to the animal detail page
4. THE Vetify System SHALL provide an "Add New Animal" button that navigates to an add animal form
5. THE Vetify System SHALL render the animals list with Responsive Design matching admin pages

### Requirement 5: Hayvan Detay Sayfası

**User Story:** As a customer, I want to view detailed information about my animal, so that I can track its health history and appointments

#### Acceptance Criteria

1. THE Vetify System SHALL display complete animal information (name, species, breed, age, weight) with Mock Data
2. THE Vetify System SHALL display past appointments for the animal with Mock Data
3. THE Vetify System SHALL display past treatments for the animal with Mock Data
4. THE Vetify System SHALL display total payment amount and remaining debt with Mock Data
5. THE Vetify System SHALL display Medical History with Mock Data
6. THE Vetify System SHALL render the animal detail page with Responsive Design matching admin pages

### Requirement 6: Randevu Alma

**User Story:** As a customer, I want to create an appointment for my animal, so that I can schedule a visit to the clinic

#### Acceptance Criteria

1. THE Vetify System SHALL display animals in a selection dropdown with Mock Data
2. THE Vetify System SHALL provide date and time input fields for appointment scheduling
3. THE Vetify System SHALL display a conflict warning message area in the form
4. THE Vetify System SHALL provide a submit button that shows a success message
5. THE Vetify System SHALL render the appointment creation form with Responsive Design matching admin pages

### Requirement 7: Randevularım Sayfası

**User Story:** As a customer, I want to view all my appointments, so that I can track scheduled, completed, and cancelled visits

#### Acceptance Criteria

1. THE Vetify System SHALL display appointments with Mock Data
2. THE Vetify System SHALL display appointment status (Scheduled, Approved, Completed, Cancelled) with color-coded badges
3. THE Vetify System SHALL display appointment date, time, and notes
4. THE Vetify System SHALL display treatments for each appointment with Mock Data
5. THE Vetify System SHALL show cancel buttons only for appointments with "Scheduled" status
6. THE Vetify System SHALL render the appointments list with Responsive Design matching admin pages

### Requirement 8: Tedavilerim Sayfası

**User Story:** As a customer, I want to view all treatments performed on my animals, so that I can track their medical history

#### Acceptance Criteria

1. THE Vetify System SHALL display treatments with Mock Data
2. THE Vetify System SHALL display the appointment associated with each treatment
3. THE Vetify System SHALL display treatment type for each treatment
4. THE Vetify System SHALL display treatment notes for each treatment
5. THE Vetify System SHALL display treatment cost for each treatment
6. THE Vetify System SHALL render the treatments list with Responsive Design matching admin pages

### Requirement 9: Ödemelerim Sayfası

**User Story:** As a customer, I want to view my payment history and outstanding debts, so that I can manage my financial obligations

#### Acceptance Criteria

1. THE Vetify System SHALL display payments with Mock Data
2. THE Vetify System SHALL display remaining debt with Mock Data
3. THE Vetify System SHALL display payments grouped by appointment
4. THE Vetify System SHALL display payment amounts in Turkish Lira (TRY)
5. THE Vetify System SHALL display equivalent amounts in USD and EUR with Static HTML
6. THE Vetify System SHALL render the payments page with Responsive Design matching admin pages

### Requirement 10: Müşteri Profil Yönetimi

**User Story:** As a customer, I want to update my profile information, so that I can keep my contact details current

#### Acceptance Criteria

1. THE Vetify System SHALL display customer name, email, and phone number fields with Mock Data
2. THE Vetify System SHALL provide input fields for updating profile information
3. THE Vetify System SHALL provide a save button that shows a success message
4. THE Vetify System SHALL provide password change fields (current, new, confirm)
5. THE Vetify System SHALL provide a change password button that shows a success message
6. THE Vetify System SHALL render the profile page with Responsive Design matching admin pages

### Requirement 11: Navigasyon ve Erişim Kontrolü

**User Story:** As a customer, I want to access only customer-specific pages, so that I cannot interfere with administrative functions

#### Acceptance Criteria

1. THE Vetify System SHALL provide a customer-specific navigation menu with links to customer pages
2. THE Vetify System SHALL display customer navigation items (Dashboard, Hayvanlarım, Randevularım, Tedavilerim, Ödemelerim, Profil)
3. THE Vetify System SHALL use the same navigation styling as admin pages
4. THE Vetify System SHALL display customer name in the navigation bar
5. THE Vetify System SHALL maintain consistent navigation styling across all customer pages

### Requirement 12: Tasarım Tutarlılığı

**User Story:** As a user, I want all customer portal pages to have consistent design with existing admin pages, so that the system feels unified

#### Acceptance Criteria

1. THE Vetify System SHALL use the same color scheme for customer portal pages as admin pages
2. THE Vetify System SHALL use the same typography for customer portal pages as admin pages
3. THE Vetify System SHALL use the same component styles (buttons, cards, forms) for customer portal pages as admin pages
4. THE Vetify System SHALL use the same layout structure for customer portal pages as admin pages
5. THE Vetify System SHALL apply Responsive Design to all customer portal pages matching the responsiveness of admin pages
