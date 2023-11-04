using System.ComponentModel.DataAnnotations;

namespace GDVTsmV3.Models
{
    public class Rol
    {
        [Key] 
        public int Rol_Id { get; set; }
        public string Nombre_Rol { get; set; }
        public string Descripcion { get; set; }
        public List<Usuario> Usuario { get; set; }
    }
}
