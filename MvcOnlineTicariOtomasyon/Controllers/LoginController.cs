using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        Context context = new Context();
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult CariKayıtPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CariKayıtPartial(Cariler cariler)
        {
            context.Cariler.Add(cariler);
            context.SaveChanges();
            return View("Index", "Login");
        }

        [HttpGet]
        public PartialViewResult CariGirisPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult CariGirisPartial(Cariler cariler)
        {
            var bilgiler = context.Cariler.FirstOrDefault(x => x.CariMail == cariler.CariMail && x.CariSifre == cariler.CariSifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.CariMail, false);
                Session["CariMail"] = bilgiler.CariMail.ToString();
                return RedirectToAction("Index", "CariPanel");   
            } 
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }

        [HttpGet]
        public PartialViewResult AdminLogin()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var bilgiler = context.Admins.FirstOrDefault(x => x.KullaniciAd == admin.KullaniciAd && x.Sifre == admin.Sifre);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.KullaniciAd, false);
                Session["KullaniciAd"] = bilgiler.KullaniciAd.ToString();
                return RedirectToAction("Index", "Kategori");
            }
            else
            {
                return RedirectToAction("Index", "Login");  
            }
        }
    }
}