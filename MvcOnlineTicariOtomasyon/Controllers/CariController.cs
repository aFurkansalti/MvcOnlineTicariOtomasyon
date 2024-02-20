using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context context = new Context();                                                                                                                                                                                                
        public ActionResult Index()
        {
            List<Cariler> carilers = context.Cariler.Where(x => x.Durum == true).ToList();
            return View(carilers);
        }

        [HttpGet]
        public ActionResult YeniCari()
        {
            //ModelState.Remove("CariMail");
            //ModelState.Remove("CariSifre");
            return View();
        }

        [HttpPost]
        public ActionResult YeniCari(Cariler cariler)
        {
            if (!ModelState.IsValid)
            {
                return View("YeniCari");
            }

            var resimFile = cariler.MusteriResmi == null ? 0 : Request.Files.Count;

            if (resimFile > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                cariler.MusteriResmi= "/Image/" + dosyaadi + uzanti;
            }
            else
            {
                cariler.MusteriResmi = "/Image/user-front-side-with-white-background.jpg";
            }

            cariler.Durum = true;
            context.Cariler.Add(cariler);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CariSil(int id)
        {
            var cari = context.Cariler.Find(id);
            cari.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult CariGetir(int id)
        {
            var cari = context.Cariler.Find(id);
            return View("CariGetir", cari);
        }

        [HttpPost]
        public ActionResult CariGuncelle(Cariler cari_prm)
        {
            if (!ModelState.IsValid)
            {
                return View("CariGetir");
            }

            var cari_ctx = context.Cariler.Find(cari_prm.CariId);

            var resimFile = cari_prm.MusteriResmi == null ? 0 : Request.Files.Count;

            if (resimFile > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                cari_ctx.MusteriResmi = "/Image/" + dosyaadi + uzanti;
            }
            else if (resimFile == 0)
            {
                if (cari_ctx.MusteriResmi == null)
                {
                    cari_ctx.MusteriResmi = "/Image/user-front-side-with-white-background.jpg";
                }
            }
            

            cari_ctx.Durum = true;
            cari_ctx.CariAd = cari_prm.CariAd;
            cari_ctx.CariSoyad = cari_prm.CariSoyad;
            cari_ctx.CariSehir = cari_prm.CariSehir;
            cari_ctx.CariMail = cari_prm.CariMail;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult MusteriSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList();
            var cariIsimSoyisim = context.Cariler.Where(x => x.CariId == id).Select(x => x.CariAd + " " + x.CariSoyad).FirstOrDefault();
            ViewBag.cariIsimSoyisim = cariIsimSoyisim;
            return View(degerler);  
        }
    }
}