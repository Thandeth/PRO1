using System;
using System.Collections.Generic;

namespace Pizza_v1.Models
{
    public partial class Administrator
    {
        public int IdAdministrator { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Mail { get; set; }
    }
}
