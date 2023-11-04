using System.ComponentModel.DataAnnotations.Schema;

namespace GDVTsmV3.Models
{
    public class Asignacion_Roles
    {
        [ForeignKey("Usuario")]
        public int Usuario_Id { get; set; }
        public Usuario Usuario { get; set; }
        [ForeignKey("Rol")]
        public int Rol_Id { get; set; }
        public Rol Rol { get; set; }
    }
}
