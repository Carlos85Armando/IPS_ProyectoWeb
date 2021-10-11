using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPS_Entity.Entity
{
    public class PersonaEntity: BaseEntity
    {
        [Required(ErrorMessage ="Campo obligatorio")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre Requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Apellido Requerido")]
        public string Apellidos { get; set; }
        [Required(ErrorMessage = "Cedula Requerida")]
        public string Cedula { get; set; }
        [Required(ErrorMessage = "Contraseña Requerida")]
        public string Contraseña { get; set; }
    }
}
