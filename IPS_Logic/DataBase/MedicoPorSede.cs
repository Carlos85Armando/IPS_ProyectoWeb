using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class MedicoPorSede
    {
        public int IdSede { get; set; }
        public int IdMedico { get; set; }

        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Sede IdSedeNavigation { get; set; }
    }
}
