using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcOnlineTicariOtomasyon.Models.Siniflar.Property
{
    public class Saat
    {
        [Column(TypeName = "time(7)")]
        public TimeSpan Zaman { get; set; }
    }
}