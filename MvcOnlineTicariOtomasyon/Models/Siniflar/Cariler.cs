using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Cariler
    {
        [Key]
        public int CariId { get; set; }

        [Display(Name = "Cari Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariAd { get; set; }

        [Display(Name = "Cari Soyadı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30, ErrorMessage = "En fazla 30 karakter yazabilirsiniz!")]
        [Required(ErrorMessage = "Bu alanı boş geçemezsiniz!")]
        public string CariSoyad { get; set; }

        [Display(Name = "Şehir")]
        [Column(TypeName = "Varchar")]
        [StringLength(13)]
        public string CariSehir { get; set; }

        [Display(Name = "Mail")]
        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
    }
}