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
            this.DropdownListOfDepartman();
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(Personel personel)
        {
            if (!ModelState.IsValid)
            {
                this.DropdownListOfDepartman();
                return View("PersonelEkle");
            }

            var resimFileCount = personel.PersonelGorsel == null ? 0 : Request.Files.Count;
            if (resimFileCount > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            } else {
                personel.PersonelGorsel = "/Image/user-front-side-with-white-background.jpg";
            }
            context.Personels.Add(personel);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            this.DropdownListOfDepartman();
            var personel = context.Personels.Find(id);
            return View("PersonelGetir", personel);
        }

        [HttpPost]
        public ActionResult PersonelGuncelle(Personel personel_prm)
        {
            if (!ModelState.IsValid)
            {
                this.DropdownListOfDepartman();

                // Hataları model state'e ekleyerek gönder
                var errorList = ModelState.Values.SelectMany(v => v.Errors).ToList();

                foreach (var error in errorList)
                {
                    ModelState.AddModelError("", error.ErrorMessage);
                }

                // UrunGetir'e geri dön
                return View("UrunGetir", personel_prm);
            }

            var personel_ctx = context.Personels.Find(personel_prm.PersonelId);
            var resimFileCount = personel_prm.PersonelGorsel == null ? 0 : Request.Files.Count;
            if (resimFileCount > 0)
            {
                string dosyaadi = Path.GetFileName(Request.Files[0].FileName);
                string uzanti = Path.GetExtension(Request.Files[0].FileName);
                string yol = "~/Image/" + dosyaadi + uzanti;
                Request.Files[0].SaveAs(Server.MapPath(yol));
                personel_ctx.PersonelGorsel = "/Image/" + dosyaadi + uzanti;
            } else {
                personel_ctx.PersonelGorsel = "/Image/user-front-side-with-white-background.jpg";
            }
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

        private void DropdownListOfDepartman()
        {
            List<SelectListItem> departmanlar = (from x in context.Departmans.ToList()
                                                 select new SelectListItem
                                                 {
                                                     Text = x.DepartmanAd,
                                                     Value = x.DepartmanId.ToString()
                                                 }).ToList();
            ViewBag.departmanlar = departmanlar;
        }
    }
}