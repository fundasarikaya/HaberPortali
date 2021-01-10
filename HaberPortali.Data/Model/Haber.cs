using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortali.Data.Model
{
    [Table("Haber")]
   public class Haber:BaseEntity
    {
        //[Key]
        //public int ID { get; set; }
        [Display(Name ="Haber Başlık")]
        [MaxLength(255,ErrorMessage ="Cok fazla girdiniz !")]
        [Required]
        public string Baslik { get; set; }
        [Display(Name = "Kısa Açıklama")]
        public string KisaAciklama { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public int Okuma { get; set; }

        public int UserID { get; set; }


        //[Display(Name ="Aktif Mi")]
        //public bool AktifMi { get; set; }
        //[Display(Name = "Eklenme Tarihi")]
        //public DateTime EklenmeTarihi { get; set; }
        public virtual User User { get; set; }
        [Display(Name = "Resim")]
        [MaxLength(255, ErrorMessage = "Cok fazla girdiniz !")]
        public string Resim { get; set; }
        public virtual ICollection<Resim> Resims { get; set; }
        public int KategoriID { get; set; }
        public virtual Kategori Kategori { get; set; }
    }
}
