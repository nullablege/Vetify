// Klinik koordinatları - Tek noktadan yönetim
const CLINIC_COORDINATES = {
    lat: 35.1369196429184,
    lon: 33.92549188590959
};

// Cookie yardımcı fonksiyonları
function setCookie(name, value, hours) {
    const date = new Date();
    date.setTime(date.getTime() + (hours * 60 * 60 * 1000));
    const expires = "expires=" + date.toUTCString();
    document.cookie = name + "=" + JSON.stringify(value) + ";" + expires + ";path=/";
}

function getCookie(name) {
    const nameEQ = name + "=";
    const ca = document.cookie.split(';');
    for (let i = 0; i < ca.length; i++) {
        let c = ca[i];
        while (c.charAt(0) === ' ') c = c.substring(1, c.length);
        if (c.indexOf(nameEQ) === 0) {
            try {
                return JSON.parse(c.substring(nameEQ.length, c.length));
            } catch (e) {
                return null;
            }
        }
    }
    return null;
}

// Hava durumu sembol kodunu Türkçe metne çevir
function getWeatherDescription(symbolCode) {
    const weatherMap = {
        'clearsky': 'Açık',
        'fair': 'Az Bulutlu',
        'partlycloudy': 'Parçalı Bulutlu',
        'cloudy': 'Bulutlu',
        'fog': 'Sisli',
        'rain': 'Yağmurlu',
        'lightrain': 'Hafif Yağmurlu',
        'heavyrain': 'Şiddetli Yağmurlu',
        'sleet': 'Karla Karışık Yağmur',
        'snow': 'Karlı',
        'lightsnow': 'Hafif Karlı',
        'heavysnow': 'Yoğun Karlı',
        'rainshowers': 'Sağanak Yağışlı',
        'snowshowers': 'Kar Yağışlı',
        'sleetshowers': 'Sulu Kar Yağışlı',
        'thunderstorm': 'Gök Gürültülü Fırtına'
    };

    for (const key in weatherMap) {
        if (symbolCode.includes(key)) {
            return weatherMap[key];
        }
    }
    return 'Bilinmiyor';
}

// Mesafe hesaplama (Haversine formülü)
function getDistanceKm(lat1, lon1, lat2, lon2) {
    const R = 6371; // Dünya yarıçapı (km)
    const toRad = x => x * Math.PI / 180;
    const dLat = toRad(lat2 - lat1);
    const dLon = toRad(lon2 - lon1);
    const a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
        Math.cos(toRad(lat1)) * Math.cos(toRad(lat2)) *
        Math.sin(dLon / 2) * Math.sin(dLon / 2);
    const c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
    return R * c; // km
}

// Süre formatı (dakika -> saat dakika)
function formatDuration(minutes) {
    if (minutes < 60) {
        return `Yaklaşık ${Math.round(minutes)} dakika`;
    }
    const hours = Math.floor(minutes / 60);
    const mins = Math.round(minutes % 60);
    if (mins === 0) {
        return `Yaklaşık ${hours} saat`;
    }
    return `Yaklaşık ${hours} saat ${mins} dakika`;
}

