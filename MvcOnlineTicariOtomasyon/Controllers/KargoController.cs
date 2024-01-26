using MvcOnlineTicariOtomasyon.Models.Siniflar;
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
        public ActionResult Index()
        {
            var kargolar = context.KargoDetays.ToList();
            return View(kargolar);
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
            return View();
        }

        [HttpPost]
        public ActionResult YeniKargo(KargoDetay kargoDetay)
        {
            context.KargoDetays.Add(kargoDetay);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}