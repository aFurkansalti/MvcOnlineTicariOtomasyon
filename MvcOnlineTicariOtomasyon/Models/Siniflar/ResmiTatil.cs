using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class ResmiTatil
    {
        [Key]
        public int Id { get; set; } 

        [StringLength(25, ErrorMessage = "En fazla 25 karakter yazabilirsiniz!")]
        [Column(TypeName = "Varchar")]
        [Display(Name = "Tatil Günün İsmi")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string GunIsim { get; set; }

        [Display(Name = "Tatil Süresi")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public double Sure {  get; set; }

        [StringLength(10, ErrorMessage = "En fazla 10 karakter yazabilirsiniz!")]
        [Column(TypeName = "Varchar")]
        [Display(Name = "Gün")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string Gun { get; set; }
        public DateTime Tarih { get; set; }
        public bool Durum { get; set; }

    }
}