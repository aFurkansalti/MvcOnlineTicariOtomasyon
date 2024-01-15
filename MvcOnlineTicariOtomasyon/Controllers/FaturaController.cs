using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class FaturaController : Controller
    {
        Context context = new Context();
        // GET: Fatura
        public ActionResult Index()
        {
            var degerler = context.Faturalars.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult FaturaEkle()
        {
            DropdownListTeslim();
            return View();
        }

        [HttpPost]
        public ActionResult FaturaEkle(Faturalar fatura)
        {
            context.Faturalars.Add(fatura); 
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaGetir(int id)
        {
            var fatura = context.Faturalars.Find(id);
            DropdownListTeslim();
            return View("FaturaGetir", fatura);
        }

        public ActionResult FaturaGuncelle(Faturalar fatura_prm)
        {
            var fatura_ctx = context.Faturalars.Find(fatura_prm.FaturaId);
            fatura_ctx.FaturaSeriNo = fatura_prm.FaturaSeriNo;
            fatura_ctx.FaturaSiraNo = fatura_prm.FaturaSiraNo;
            fatura_ctx.Tarih = fatura_prm.Tarih;
            fatura_ctx.VergiDairesi = fatura_prm.VergiDairesi;
            fatura_ctx.Saat = fatura_prm.Saat;
            fatura_ctx.TeslimEden = fatura_prm.TeslimEden;
            fatura_ctx.TeslimAalan = fatura_prm .TeslimAalan;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult FaturaDetay(int id)
        {
            var degerler = context.FaturaKalems.Where(x => x.FaturaId == id).ToList();

            var faturaSeriNo = context.Faturalars.Where(x => x.FaturaId == id).Select(x => x.FaturaSeriNo).FirstOrDefault();
            ViewBag.faturaSeriNo = faturaSeriNo;

            var faturaSiraNo = context.Faturalars.Where(x => x.FaturaId == id).Select(x => x.FaturaSiraNo).FirstOrDefault();
            ViewBag.faturaSiraNo = faturaSiraNo;

            ViewBag.faturaId = id;

            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniKalem(int id)
        {
            ViewBag.faturaId = id;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKalem(FaturaKalem faturaKalem)
        {
            faturaKalem.Tutar = faturaKalem.Miktar * faturaKalem.BirimFiyat;

            context.FaturaKalems.Add(faturaKalem);
            context.SaveChanges();
            return RedirectToAction("Index");    
        }

        private void DropdownListTeslim()
        {
            List<SelectListItem> teslimEdenler = (from x in context.Personels.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = String.Format("{0} {1}", x.PersonelAd, x.PersonelSoyad),
                                                      Value = String.Format("{0} {1}", x.PersonelAd, x.PersonelSoyad)
                                                  }).ToList();
            ViewBag.teslimEdenler = teslimEdenler;

            List<SelectListItem> teslimAlanlar = (from x in context.Cariler.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = String.Format("{0} {1}", x.CariAd, x.CariSoyad),
                                                      Value = String.Format("{0} {1}", x.CariAd, x.CariSoyad)
                                                  }).ToList();
            ViewBag.teslimAlanlar = teslimAlanlar;
        }
    }
}