// Klinik hava durumu
async function fetchClinicWeather() {
    const cached = getCookie('clinicWeather');
    if (cached) {
        updateClinicWeatherUI(cached);
        return;
    }

    try {
        // Hava durumu API'si
        const weatherResponse = await fetch(
            `https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=${CLINIC_COORDINATES.lat}&lon=${CLINIC_COORDINATES.lon}`,
            { headers: { "User-Agent": "VetClinicApp/1.0" } }
        );

        if (!weatherResponse.ok) {
            throw new Error(`Weather API error: ${weatherResponse.status}`);
        }

        const weatherData = await weatherResponse.json();
        const temp = Math.round(weatherData.properties.timeseries[0].data.instant.details.air_temperature);
        const symbolCode = weatherData.properties.timeseries[0].data.next_1_hours?.summary?.symbol_code ||
            weatherData.properties.timeseries[0].data.next_6_hours?.summary?.symbol_code ||
            'clearsky_day';
        const weatherDesc = getWeatherDescription(symbolCode);

        // Klinik şehir adını API'den çek
        const locationResponse = await fetch(
            `https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${CLINIC_COORDINATES.lat}&longitude=${CLINIC_COORDINATES.lon}&localityLanguage=tr`
        );
        const locationData = await locationResponse.json();
        const city = locationData.city || locationData.locality || 'Gazimağusa';

        const clinicData = {
            temp: temp,
            description: weatherDesc,
            city: city
        };

        setCookie('clinicWeather', clinicData, 3);
        updateClinicWeatherUI(clinicData);
    } catch (error) {
        console.error('Klinik hava durumu alınamadı:', error);
        // Hata durumunda varsayılan değerler
        updateClinicWeatherUI({ temp: '--', description: 'Yükleniyor', city: 'Gazimağusa' });
    }
}

function updateClinicWeatherUI(data) {
    const tempElement = document.getElementById('klinikSicaklik');
    const weatherElement = document.getElementById('klinikHavaDurum');

    if (tempElement) tempElement.textContent = `${data.temp}°C`;
    if (weatherElement) weatherElement.textContent = `${data.city}, ${data.description}`;
}

// Kullanıcı konumu hava durumu ve mesafe hesaplama
async function fetchUserLocationWeather() {
    const cached = getCookie('userWeather');
    if (cached) {
        updateUserWeatherUI(cached);
        if (cached.distance !== undefined && cached.duration !== undefined) {
            updateDistanceUI(cached.distance, cached.duration);
        }
        return;
    }

    if (!navigator.geolocation) {
        console.error('Tarayıcı konum desteği sunmuyor');
        return;
    }

    navigator.geolocation.getCurrentPosition(async (position) => {
        try {
            const userLat = position.coords.latitude;
            const userLon = position.coords.longitude;

            // Mesafe hesaplama
            const distanceKm = getDistanceKm(userLat, userLon, CLINIC_COORDINATES.lat, CLINIC_COORDINATES.lon);
            const durationMinutes = distanceKm * 3; // Ortalama 20 km/saat hız varsayımı

            // Hava durumu API'si
            const weatherResponse = await fetch(
                `https://api.met.no/weatherapi/locationforecast/2.0/compact?lat=${userLat}&lon=${userLon}`,
                { headers: { "User-Agent": "VetClinicApp/1.0" } }
            );
            const weatherData = await weatherResponse.json();

            const temp = Math.round(weatherData.properties.timeseries[0].data.instant.details.air_temperature);
            const symbolCode = weatherData.properties.timeseries[0].data.next_1_hours?.summary?.symbol_code ||
                weatherData.properties.timeseries[0].data.next_6_hours?.summary?.symbol_code ||
                'clearsky_day';
            const weatherDesc = getWeatherDescription(symbolCode);

            // Konum bilgisi
            const locationResponse = await fetch(
                `https://api.bigdatacloud.net/data/reverse-geocode-client?latitude=${userLat}&longitude=${userLon}&localityLanguage=tr`
            );
            const locationData = await locationResponse.json();
            const locality = locationData.locality || locationData.city || 'Bilinmiyor';

            const userData = {
                temp: temp,
                description: weatherDesc,
                locality: locality,
                distance: distanceKm,
                duration: durationMinutes
            };

            setCookie('userWeather', userData, 3);
            updateUserWeatherUI(userData);
            updateDistanceUI(distanceKm, durationMinutes);
        } catch (error) {
            console.error('Kullanıcı konumu hava durumu alınamadı:', error);
        }
    }, (error) => {
        console.error('Konum izni alınamadı:', error);
    });
}

function updateUserWeatherUI(data) {
    const tempElement = document.getElementById('konumSicaklik');
    const weatherElement = document.getElementById('konumHavaDurumu');

    if (tempElement) tempElement.textContent = `${data.temp}°C`;
    if (weatherElement) weatherElement.textContent = `${data.locality}, ${data.description}`;
}

