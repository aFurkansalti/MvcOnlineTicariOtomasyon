using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        Context context = new Context();
        // GET: Departman
        public ActionResult Index()
        {
            var degerler = context.Departmans.Where(x => x.Durum == true).ToList(); 
            return View(degerler);
        }

        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DepartmanEkle(Departman departman)
        {
            context.Departmans.Add(departman);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanSil(int id)
        {
            var departman = context.Departmans.Find(id);
            departman.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanGetir(int id)
        {
            var departman = context.Departmans.Find(id);
            return View("DepartmanGetir", departman);
        }

        [HttpPost]
        public ActionResult DepartmanGuncelle(Departman prm_departman)
        {
            var ctx_departman = context.Departmans.Find(prm_departman.DepartmanId);
            ctx_departman.DepartmanAd = prm_departman.DepartmanAd;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmanDetay(int id)
        {
            List<Personel> degerler = context.Personels.Where(x => x.DepartmanId == id).ToList();
            string departmanName = context.Departmans.Where(x => x.DepartmanId == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.departmanName = departmanName.ToUpper();
            return View(degerler);
        }

        public ActionResult DepartmanPersonelSatis(int id)
        {
            var degerler = context.SatisHarekets.Where(x => x.PersonelId == id).ToList();
            var personel = context.Personels.Where(x => x.PersonelId == id).Select(y => y.PersonelAd + " " + y.PersonelSoyad).FirstOrDefault();
            ViewBag.personel = personel;
            return View(degerler);
        }
    }
}