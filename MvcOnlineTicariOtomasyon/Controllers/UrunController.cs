﻿using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context context = new Context();
        public ActionResult Index()
        {
            var urunler = context.Uruns.Where(x => x.Durum == true).ToList();
            return View(urunler);
        }

        [HttpGet]
        public ActionResult YeniUrun()
        {
            this.dropdownListOfKategori();
            return View();
        }

        private void dropdownListOfKategori()
        {
            List<SelectListItem> kategoriList = (from x in context.Kategoris.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.KategoriAd,
                                                     Value = x.KategoriId.ToString(),
                                                 }).ToList();
            ViewBag.kategoriList = kategoriList;
        }

        [HttpPost]
        public ActionResult YeniUrun(Urun urun)
        {
            context.Uruns.Add(urun);
            context.SaveChanges();
            return RedirectToAction("Index");
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
            this.dropdownListOfKategori();
            return View("UrunGetir", urunDeger);
        }

        [HttpPost]
        public ActionResult UrunGuncelle(Urun urun_prm)
        {
            var urun_ctx = context.Uruns.Find(urun_prm.UrunId);
            urun_ctx.UrunAd = urun_prm.UrunAd;
            urun_ctx.Marka = urun_prm.Marka;
            urun_ctx.Stok = urun_prm.Stok;
            urun_ctx.AlisFiyat = urun_prm.AlisFiyat;
            urun_ctx.SatisFiyat = urun_prm.SatisFiyat;
            urun_ctx.Durum = urun_prm.Durum;
            urun_ctx.UrunGorsel = urun_prm.UrunGorsel;
            urun_ctx.KategoriId = urun_prm.KategoriId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult UrunListesi()
        {
            var degerler = context.Uruns.ToList();
            return View(degerler);
        }
    }
}