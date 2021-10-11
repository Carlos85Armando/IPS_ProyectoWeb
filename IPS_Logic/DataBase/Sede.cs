using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class Sede
    {
        public Sede()
        {
            CitaMedicas = new HashSet<CitaMedica>();
            Ips = new HashSet<Ip>();
        }

        public int Id { get; set; }
        public string NombreSede { get; set; }
        public string NitSede { get; set; }
        public int IdCiudad { get; set; }
        public string DireccionSede { get; set; }

        public virtual Ciudad IdCiudadNavigation { get; set; }
        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }
        public virtual ICollection<Ip> Ips { get; set; }
    }
}
