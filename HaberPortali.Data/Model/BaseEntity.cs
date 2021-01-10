using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortali.Data.Model
{
   public class BaseEntity
    {
        public int ID { get; set; }
        public DateTime Tarih = DateTime.Now;
        public bool Aktif = true;
        public DateTime EklenmeTarihi { get
            {
                return Tarih;//insert yapılırken varsıyalan degeri alır
            }
            set
            {
                Tarih = value;//ekleme yaparken degiştirmek istersek set kısmında yapılır
            }
        }
        public bool AktifMi
        {
            get
            {
                return Aktif;
            }
            set
            {
                Aktif = value;
            }
        }
    }
}
//bunlar tum tablolarda oldugu icin boyle bir base oluşrutduk