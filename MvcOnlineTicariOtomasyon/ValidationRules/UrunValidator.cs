using FluentValidation;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.ValidationRules
{
    public class UrunValidator: AbstractValidator<Urun>
    {
        public UrunValidator() 
        {
            RuleFor(x => x.UrunAd).NotEmpty().WithMessage("Lütfen boş bırakmayınız.");
            RuleFor(x => x.UrunAd).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapınız!");

            RuleFor(x => x.Marka).MaximumLength(30).WithMessage("Lütfen en fazla 30 karakter girişi yapınız!");

            RuleFor(x => x.Stok).Must(stok => stok < 32767).WithMessage("Stok miktarı 100'den küçük olmalıdır!");
            RuleFor(x => x.Stok).Must(stok => stok > 0).WithMessage("Stok sayısı negatif olmamalıdır!");

            RuleFor(fiyat => fiyat.AlisFiyat).NotEmpty().WithMessage("Fiyat boş olamaz.");
            RuleFor(x => x.AlisFiyat).Must(alisFiyat => IsValidFiyat(alisFiyat)).WithMessage("Geçersiz fiyat formatı.");
            RuleFor(x => x.AlisFiyat).Must(alisFiyat => alisFiyat > 0).WithMessage("Alış fiyatı negatif olmamalıdır.");
        }

        private bool IsValidFiyat(decimal fiyat)
        {
            // Fiyatın sadece sayı, nokta veya virgül içermesi kontrol ediliyor.
            string fiyatStr = fiyat.ToString();
            return System.Text.RegularExpressions.Regex.IsMatch(fiyatStr, @"^[0-9]+([.,][0-9]{1,2})?$");
        }
    }
}