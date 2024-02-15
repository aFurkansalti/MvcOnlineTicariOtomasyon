using FluentValidation.Results;
using MvcOnlineTicariOtomasyon.Migrations;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.ValidationRules;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context context = new Context();
        public ActionResult Index(string prm_urunAd, int sayfa = 1)
        {
            // context.Uruns.Where(x => x.Durum == true).ToList()
            var urunler = from x in context.Uruns select x;
            if (!string.IsNullOrEmpty(prm_urunAd))
            {
                urunler = urunler.Where(urun => urun.UrunAd.Contains(prm_urunAd) && urun.Durum == true);
            } else {
                urunler = urunler.Where(urun => urun.Durum == true);
            }
            return View(urunler.ToList().ToPagedList(sayfa, 4));
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            this.DropdownListOfKategori();
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            //UrunValidator urunValidator = new UrunValidator();
            //ValidationResult result = urunValidator.Validate(urun);

            //if (result.IsValid)
            //{
            //    urun.Durum = true;
            //    context.Uruns.Add(urun);
            //    context.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            //else
            //{
            //    foreach (var item in result.Errors)
            //    {
            //        ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
            //    }
            //}

            if (!ModelState.IsValid)
            {
                this.DropdownListOfKategori();
                return View("YeniUrun");
            }

            //var resimFile = Request.Files.Count;
            var resimFile = urun.UrunGorsel == null ? 0 : Request.Files.Count;

            if (resimFile > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun.UrunGorsel = "/Image/" + dosyaadi + uzanti;
            }

            urun.Durum = true;
            context.Uruns.Add(urun);
            context.SaveChanges();

            return RedirectToAction("Index");
        }

        private void DropdownListOfKategori()
        {
            List<SelectListItem> kategoriList = (from x in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriId.ToString(),
                                                 }).ToList();
            ViewBag.kategoriList = kategoriList;
        }

        public ActionResult UrunSil(int id)
        {
            var deger = context.Uruns.Find(id);
            deger.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {
            var urunDeger = context.Uruns.Find(id);
            this.DropdownListOfKategori();
            return View("UrunGetir", urunDeger);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun_prm)
        {
            //if (!ModelState.IsValid)
            //{
            //    this.DropdownListOfKategori();
            //    //return View("UrunGetir");
            //    return View(UrunGetir(urun_prm.UrunId));
            //}

            if (!ModelState.IsValid)
            {
                this.DropdownListOfKategori();

                // Hataları model state'e ekleyerek gönder
                var errorList = ModelState.Values.SelectMany(v => v.Errors).ToList();

                foreach (var error in errorList)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                // UrunGetir'e geri dön
                return View("UrunGetir", urun_prm);
            }

            var urun_ctx = context.Uruns.Find(urun_prm.UrunId);
            urun_ctx.UrunAd = urun_prm.UrunAd;
            urun_ctx.Marka = urun_prm.Marka;
            urun_ctx.Stok = urun_prm.Stok;
            urun_ctx.AlisFiyat = urun_prm.AlisFiyat;
            urun_ctx.SatisFiyat = urun_prm.SatisFiyat;

            var resimFile = urun_prm.UrunGorsel == null ? 0 : Request.Files.Count;
            if (resimFile > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                urun_ctx.UrunGorsel = "/Image/" + dosyaadi + uzanti;
            }

            urun_ctx.KategoriId = urun_prm.KategoriId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);
        }

        public ActionResult SatisYap(int id)
        {
            List<SelectListItem> personeller = (from p in context.Personels.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.PersonelAd + " " + p.PersonelSoyad,
                                                    Value = p.PersonelId.ToString()
                                                }).ToList();
            ViewBag.personellerSatis = personeller;
            var urun = context.Uruns.Find(id);
            ViewBag.urunId = urun.UrunId;    
            ViewBag.urunSatisFiyat = urun.SatisFiyat;
            return View();
        }

        [HttpPost]
        public ActionResult SatisYap(SatisHareket satisHareket)
        {
            satisHareket.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.SatisHarekets.Add(satisHareket);
            context.SaveChanges();
            return RedirectToAction("Index", "Satis");
        } 
    }
}