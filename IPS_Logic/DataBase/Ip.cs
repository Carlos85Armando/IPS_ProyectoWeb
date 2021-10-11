using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class Ip
    {
        public int Id { get; set; }
        public string NombreIps { get; set; }
        public int IdSede { get; set; }

        public virtual Sede IdSedeNavigation { get; set; }
    }
}