function updateDistanceUI(distanceKm, durationMinutes) {
    const distanceElement = document.getElementById('uzaklikKm');
    const durationElement = document.getElementById('uzaklikSure');

    if (distanceElement && distanceKm !== undefined) {
        distanceElement.textContent = `${distanceKm.toFixed(1)} km`;
    }
    if (durationElement && durationMinutes !== undefined) {
        durationElement.textContent = formatDuration(durationMinutes);
    }
}

async function fetchCurrencyRates() {
    const cached = getCookie('currencyRates');
    if (cached) {
        updateCurrencyUI(cached);
        return;
    }

    try {
        const response = await fetch('https://api.exchangerate-api.com/v4/latest/TRY');
        const data = await response.json();

        const usdRate = (1 / data.rates.USD).toFixed(2);
        const eurRate = (1 / data.rates.EUR).toFixed(2);

        const rates = {
            usd: usdRate,
            eur: eurRate
        };

        setCookie('currencyRates', rates, 3);
        updateCurrencyUI(rates);
    } catch (error) {
        console.error('Döviz kurları alınamadı:', error);
    }
}

function updateCurrencyUI(rates) {
    const usdElement = document.getElementById('usd');
    const eurElement = document.getElementById('eur');

    if (usdElement) usdElement.textContent = `${rates.usd} ₺`;
    if (eurElement) eurElement.textContent = `${rates.eur} ₺`;
}

function initCustomerDashboard() {
    const currentPath = window.location.pathname;
    const isCustomerPage = currentPath.includes('/Customer/Index') || currentPath.includes('/Customer') || currentPath.includes('customer-dashboard');

    if (isCustomerPage) {
        fetchClinicWeather();
        fetchUserLocationWeather();
        fetchCurrencyRates();
    }
}

