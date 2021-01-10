using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortali.Data.Model
{
    [Table("User")]
   public class User : BaseEntity
    {
       
        [MaxLength(150,ErrorMessage ="Lütfen 150 karakterden fazla değer girmeyiniz ! ")]
        [Display(Name ="Ad Soyad")]
        public string AdSoyad { get; set; }
        [Display(Name ="E-mail")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$",ErrorMessage ="Gecerli bir mail adresi giriniz !")]
        public string Email { get; set; }
        [Display(Name ="Sifre")]
        [MaxLength(16, ErrorMessage = "Lütfen 16 karakterden fazla değer girmeyiniz ! ")]
        [DataType(DataType.Password)]
        [Required]//boş gecilemez yaptık
        public string Sifre { get; set; }
        //[Display(Name = "Kayıt Tarihi")]
        //public DateTime KayitTarihi { get; set; }
       
        public virtual Rol Rol { get; set; }
    }
}
