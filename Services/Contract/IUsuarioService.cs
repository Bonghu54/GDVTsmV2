using GDVTsmV3.Models;
using Microsoft.EntityFrameworkCore;

namespace GDVTsmV3.Services.Contract
{
    public interface IUsuarioService
    {
        Task<Usuario> GetUsuario(string correo, string clave);
        Task<Usuario> SaveUsuario(Usuario modelo);

    }
}
