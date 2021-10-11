using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class Ciudad
    {
        public Ciudad()
        {
            Sedes = new HashSet<Sede>();
        }

        public int Id { get; set; }
        public string NombreCiudad { get; set; }
        public string NombreDepartamento { get; set; }

        public virtual ICollection<Sede> Sedes { get; set; }
    }
}
