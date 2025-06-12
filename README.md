# Kargo Takip Sistemi

Bu proje, gönderi durumlarının **hazırlanıyor**, **yolda** ve **teslim edildi** gibi adımlarla takip edilmesini sağlayan basit bir Kargo Takip Sistemidir. Sistem, C# diliyle Windows Forms üzerinde geliştirilmiştir ve Nesne Yönelimli Programlama (OOP) prensiplerini uygular.

## 🧩 Özellikler

- Gönderi oluşturma (Yurtiçi ve Yurtdışı)
- Gönderi durumu güncelleme (Hazırlanıyor → Yolda → Teslim Edildi)
- Takip numarası ile gönderi sorgulama

## 🧠 Kullanılan OOP Kavramları

### ✔️ Kalıtım
- `Gonderi` adlı temel sınıf üzerinden `Yurtici` ve `Yurtdisi` sınıfları türetilmiştir.

### ✔️ Enum
- Gönderi durumları `Durum` adında bir `enum` ile tanımlanmıştır:  
  - `Bekliyor`  
  - `Yolda`  
  - `TeslimEdildi`

### ✔️ Arayüz (Interface)
- `ITakipEdilebilir` arayüzü ile gönderi takibi işlemleri soyutlanmıştır.

## 🧱 Modüller

- **Gönderi Oluşturma:** Yeni bir kargo gönderisi ekleme.
- **Durum Güncelleme:** Seçilen gönderinin durumunu `enum` ve `switch` yapısı kullanarak güncelleme.
- **Takip Numarası ile Sorgulama:** Gönderi listesinde takip numarasına göre arama ve bilgi görüntüleme.

## 💡 İpuçları

- Gönderi durum güncellemeleri için `switch-case` yapısı ile `enum` kullanılmıştır. Bu sayede güncellemeler daha okunabilir ve bakımı kolay hale getirilmiştir.
- Sistemde benzersiz takip numaraları ile arama yapılabilir.

## 🚀 Teknolojiler

- C#
- Windows Forms (WinForms)
- .NET Framework
- Nesne Yönelimli Programlama (OOP)

## 📁 Proje Yapısı
KargoTakipSistemi/
├── Form1.cs
├── Gonderi.cs
├── Yurtici.cs
├── Yurtdisi.cs
├── Durum.cs
├── ITakipEdilebilir.cs
├── Form1.Designer.cs
├── Program.cs
└── README.md
