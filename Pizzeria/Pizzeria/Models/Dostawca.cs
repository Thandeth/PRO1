using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Dostawca
    {
        public Dostawca()
        {
            ZamowienieDostawca = new HashSet<ZamowienieDostawca>();
        }

        public int IdDostawca { get; set; }
        public DateTime DataZatrudnienia { get; set; }
        public int IdPersona { get; set; }

        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<ZamowienieDostawca> ZamowienieDostawca { get; set; }
    }
}
