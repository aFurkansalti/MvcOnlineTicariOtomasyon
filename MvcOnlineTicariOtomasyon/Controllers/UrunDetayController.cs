using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using MvcOnlineTicariOtomasyon.Models.Siniflar.Model_Classes;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunDetayController : Controller
    {
        Context context = new Context();
        // GET: UrunDetay
        public ActionResult Index()
        {
            //var degerler = context.Uruns.Where(x => x.UrunId == 1).ToList();
            DetayModelClass detayModelClass = new DetayModelClass();
            detayModelClass.UrunModel = context.Uruns.Where(x => x.UrunId == 1).ToList();   
            detayModelClass.DetayModel = context.Detays.Where(x => x.DetayId == 1).ToList();    
            return View(detayModelClass);
        }
    }
}