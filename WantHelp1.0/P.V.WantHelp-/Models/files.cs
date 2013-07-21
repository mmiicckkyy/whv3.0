using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace P.V.WantHelp_.Models
{
    public class files
    {
        public int id { get; set; }
        public int idUs { get; set; }
        public string urlAbs { get; set; }
        public string urlWeb { get; set; }

        public virtual Usuario usuario { get; set; }
    }
}