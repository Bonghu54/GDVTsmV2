using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;
using GDVTsmV3.ViewModels;

namespace GDVTsmV3.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly GDVTsmV3Context _context;

        public UsuariosController(GDVTsmV3Context context)
        {
            _context = context;
        }

        // GET: Usuarios
        public async Task<IActionResult> Index()
        {
              return _context.Usuario != null ? 
                          View(await _context.Usuario.ToListAsync()) :
                          Problem("Entity set 'GDVTsmV3Context.Usuario'  is null.");
        }

        // GET: Usuarios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Usuario_Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario_Id,Nombre_Usuario,Correo_Electronico,Contrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usuario_Id,Nombre_Usuario,Correo_Electronico,Contrasena")] Usuario usuario)
        {
            if (id != usuario.Usuario_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(usuario);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuarioExists(usuario.Usuario_Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuario == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuario
                .FirstOrDefaultAsync(m => m.Usuario_Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuario == null)
            {
                return Problem("Entity set 'GDVTsmV3Context.Usuario'  is null.");
            }
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuario.Remove(usuario);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
          return (_context.Usuario?.Any(e => e.Usuario_Id == id)).GetValueOrDefault();
        }

        [HttpGet]
        public IActionResult AdministrarRol(int id)
        {
            UsuarioRoles usuarioRoles = new UsuarioRoles
            {
                ListaDeAsignacioDeRoles = _context.Asignacion_Roles.Include(e => e.Rol).Include(a => a.Usuario)
                .Where(a => a.Usuario_Id == id),
                Asignacion_Roles = new Asignacion_Roles()
                {
                    Usuario_Id = id
                },
                Usuario = _context.Usuario.FirstOrDefault(a => a.Usuario_Id == id)
            };
            List<int> listaTemporalAsigRoles = usuarioRoles.ListaDeAsignacioDeRoles.Select(e => e.Rol_Id).ToList();
            var listaTemporal =_context.Rol.Where(e=>!listaTemporalAsigRoles.Contains(e.Rol_Id)).ToList();
            usuarioRoles.ListaRoles = listaTemporal.Select(i => new SelectListItem
            {
                Text = i.Nombre_Rol,
                Value = i.Rol_Id.ToString()
            });
            return View(usuarioRoles);
        }
        [HttpPost]
        public IActionResult AdministrarRol(UsuarioRoles usuarioRoles)
        {
            if (usuarioRoles.Asignacion_Roles.Usuario_Id != 0 && usuarioRoles.Asignacion_Roles.Rol_Id != 0)
            {
                _context.Asignacion_Roles.Add(usuarioRoles.Asignacion_Roles);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(AdministrarRol), new { id = usuarioRoles.Asignacion_Roles.Usuario_Id });
        }



        [HttpPost]
        public IActionResult EliminarRoles(int idRol, UsuarioRoles usuarioRoles)
        {
            int idUsuario = usuarioRoles.Usuario.Usuario_Id;
            Asignacion_Roles asignacion_Roles = _context.Asignacion_Roles.FirstOrDefault(
                    u => u.Rol_Id == idRol && u.Usuario_Id == idUsuario
                );
            _context.Asignacion_Roles.Remove(asignacion_Roles);
            _context.SaveChanges();
            return RedirectToAction(nameof(AdministrarRol), new { @id = idUsuario });
        }



    }
}
