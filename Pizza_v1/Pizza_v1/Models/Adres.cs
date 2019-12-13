using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Adres
    {
        public Adres()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdAdres { get; set; }
        public string Miasto { get; set; }
        public string Ulica { get; set; }
        public int NrDomu { get; set; }
        public int? NrMieszkania { get; set; }

        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
