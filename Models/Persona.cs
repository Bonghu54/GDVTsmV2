
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDVTsmV3.Models
{
    public class Persona
    {
        [Key]
        public int Persona_Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ci { get; set; }
        [DataType(DataType.Date)]
        public DateTime Fecha_Nac { get; set; }
        public Empleado Empleado { get; set; }
    }
}
