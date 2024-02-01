using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            var degerler = context.Cariler.FirstOrDefault(x => x.CariMail == mail);
            ViewBag.CariMail = mail;
            return View(degerler);
        }

        public ActionResult Siparislerim()
        {
            var mail = (string)Session["CariMail"];
            var id = context.Cariler.Where(x => x.CariMail == mail).Select(x => x.CariId).FirstOrDefault();
            var degerler = context.SatisHarekets.Where(x => x.CariId == id).ToList(); 
            return View(degerler);
        }    

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

        public ActionResult MesajDetay(int id)
        {
            var mesaj = context.Mesajlars.Where(x => x.MesajId == id).FirstOrDefault();
            return View(mesaj);
        }

        [HttpGet]
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
    }
}