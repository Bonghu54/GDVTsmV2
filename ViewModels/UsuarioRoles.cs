using GDVTsmV3.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GDVTsmV3.ViewModels
{
    public class UsuarioRoles
    {
        public Asignacion_Roles Asignacion_Roles { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Asignacion_Roles> ListaDeAsignacioDeRoles { get; set; }
        public IEnumerable<SelectListItem> ListaRoles { get; set; }
    }
}
