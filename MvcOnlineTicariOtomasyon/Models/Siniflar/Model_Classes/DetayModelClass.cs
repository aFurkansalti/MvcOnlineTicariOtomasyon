﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar.Model_Classes
{
    public class DetayModelClass
    {
        public IEnumerable<Urun> UrunModel { get; set; }
        public IEnumerable<Detay> DetayModel { get; set;}
    }
}