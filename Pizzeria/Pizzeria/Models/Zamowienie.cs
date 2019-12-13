using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            Szczegoly = new HashSet<Szczegoly>();
            ZamowienieDostawca = new HashSet<ZamowienieDostawca>();
        }

        public int IdZamowienie { get; set; }
        public DateTime DataZamowienia { get; set; }
        public string Platnosc { get; set; }
        public decimal Cena { get; set; }
        public int AdresIdAdres { get; set; }
        public int KlientIdKlient { get; set; }
        public string Uwagi { get; set; }

        public virtual Adres AdresIdAdresNavigation { get; set; }
        public virtual Klient KlientIdKlientNavigation { get; set; }
        public virtual ICollection<Szczegoly> Szczegoly { get; set; }
        public virtual ICollection<ZamowienieDostawca> ZamowienieDostawca { get; set; }
    }
}
