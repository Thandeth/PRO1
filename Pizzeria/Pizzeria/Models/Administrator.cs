using System;
using System.Collections.Generic;

namespace Pizzeria.Models
{
    public partial class Administrator
    {
        public int IdAdministrator { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
