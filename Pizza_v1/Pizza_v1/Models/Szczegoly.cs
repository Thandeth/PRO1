using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Szczegoly
    {
        public int IdPizza { get; set; }
        public int IdZamowienie { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
