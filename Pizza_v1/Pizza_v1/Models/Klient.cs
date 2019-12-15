using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Klient
    {
        public Klient()
        {
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdKlient { get; set; }
        public string NumerTelefonu { get; set; }
        public string Mail { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
