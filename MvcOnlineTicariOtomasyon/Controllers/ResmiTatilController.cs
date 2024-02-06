using MvcOnlineTicariOtomasyon.Migrations;
using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class ResmiTatilController : Controller
    {
        // GET: ResmiTatil
        Context context = new Context();
        public ActionResult Index()
        {   
            var degerler = context.ResmiTatils.Where(x => x.Durum == true).ToList();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult TatilEkle()
        {
            DropdownListBag();
            return View();
        }

        [HttpPost]
        public ActionResult TatilEkle(ResmiTatil resmiTatil)
        {
            resmiTatil.Durum = true;
            resmiTatil.Sure = Convert.ToDouble(resmiTatil.Sure);
            var tarih = resmiTatil.Tarih.ToString();
            resmiTatil.Tarih = DateTime.Parse(resmiTatil.Tarih.ToShortDateString());
            context.ResmiTatils.Add(resmiTatil);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult TatilGetir(int id)
        {
            DropdownListBag();
            var tatil = context.ResmiTatils.Find(id);
            return View(tatil);
        }

        [HttpPost]
        public ActionResult TatilGuncelle(ResmiTatil resmiTatil_prm)
        {
            var resmiTatil_ctx = context.ResmiTatils.Find(resmiTatil_prm.Id);
            resmiTatil_ctx.GunIsim = resmiTatil_prm.GunIsim;
            resmiTatil_ctx.Sure = Convert.ToDouble(resmiTatil_prm.Sure);
            resmiTatil_ctx.Gun = resmiTatil_prm.Gun;
            resmiTatil_ctx.Tarih = DateTime.Parse(resmiTatil_prm.Tarih.ToShortDateString());
            resmiTatil_ctx.Durum = true;
            context.SaveChanges();
            return RedirectToAction("Index");   
        }

        public ActionResult TatilSil(int id)
        {
            var tatil = context.ResmiTatils.Find(id);
            tatil.Durum = false;
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public void DropdownListBag()
        {
            List<double> sureler = new List<double> { 0, 0.5, 1 };
            List<SelectListItem> surelerSelect = (from s in sureler
                                                  select new SelectListItem
                                                  {
                                                      Text = s.ToString(),
                                                      Value = s.ToString()
                                                  }).ToList();
            ViewBag.surelerSelectList = surelerSelect;

            List<string> gunler = new List<string>
            {
                "Gün Seçiniz", "Pazartesi", "Salı", "Çarşamba", "Perşembe", "Cuma", "Cumartesi", "Pazar"
            };
            List<SelectListItem> gunlerSelect = (from g in gunler
                                                 select new SelectListItem
                                                 {
                                                     Text = g.ToString(),
                                                     Value = g.ToString()
                                                 }).ToList();
            ViewBag.gunlersSelectList = gunlerSelect;
        }
    }
}