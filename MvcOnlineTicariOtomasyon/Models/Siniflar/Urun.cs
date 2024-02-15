using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {
        [Key]
        public int UrunId { get; set; }

        [Required(ErrorMessage = "Boş geçilmez!")]
        [Display(Name = "Ürün Adı")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }

        [Required(ErrorMessage = "Boş geçilmez!")]
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }

        [Display(Name = "Alış Fiyatı")]
        //[DataType(DataType.Currency, ErrorMessage = "Geçersiz karakter.")]
        //[RegularExpression(@"^\d+([\.,]\d{1,2})?$", ErrorMessage = "Geçersiz fiyat formatı")]
        public decimal AlisFiyat { get; set; }

        [Display(Name = "Satış Fiyatı")]
        [DataType(DataType.Currency, ErrorMessage = "Geçersiz karakter.")]
        public decimal SatisFiyat { get; set; }
        public bool Durum { get; set; }

        [Display(Name = "Ürün Görseli")]
        [Column(TypeName = "varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }

        [Required(ErrorMessage = "Boş geçilmez!")]
        public int KategoriId { get; set; }
        public virtual Kategori Kategori { get; set; }
        public virtual ICollection<SatisHareket> SatisHarekets { get; set; }

        /*
        Bir kategori birden fazla üründe bulunabilecektir. Bu sebepten 
    Kategoriler tablosunda bir koleksiyon tutacağız, dolayısıyla 
    Urunler tablomuzda da bir tane Kategori olacağından Kategori 
    sınıfından bir Kategori tutacağız. Burada Kategori olarak 
    tuttuğumuz property SQL tarafında KategoriId tarzında bir 
    yapıya dönüşecektir.
     */
    }
}