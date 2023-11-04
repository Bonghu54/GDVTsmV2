using GDVTsmV3.Data;
using GDVTsmV3.Models;
using GDVTsmV3.Services.Contract;
using Microsoft.EntityFrameworkCore;

namespace GDVTsmV3.Services.Implementation
{
    public class UsuarioService : IUsuarioService
    {
        private readonly GDVTsmV3Context _dbContext;
        public UsuarioService(GDVTsmV3Context dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Usuario> GetUsuario(string correo, string clave)
        {
            Usuario usuario_encontrado = await _dbContext.Usuario.Where(u => u.Correo_Electronico == correo && u.Contrasena == clave)
                 .FirstOrDefaultAsync();

            return usuario_encontrado;
        }

        public async Task<Usuario> SaveUsuario(Usuario modelo)
        {
            _dbContext.Usuario.Add(modelo);
            await _dbContext.SaveChangesAsync();
            return modelo;
        }
    }
}
