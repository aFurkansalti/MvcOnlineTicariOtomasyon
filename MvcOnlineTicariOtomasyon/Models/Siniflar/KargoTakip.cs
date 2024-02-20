using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class KargoTakip
    {
        [Key]
        public int KargoTakipId { get; set; }

        [Required(ErrorMessage = "Boş geçilmez!")]
        [Column(TypeName = "VarChar")]
        [StringLength(10)]
        public string TakipKodu { get; set; }

        [Column(TypeName = "VarChar")]
        [StringLength(100)]
        public string Aciklama { get; set; }
        
        [Required(ErrorMessage = "Boş geçilmez!")]
        public DateTime Tarih { get; set; }
    }
}