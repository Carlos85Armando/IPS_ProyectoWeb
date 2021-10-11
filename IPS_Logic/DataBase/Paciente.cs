using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class Paciente
    {
        public Paciente()
        {
            CitaMedicas = new HashSet<CitaMedica>();
        }

        public int Id { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public int IdPersona { get; set; }
        public int? IdConvenio { get; set; }

        public virtual Convenio IdConvenioNavigation { get; set; }
        public virtual Persona IdPersonaNavigation { get; set; }
        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }
    }
}
