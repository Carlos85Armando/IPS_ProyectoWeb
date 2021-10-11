using System;
using System.Collections.Generic;

#nullable disable

namespace IPS_Logic.DataBase
{
    public partial class Sintoma
    {
        public Sintoma()
        {
            CitaMedicas = new HashSet<CitaMedica>();
        }

        public int Id { get; set; }
        public bool? Fiebre { get; set; }
        public bool? Adelgazamiento { get; set; }
        public bool? Diarrea { get; set; }
        public bool? Nauseas { get; set; }
        public bool? Vomito { get; set; }

        public virtual ICollection<CitaMedica> CitaMedicas { get; set; }
    }
}
