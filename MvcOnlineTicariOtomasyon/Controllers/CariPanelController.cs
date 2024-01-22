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
    }
}