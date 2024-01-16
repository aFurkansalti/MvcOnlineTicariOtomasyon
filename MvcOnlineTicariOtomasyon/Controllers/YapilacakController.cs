using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class YapilacakController : Controller
    {
        Context context = new Context();
        // GET: Yapilacak
        public ActionResult Index()
        {
            ViewBag.CariSayisi = context.Cariler.Count().ToString();
            ViewBag.UrunSayisi = context.Uruns.Count().ToString();    
            ViewBag.KategoriSayisi = context.Kategoris.Count().ToString();
            ViewBag.SehirSayisi = (from x in context.Cariler select x.CariSehir).Distinct().Count().ToString();
            var toDo = context.Yapilacaks.ToList();
            return View(toDo);
        }
    }
}