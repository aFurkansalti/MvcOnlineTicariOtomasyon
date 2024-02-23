using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar.Model_Classes
{
    public class FaturaAndFaturaKalemModelClass
    {
        public IEnumerable<Faturalar> Faturalar { get ; set; }
        public IEnumerable<FaturaKalem> FaturaKalemler { get ; set; }
    }
}