using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Personel
    {
        [Key]
        public int PersonelId { get; set; }

        [Required(ErrorMessage = "Boş geçilmez!")]
        [Display(Name = "Personel Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelAd { get; set; }

        [Required(ErrorMessage = "Boş geçilmez!")]
        [Display(Name = "Personel Soyadı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string PersonelSoyad { get; set; }

        [Display(Name = "Personel Görsel")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string PersonelGorsel { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }
        public virtual Departman Departman { get; set; }

        [Required(ErrorMessage = "Lütfen seçiniz!")]
        public int DepartmanId { get; set; }
    }
}