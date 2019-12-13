using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Persona
    {
        public Persona()
        {
            Dostawca = new HashSet<Dostawca>();
            Klient = new HashSet<Klient>();
        }

        public int IdPersona { get; set; }
        public string Imie { get; set; }
        public string Nazwisko { get; set; }

        public virtual ICollection<Dostawca> Dostawca { get; set; }
        public virtual ICollection<Klient> Klient { get; set; }
    }
}
