using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        Context context = new Context();
        // GET: Personel
        public ActionResult Index()
        {
            var degerler = context.Personels.ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult PersonelEkle() 
        {
            List<SelectListItem> departmanlar = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.departmanlar = departmanlar;
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            List<SelectListItem> departmanlar = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.departmanList = departmanlar;
            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel_prm)
        {
            if (Request.Files.Count > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel_prm.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            }
            var personel_ctx = context.Personels.Find(personel_prm.PersonelId);
            personel_ctx.PersonelAd = personel_prm.PersonelAd;
            personel_ctx.PersonelSoyad = personel_prm.PersonelSoyad;
            personel_ctx.PersonelGorsel = personel_prm.PersonelGorsel;
            personel_ctx.DepartmanId = personel_prm.DepartmanId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelListe()
        {
            var personeller = context.Personels.ToList();
            return View(personeller);
        }
    }
}