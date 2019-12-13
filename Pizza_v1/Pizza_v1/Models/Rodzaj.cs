using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Rodzaj
    {
        public int IdRodzaj { get; set; }
        public int Ilosc { get; set; }
        public int IdSkladniki { get; set; }
        public int IdPizza { get; set; }

        public virtual Pizza IdPizzaNavigation { get; set; }
        public virtual Skladniki IdSkladnikiNavigation { get; set; }
    }
}
