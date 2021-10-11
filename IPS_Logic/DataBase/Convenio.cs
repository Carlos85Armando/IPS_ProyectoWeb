using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class Convenio
    {
        public Convenio()
        {
            Pacientes = new HashSet<Paciente>();
        }

        public int Id { get; set; }
        public bool TipoConvenio { get; set; }
        public DateTime Horario { get; set; }
        public int? Mensualidad { get; set; }
        public int? Descuento { get; set; }

        public virtual ICollection<Paciente> Pacientes { get; set; }
    }
}
