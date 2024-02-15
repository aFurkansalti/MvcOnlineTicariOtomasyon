using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisId { get; set; }
        // ürün
        // cari
        // personel
        public DateTime Tarih { get; set; }

        [Required(ErrorMessage = "Adeti boş geçemezsiniz.")]
        public int Adet { get; set; }

        [Required(ErrorMessage = "Fiyatı boş geçemezsiniz.")]
        public decimal Fiyat { get; set; }

        [Display(Name = "Toplam Tutar")]
        [Required(ErrorMessage = "Toplam tutarı boş geçemezsiniz.")]
        public decimal ToplamTutar { get; set; }

        public int UrunId { get; set; }
        public int CariId { get; set; }
        public int PersonelId { get; set; }

        public virtual Urun Urun { get; set; }
        public virtual Cariler Cariler { get; set; }
        public virtual Personel Personel { get; set; }
    }
}