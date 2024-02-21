using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariPanelController : Controller
    {
        // GET: CariPanel
        Context context = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CariMail"];
            ViewBag.CariMail = mail;
            var adSoyad = context.Cariler.Where(x => x.CariMail == mail).Select(y => y.CariAd + " " + y.CariSoyad).FirstOrDefault();
            ViewBag.CariAdSoyad = adSoyad;
            var cariSehir = context.Cariler.Where(x => x.CariMail == mail).Select(y => y.CariSehir).FirstOrDefault();
            ViewBag.CariSehir = cariSehir;
            var cariIdByMail = context.Cariler.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            ViewBag.CariId = cariIdByMail;
            var toplamSatis = context.SatisHarekets.Where(x => x.CariId == cariIdByMail).Count();
            ViewBag.ToplamSatis = toplamSatis;
            var toplamTutar = context.SatisHarekets.Where(x => x.CariId == cariIdByMail).Sum(y => y.ToplamTutar);
            ViewBag.ToplamTutar = toplamTutar;
            decimal? toplamAdet = context.SatisHarekets.Where(x => x.CariId == cariIdByMail).Sum(y => y.Adet);
            ViewBag.ToplamAdet = toplamAdet;
            var resim = context.Cariler.Where(x => x.CariMail == mail).Select(y => y.MusteriResmi).FirstOrDefault();
            ViewBag.Resim = resim;
            var degerler = context.Mesajlars.Where(x => x.Alici == mail).ToList();
            return View(degerler);
        }

        [Authorize]
        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = context.Cariler.Where(x => x.CariMail == mail).Select(x => x.CariId).FirstOrDefault();
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList(); 
            return View(degerler);
        }

        [Authorize]
        public ActionResult GelenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Alici == mail).OrderByDescending(t => t.Tarih).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var mail = (string)Session["CariMail"];
            var mesajlar = context.Mesajlars.Where(x => x.Gonderici == mail).OrderByDescending(t => t.Tarih).ToList();
            return View(mesajlar);
        }

        [Authorize]
        public ActionResult MesajDetay(int id)
        {
            var mesaj = context.Mesajlars.Where(x => x.MesajId == id).FirstOrDefault();
            return View(mesaj);
        }
       
        [HttpGet]
        [Authorize]
        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(Mesajlar mesajlar)
        {
            var mail = (string)Session["CariMail"];
            mesajlar.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            mesajlar.Gonderici = mail;
            context.Mesajlars.Add(mesajlar);
            context.SaveChanges();
            return View();
        }

        public PartialViewResult MessageMenuPartial()
        {
            this.MesajSayilari();
            return PartialView();
        }

        private void MesajSayilari()
        {
            var mail = (string)Session["CariMail"];
            var gelenSayisi = context.Mesajlars.Count(x => x.Alici == mail).ToString();
            ViewBag.gelenSayisi = gelenSayisi;
            var gidenSayisi = context.Mesajlars.Count(x => x.Gonderici == mail).ToString();
            ViewBag.gidenSayisi = gidenSayisi;
        }

        public ActionResult KargoTakip(string prm_kargoTakipKod)
        {
            var kargoDetaylar = from x in context.KargoDetays select x;
            kargoDetaylar = kargoDetaylar.Where(x => x.TakipKodu.Contains(prm_kargoTakipKod.TrimEnd().TrimStart()));
            return View(kargoDetaylar.ToList());
        }

        public ActionResult CariKargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(takip => takip.TakipKodu == id).ToList();
            ViewBag.KargoTakipKodu = id;
            return View(degerler);
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }

        public PartialViewResult SettingsPartial()
        {
            var mail = (string)Session["CariMail"];
            var cariId = context.Cariler.Where(x => x.CariMail == mail).Select(y => y.CariId).FirstOrDefault();
            var cari = context.Cariler.Find(cariId);
            return PartialView("SettingsPartial", cari);
        }

        [HttpPost]
        public ActionResult CariBilgiGuncelle(Cariler cari_prm)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
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

        public PartialViewResult DuyurularPartial()
        {
            var veriler = context.Mesajlars.Where(x => x.Gonderici == "admin").ToList();
            return PartialView("DuyurularPartial", veriler);
        }
    }
}