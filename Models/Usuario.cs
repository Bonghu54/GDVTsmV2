using System.ComponentModel.DataAnnotations;

namespace GDVTsmV3.Models
{
    public class Usuario
    {
        [Key]
        public int Usuario_Id { get; set; }
        [Required]
        public string Nombre_Usuario { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="Por favor Ingrese un email correcto")]
        public string Correo_Electronico { get; set; }
        [Required]
        public string Contrasena { get; set;}
        public Empleado Empleado { get; set; }

        public ICollection<Asignacion_Roles> Asignacion_Roles { get; set; }


    }
}
