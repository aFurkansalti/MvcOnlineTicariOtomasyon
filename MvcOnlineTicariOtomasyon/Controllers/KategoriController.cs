using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar.Model_Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KategoriController : Controller
    {
        // GET: Kategori
        public ActionResult Index(int sayfa = 1)
        {
            using (Context context = new Context())
            {
                var degerler = context.Kategoris.Where(x => x.Durum == true).ToList().ToPagedList(sayfa, 4);
                return View(degerler);
            }
        }

        [HttpGet]
        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(Kategori kategori)
        {
            using (Context context = new Context())
            {
                kategori.Durum = true;
                context.Kategoris.Add(kategori);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult KategoriSil(int id)
        {
            using (Context context = new Context())
            {
                //Kategori kategori = context.Kategoris.Find(id);
                //context.Kategoris.Remove(kategori);
                context.Kategoris.Find(id).Durum = false;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult KategoriGetir(int id)
        {
            using (Context context = new Context())
            {
                var kategori = context.Kategoris.Find(id);
                return View("KategoriGetir", kategori);
            }
        }

        [HttpPost]
        public ActionResult KategoriGuncelle(Kategori kategori)
        {
            using (Context context = new Context())
            {
                var bulunanKategori = context.Kategoris.Find(kategori.KategoriId);
                bulunanKategori.KategoriAd = kategori.KategoriAd;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        Context context = new Context();
        public ActionResult KategoriyeGoreUrunler()
        {
            KategeoriyeGoreUrunModelClass modelClass = new KategeoriyeGoreUrunModelClass();
            modelClass.Kategoriler = new SelectList(context.Kategoris, "KategoriId", "KategoriAd");
            modelClass.Urunler = new SelectList(context.Uruns, "UrunId", "UrunAd"); 
            return View(modelClass);
        }

        [HttpPost]
        public JsonResult UrunGetir(int katId)
        {
            var urunListesi = (from x in context.Uruns
                               join y in context.Kategoris
                               on x.Kategori.KategoriId equals y.KategoriId
                               where x.Kategori.KategoriId == katId
                               select new
                               {
                                    Text = x.UrunAd,
                                    Value = x.UrunId.ToString()
                               }).ToList();

            return Json(urunListesi, JsonRequestBehavior.DenyGet); 
        }
    }
}