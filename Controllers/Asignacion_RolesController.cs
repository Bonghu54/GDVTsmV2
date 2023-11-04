using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;

namespace GDVTsmV3.Controllers
{
    public class Asignacion_RolesController : Controller
    {
        private readonly GDVTsmV3Context _context;

        public Asignacion_RolesController(GDVTsmV3Context context)
        {
            _context = context;
        }

        // GET: Asignacion_Roles
        public async Task<IActionResult> Index()
        {
            var gDVTsmV3Context = _context.Asignacion_Roles.Include(a => a.Rol).Include(a => a.Usuario);
            return View(await gDVTsmV3Context.ToListAsync());
        }

        // GET: Asignacion_Roles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Asignacion_Roles == null)
            {
                return NotFound();
            }

            var asignacion_Roles = await _context.Asignacion_Roles
                .Include(a => a.Rol)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Usuario_Id == id);
            if (asignacion_Roles == null)
            {
                return NotFound();
            }

            return View(asignacion_Roles);
        }

        // GET: Asignacion_Roles/Create
        public IActionResult Create()
        {
            ViewData["Rol_Id"] = new SelectList(_context.Rol, "Rol_Id", "Nombre_Rol");
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Nombre_Usuario");
            return View();
        }

        // POST: Asignacion_Roles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Usuario_Id,Rol_Id")] Asignacion_Roles asignacion_Roles)
        {
            if (ModelState.IsValid)
            {
                _context.Add(asignacion_Roles);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Rol_Id"] = new SelectList(_context.Rol, "Rol_Id", "Rol_Id", asignacion_Roles.Rol_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena", asignacion_Roles.Usuario_Id);
            return View(asignacion_Roles);
        }

        // GET: Asignacion_Roles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Asignacion_Roles == null)
            {
                return NotFound();
            }

            var asignacion_Roles = await _context.Asignacion_Roles.FindAsync(id);
            if (asignacion_Roles == null)
            {
                return NotFound();
            }
            ViewData["Rol_Id"] = new SelectList(_context.Rol, "Rol_Id", "Rol_Id", asignacion_Roles.Rol_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena", asignacion_Roles.Usuario_Id);
            return View(asignacion_Roles);
        }

        // POST: Asignacion_Roles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Usuario_Id,Rol_Id")] Asignacion_Roles asignacion_Roles)
        {
            if (id != asignacion_Roles.Usuario_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(asignacion_Roles);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Asignacion_RolesExists((int)asignacion_Roles.Usuario_Id))
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
            ViewData["Rol_Id"] = new SelectList(_context.Rol, "Rol_Id", "Rol_Id", asignacion_Roles.Rol_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena", asignacion_Roles.Usuario_Id);
            return View(asignacion_Roles);
        }

        // GET: Asignacion_Roles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Asignacion_Roles == null)
            {
                return NotFound();
            }

            var asignacion_Roles = await _context.Asignacion_Roles
                .Include(a => a.Rol)
                .Include(a => a.Usuario)
                .FirstOrDefaultAsync(m => m.Usuario_Id == id);
            if (asignacion_Roles == null)
            {
                return NotFound();
            }

            return View(asignacion_Roles);
        }

        // POST: Asignacion_Roles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Asignacion_Roles == null)
            {
                return Problem("Entity set 'GDVTsmV3Context.Asignacion_Roles'  is null.");
            }
            var asignacion_Roles = await _context.Asignacion_Roles.FindAsync(id);
            if (asignacion_Roles != null)
            {
                _context.Asignacion_Roles.Remove(asignacion_Roles);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Asignacion_RolesExists(int id)
        {
          return (_context.Asignacion_Roles?.Any(e => e.Usuario_Id == id)).GetValueOrDefault();
        }
    }
}