document.addEventListener('DOMContentLoaded', function () {
    initCustomerDashboard();

    const togglePasswordBtns = document.querySelectorAll('#togglePassword');
    togglePasswordBtns.forEach(btn => {
        btn.addEventListener('click', function () {
            const passwordInput = this.closest('.input-group').querySelector('input');
            const icon = this.querySelector('i');

            if (passwordInput.type === 'password') {
                passwordInput.type = 'text';
                icon.classList.remove('bi-eye');
                icon.classList.add('bi-eye-slash');
            } else {
                passwordInput.type = 'password';
                icon.classList.remove('bi-eye-slash');
                icon.classList.add('bi-eye');
            }
        });
    });

    document.querySelectorAll('.btn-edit').forEach(function (btn) {
        btn.addEventListener('click', function () {
            const id = this.getAttribute('data-id');
            const url = this.getAttribute('data-url');

            fetch(`${url}?id=${id}`)
                .then(r => {
                    if (!r.ok) throw new Error('Tedavi bulunamadı');
                    return r.json();
                })
                .then(data => {
                    console.log(data);
                    document.getElementById('editId').value = data.id;
                    document.getElementById('editTreatmentType').value = data.tedaviTuru;
                    document.getElementById('editTreatmentCost').value = data.ucret;
                    document.getElementById('editTreatmentNotes').value = data.notlar ?? '';

                    const modalEl = document.getElementById('editTreatmentModal');
                    const modal = new bootstrap.Modal(modalEl);
                    modal.show();
                })
                .catch(err => {
                    console.error(err);
                    alert('Tedavi bilgileri alınırken hata oluştu.');
                });
        });
    });

    document.querySelectorAll('.btn-view').forEach(function (btn) {
        btn.addEventListener('click', function () {
            const animal = this.dataset.animal || '-';
            const owner = this.dataset.owner || '-';
            const type = this.dataset.type || '-';
            const date = this.dataset.date || '-';
            const cost = this.dataset.cost || '-';
            const notes = this.dataset.notes || '-';

            document.getElementById('viewAnimalName').textContent = animal;
            document.getElementById('viewOwnerName').textContent = owner;
            document.getElementById('viewTreatmentType').textContent = type;
            document.getElementById('viewTreatmentDate').textContent = date;
            document.getElementById('viewTreatmentCost').textContent = '₺' + cost;
            document.getElementById('viewTreatmentNotes').textContent = notes;
            // data-bs-* modalı zaten açıyor, burada ekstra show() yok.
        });
    });



    document.getElementById("musteriSelect").addEventListener("change", async function () {
        const musteriId = this.value;

        const response = await fetch(`/Vet/HayvanGetir?musteriId=${musteriId}`);
        const data = await response.json();

        const hayvanSelect = document.getElementById("animalSelect");
        hayvanSelect.innerHTML = "";
        hayvanSelect.innerHTML = "<option value=''>Hayvan seçiniz...</option>";
        data.forEach(x => {
            const opt = document.createElement("option");
            opt.value = x.id;
            opt.textContent = x.ad;
            hayvanSelect.appendChild(opt);
        });
    });


    const resetFiltersBtn = document.getElementById('resetFilters');
    if (resetFiltersBtn) {
        resetFiltersBtn.addEventListener('click', function () {
            const searchInput = document.getElementById('searchInput');
            const dateFilter = document.getElementById('dateFilter');
            const statusFilter = document.getElementById('statusFilter');
            const speciesFilter = document.getElementById('speciesFilter');
            const ageFilter = document.getElementById('ageFilter');
            const animalFilter = document.getElementById('animalFilter');
            const treatmentTypeFilter = document.getElementById('treatmentTypeFilter');
            const paymentMethodFilter = document.getElementById('paymentMethodFilter');

            if (searchInput) searchInput.value = '';
            if (dateFilter) dateFilter.value = '';
            if (statusFilter) statusFilter.value = '';
            if (speciesFilter) speciesFilter.value = '';
            if (ageFilter) ageFilter.value = '';
            if (animalFilter) animalFilter.value = '';
            if (treatmentTypeFilter) treatmentTypeFilter.value = '';
            if (paymentMethodFilter) paymentMethodFilter.value = '';
        });
    }



    const searchInput = document.getElementById('searchInput');
    if (searchInput) {
        searchInput.addEventListener('input', function () {
            const searchTerm = this.value.toLowerCase();
            const tableRows = document.querySelectorAll('tbody tr');

            tableRows.forEach(row => {
                const text = row.textContent.toLowerCase();
                if (text.includes(searchTerm)) {
                    row.style.display = '';
                } else {
                    row.style.display = 'none';
                }
            });
        });
    }

    const appointmentDate = document.getElementById('appointmentDate');
    if (appointmentDate) {
        const today = new Date().toISOString().split('T')[0];
        appointmentDate.setAttribute('min', today);
    }

    const paymentDate = document.getElementById('paymentDate');
    if (paymentDate) {
        const today = new Date().toISOString().split('T')[0];
        paymentDate.value = today;
    }



    const speciesSelect = document.getElementById('species');
    if (speciesSelect) {
        speciesSelect.addEventListener('change', function () {
            const breedInput = document.getElementById('breed');
            if (breedInput) {
                breedInput.focus();
            }
        });
    }

    const statCards = document.querySelectorAll('.stat-card');
    statCards.forEach((card, index) => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';

        setTimeout(() => {
            card.style.transition = 'all 0.5s ease';
            card.style.opacity = '1';
            card.style.transform = 'translateY(0)';
        }, index * 100);
    });

    const customCards = document.querySelectorAll('.custom-card');
    const observerOptions = {
        threshold: 0.1,
        rootMargin: '0px 0px -50px 0px'
    };

    const observer = new IntersectionObserver((entries) => {
        entries.forEach(entry => {
            if (entry.isIntersecting) {
                entry.target.style.opacity = '1';
                entry.target.style.transform = 'translateY(0)';
            }
        });
    }, observerOptions);

    customCards.forEach(card => {
        card.style.opacity = '0';
        card.style.transform = 'translateY(20px)';
        card.style.transition = 'all 0.5s ease';
        observer.observe(card);
    });

});
