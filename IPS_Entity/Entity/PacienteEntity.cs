﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS_Entity.Entity
{
    public class PacienteEntity:PersonaEntity
    {
        public int IdPaciente { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Direccion { get; set; }
        public int Edad { get; set; }
        public int IdPersona { get; set; }
        //public int? IdConvenio{ get; set;}
    }
}
