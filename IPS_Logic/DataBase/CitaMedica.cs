using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class CitaMedica
    {
        public int Id { get; set; }
        public DateTime FechaCita { get; set; }
        public bool TipoCita { get; set; }
        public int IdPaciente { get; set; }
        public int IdMedico { get; set; }
        public int IdSede { get; set; }
        public int? IdSintomas { get; set; }

        public virtual Paciente IdMedico1 { get; set; }
        public virtual Medico IdMedicoNavigation { get; set; }
        public virtual Sede IdSedeNavigation { get; set; }
        public virtual Sintoma IdSintomasNavigation { get; set; }
    }
}
