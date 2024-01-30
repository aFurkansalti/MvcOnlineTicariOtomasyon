using MvcOnlineTicariOtomasyon.Models.Siniflar;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.UI;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class GrafikController : Controller
    {
        // GET: Grafik
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var grafikciz = new Chart(600, 600);
            grafikciz.AddTitle("Kategori - Ürün Stok Sayısı").AddLegend("Stok").AddSeries(
                    "Değerler",
                    xValue: new[] { "Mobilya", "Ofis Eşyaları", "Bilgisayar" },
                    yValues: new[] { 85, 45, 98 }
                ).Write();
            return File(grafikciz.ToWebImage().GetBytes(), "image,jpeg");
        }

        Context context = new Context();
        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var sonuclar = context.Uruns.ToList();
            sonuclar.ToList().ForEach(x => xvalue.Add(x.UrunAd));
            sonuclar.ToList().ForEach(y => yvalue.Add(y.Stok));
            var grafik = new Chart(width: 500, height: 500)
                .AddTitle("Stoklar")
                .AddSeries(
                        chartType: "Column",
                        name: "Stok",
                        xValue: xvalue,
                        yValues: yvalue
                    );
            return File(grafik.ToWebImage().GetBytes(), "image, jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }

        [HttpPost]
        public ActionResult VizualizeUrunResult() 
        {
            return Json(UrunListesi(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif1> UrunListesi()
        {
            List<Sinif1> sinif = new List<Sinif1>();
            sinif.Add(new Sinif1()
            {
                urunad = "Bilgisayar",
                stok = 110
            });
            sinif.Add(new Sinif1()
            {
                urunad = "Beyaz Eşya",
                stok = 70
            });
            sinif.Add(new Sinif1()
            {
                urunad = "Mobilya",
                stok = 90
            });
            sinif.Add(new Sinif1()
            {
                urunad = "Küçük Ev Aletleri",
                stok = 180
            });
            sinif.Add(new Sinif1()
            {
                urunad = "Mobil Cihazlar",
                stok = 80
            });

            return sinif;
        }

        public ActionResult Index5()
        {
            return View();
        }

        public ActionResult VizualizeUrunResult2()
        {
            return Json(UrunListesi2(), JsonRequestBehavior.AllowGet);
        }

        public List<Sinif2> UrunListesi2()
        {
            List<Sinif2> sinif = new List<Sinif2>();
            using (var context = new Context())
            {
                sinif = context.Uruns.Select(x => new Sinif2
                {
                    urn = x.UrunAd,
                    stk = x.Stok
                }).ToList();
            }
            return sinif;
        }

        public ActionResult Index6()
        {
            return View();
        }

        public ActionResult Index7()
        {
            return View();
        }
    }
}