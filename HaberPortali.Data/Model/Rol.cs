﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaberPortali.Data.Model
{
    [Table("Rol")]
   public class Rol : BaseEntity
    {
       
        [Display(Name ="Rol Adı:")]
        [MinLength(3,ErrorMessage ="Lütfen 3 karakterden fazla değer giriniz !"),MaxLength(150,ErrorMessage ="Lütfen 150 karakterden fazla değer girmeyiniz !")]
        public string RolAdi { get; set; }
    }
}
