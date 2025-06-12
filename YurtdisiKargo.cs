using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip
{
    public class YurtdisiKargo : Gonderi
    {
        public string Ulke { get; set; }
        public string GumrukKodu { get; set; }

        public YurtdisiKargo(string gonderenAd, string gonderenAdres, string aliciAd, string aliciAdres, double agirlik, string ulke, string gumrukKodu)
            : base(gonderenAd, gonderenAdres, aliciAd, aliciAdres, agirlik)
        {
            Ulke = ulke;
            GumrukKodu = gumrukKodu;
        }

        public override string TakipBilgisi()
        {
            return $"[YURTDIŞI] {TakipNumarasi} | {GonderenAd} → {AliciAd} | {Ulke} | {DurumMetni()} | {Agirlik}kg | {TeslimatUcreti():C}";
        }

        public override double TeslimatUcreti()
        {
            return Agirlik * 50; // Yurtdışı kg başına 50TL olsun
        }

        private string DurumMetni()
        {
            switch (Durum)
            {
                case KargoDurum.Hazirlaniyor:
                    return "Hazırlanıyor";
                case KargoDurum.Yolda:
                    return "Yolda";
                case KargoDurum.TeslimEdildi:
                    return "Teslim Edildi";
                default:
                    return "Bilinmiyor";
            }
        }
    }
}
