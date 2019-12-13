using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class ZamowienieDostawca
    {
        public int IdDostawca { get; set; }
        public int IdZamowienie { get; set; }

        public virtual Dostawca IdDostawcaNavigation { get; set; }
        public virtual Zamowienie IdZamowienieNavigation { get; set; }
    }
}
