using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            Rodzaj = new HashSet<Rodzaj>();
            Szczegoly = new HashSet<Szczegoly>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Rodzaj> Rodzaj { get; set; }
        public virtual ICollection<Szczegoly> Szczegoly { get; set; }
    }
}
