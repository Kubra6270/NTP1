using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KargoTakip
{
    public enum KargoDurum
    {
        Hazirlaniyor,
        Yolda,
        TeslimEdildi
    }

    interface ITakipEdilebilir
    {
        string TakipNumarasi { get; }
        KargoDurum Durum { get; set; }
        void DurumGuncelle(KargoDurum yeniDurum);
        string TakipBilgisi();
    }
}
