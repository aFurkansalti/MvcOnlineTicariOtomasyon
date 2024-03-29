﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar
{
    public class Kategori
    {
        [Key]
        [Display(Name = "Kategori")]
        public int KategoriId { get; set; }

        [Display(Name = "Kategori Adı")]
        [Column(TypeName = "varchar")]
        [StringLength(30)]
        public string KategoriAd { get; set; }
        public bool Durum { get; set; }
        public virtual ICollection<Urun> Uruns { get; set; }

            /*
            Bir kategori birden fazla üründe bulunabilecektir. Bu sebepten 
        Kategoriler tablosunda bir koleksiyon tutacağız, dolayısıyla
        Urunler tablomuzda da bir tane Kategori olacağından Kategori 
        sınıfından bir Kategori tutacağız.
         */
    }
}