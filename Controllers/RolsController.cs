using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GDVTsmV3.Controllers
{
    public class RolsController : Controller
    {
        private readonly GDVTsmV3Context _context;

        public RolsController(GDVTsmV3Context context)
        {
            _context = context;
        }

        // GET: Rols
        [HttpGet]
        public IActionResult Index()
        {
            List<Rol>listaRoles=_context.Rol.ToList();
            return View(listaRoles);
        }
        

        // GET: Rols/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol
                .FirstOrDefaultAsync(m => m.Rol_Id == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // GET: Rols/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rols/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Rol rol)
        {
            if (ModelState.IsValid)
            {
                _context.Rol.Add(rol);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Rols/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol.FindAsync(id);
            if (rol == null)
            {
                return NotFound();
            }
            return View(rol);
        }

        // POST: Rols/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rol_Id,Nombre_Rol,Descripcion")] Rol rol)
        {
            if (id != rol.Rol_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RolExists(rol.Rol_Id))
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
            return View(rol);
        }

        // GET: Rols/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol
                .FirstOrDefaultAsync(m => m.Rol_Id == id);
            if (rol == null)
            {
                return NotFound();
            }

            return View(rol);
        }

        // POST: Rols/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rol == null)
            {
                return Problem("Entity set 'GDVTsmV3Context.Rol'  is null.");
            }
            var rol = await _context.Rol.FindAsync(id);
            if (rol != null)
            {
                _context.Rol.Remove(rol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RolExists(int id)
        {
          return (_context.Rol?.Any(e => e.Rol_Id == id)).GetValueOrDefault();
        }
    }
}
