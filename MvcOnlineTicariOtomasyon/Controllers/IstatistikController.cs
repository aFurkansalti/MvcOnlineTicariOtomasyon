using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.Models.Siniflar.Group_By;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class IstatistikController : Controller
    {
        Context context = new Context();
        // GET: Istatistik
        public ActionResult Index()
        {
            var cariSayisi = context.Cariler.Count().ToString();
            ViewBag.d1 = cariSayisi;
            var urunSayisi = context.Uruns.Count().ToString();
            ViewBag.d2 = urunSayisi;
            var personelSayisi = context.Personels.Count().ToString();
            ViewBag.d3 = personelSayisi;
            var kategoriSayisi = context.Kategoris.Count().ToString();
            ViewBag.d4 = kategoriSayisi;
            var stokSayisi = context.Uruns.Sum(x => x.Stok).ToString();
            ViewBag.d5 = stokSayisi;
            var markaSayisi = (from x in context.Uruns select x.Marka).Distinct().Count().ToString();
            ViewBag.d6 = markaSayisi;
            var stokSayisiMax20 = context.Uruns.Count(x => x.Stok <= 20).ToString();
            ViewBag.d7 = stokSayisiMax20;
            var maxFiyatliUrun = (from x in context.Uruns orderby x.SatisFiyat descending select x.UrunAd).FirstOrDefault();
            ViewBag.d8 = maxFiyatliUrun;
            var minFiyatliUrun = (from x in context.Uruns orderby x.SatisFiyat ascending select x.UrunAd).FirstOrDefault();
            ViewBag.d9 = minFiyatliUrun;
            var buzdolabiSayisi = context.Uruns.Count(x => x.UrunAd == "Buzdolabı").ToString();
            ViewBag.d10 = buzdolabiSayisi;
            var laptopSayisi = context.Uruns.Count(x => x.UrunAd == "Laptop").ToString();
            ViewBag.d11 = laptopSayisi;
            var maxMarka = context.Uruns.GroupBy(x => x.Marka).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault();
            ViewBag.d12 = maxMarka;
            var maxSatis = context.Uruns.Where(t => t.UrunId == (context.SatisHarekets.GroupBy(x => x.UrunId).OrderByDescending(y => y.Count()).Select(z => z.Key).FirstOrDefault())).Select(u => u.UrunAd).FirstOrDefault();
            ViewBag.d13 = maxSatis; 
            var toplamTutar = context.SatisHarekets.Sum(x => x.ToplamTutar).ToString();
            ViewBag.d14 = toplamTutar;
            DateTime bugun = DateTime.Today;
            var bugunSatis = context.SatisHarekets.Count(x => x.Tarih == bugun).ToString();
            ViewBag.d15 = bugunSatis;
            var bugunSatisTutar = context.SatisHarekets.Where(x => x.Tarih == bugun) != null ? context.SatisHarekets.Where(x => x.Tarih == bugun).Sum(y => y.ToplamTutar * y.Adet).ToString() : "0";
            ViewBag.d16 = bugunSatisTutar;
            return View();
        }

        public ActionResult BasitTablolar()
        {
            var numofCaribySehir = (from x in context.Cariler
                                   group x by x.CariSehir into g
                                   select new SinifGroupCaribyCarisehir
                                   {
                                       Sehir = g.Key,
                                       Sayi = g.Count()
                                   }).ToList();
            return View(numofCaribySehir);
        }

        public PartialViewResult PersonelDepartmanPartial()
        {
            var numofPersonelbyDepartman = (from x in context.Personels
                                            group x by x.Departman.DepartmanAd into g
                                            select new SinifGroupPersonelbyDepartman
                                            {
                                                Departman = g.Key,
                                                Sayi = g.Count()
                                            }).ToList();
            return PartialView(numofPersonelbyDepartman);
        }

        public PartialViewResult CarilerPartial()
        {
            var cariler = context.Cariler.Where(x => x.Durum == true).ToList();
            return PartialView(cariler);
        }

        public PartialViewResult UrunlerPartial()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return PartialView(urunler);
        }

        public PartialViewResult UrunMarkaPartial()
        {
            var numofUrunbyMarka = (from x in context.Uruns
                                    group x by x.Marka into g
                                    select new SinifGroupUrunbyMarka
                                    {
                                        Marka = g.Key,
                                        Sayi = g.Count()
                                    }).ToList();
            return PartialView(numofUrunbyMarka);
        }
    }
}