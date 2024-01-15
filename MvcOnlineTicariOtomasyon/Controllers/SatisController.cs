using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        Context context = new Context();
        // GET: Satis
        public ActionResult Index()
        {
            var degerler = context.SatisHarekets.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatis()
        {
            DropdownListItems();
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatis(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString()); 
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisGetir(int id)
        {
            DropdownListItems();
            var satis = context.SatisHarekets.Find(id);
            return View("SatisGetir", satis);
        }

        public ActionResult SatisGuncelle(SatisHareket satisHareket_prm)
        {
            var satisHareket_ctx = context.SatisHarekets.Find(satisHareket_prm.SatisId);
            satisHareket_ctx.Adet = satisHareket_prm.Adet;
            satisHareket_ctx.Fiyat = satisHareket_prm.Fiyat;
            satisHareket_ctx.ToplamTutar = satisHareket_prm.ToplamTutar;
            satisHareket_ctx.CariId = satisHareket_prm.CariId;
            satisHareket_ctx.PersonelId = satisHareket_prm.PersonelId;
            satisHareket_ctx.UrunId = satisHareket_prm.UrunId;
            satisHareket_ctx.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult SatisDetay(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.SatisId == id).ToList();
            return View(degerler);
        }

        private void DropdownListItems()
        {
            List<SelectListItem> cariler = (from c in context.Cariler.ToList()
                                            select new SelectListItem
                                            {
                                                Text = c.CariAd + " " + c.CariSoyad,
                                                Value = c.CariId.ToString()
                                            }).ToList();
            ViewBag.carilerSatis = cariler;

            List<SelectListItem> personeller = (from p in context.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.PersonelAd + " " + p.PersonelSoyad,
                                                    Value = p.PersonelId.ToString()
                                                }).ToList();
            ViewBag.personellerSatis = personeller;

            List<SelectListItem> urunler = (from u in context.Uruns.ToList()
                                            select new SelectListItem
                                            {
                                                Text = u.UrunAd,
                                                Value = u.UrunId.ToString()
                                            }).ToList();
            ViewBag.urunlerSatis = urunler;
        }
    }
}