using MvcOnlineTicariOtomasyon.Models.Siniflar;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class KargoController : Controller
    {
        // GET: Kargo
        Context context = new Context();
        public ActionResult Index(string prm_kargoTakipKod)
        {
            var kargoDetaylar = from x in context.KargoDetays select x;
            if (!string.IsNullOrEmpty(prm_kargoTakipKod))
            {
                //kargoDetaylar = kargoDetaylar.Where(kargoDetay => kargoDetay.TakipKodu == prm_kargoTakipKod.TrimEnd().TrimStart());
                kargoDetaylar = kargoDetaylar.Where(kargoDetay => kargoDetay.TakipKodu.Contains(prm_kargoTakipKod.TrimEnd().TrimStart()));
            }
            
            return View(kargoDetaylar.ToList());
        }

        [HttpGet]
        public ActionResult YeniKargo()
        {
            Random random = new Random();
            string[] karakterler = { "A", "B", "C", "D" };
            int k1, k2, k3;
            k1 = random.Next(0, 4);
            k2 = random.Next(0, 4);
            k3 = random.Next(0, 4);
            int s1, s2, s3;
            s1 = random.Next(100, 1000);
            s2 = random.Next(10, 99);
            s3 = random.Next(10, 99);
            string kod = s1.ToString() + karakterler[k1] + s2.ToString() + karakterler[k2] + s3.ToString() + karakterler[k3];
            ViewBag.takipKod = kod;
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargoDetay)
        {
            if (!ModelState.IsValid)
            {
                return View("Index");
            }
            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KargoTakip(string id)
        {
            var degerler = context.KargoTakips.Where(takip => takip.TakipKodu == id).ToList();
            return View(degerler);
        }
    }
}