using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Skladniki
    {
        public Skladniki()
        {
            Rodzaj = new HashSet<Rodzaj>();
        }

        public int IdSkladniki { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<Rodzaj> Rodzaj { get; set; }
    }
}
