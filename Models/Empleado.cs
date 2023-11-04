using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GDVTsmV3.Models
{
    public class Empleado
    {
        [Key] 
        public int Empleado_Id { get; set; }
        [ForeignKey("Persona")]
        public int? Persona_Id { get; set; }
        public Persona Persona { get; set; }
        [ForeignKey("Usuario")]
        public int? Usuario_Id {  get; set; }
        public Usuario Usuario { get; set; }
    }
}
