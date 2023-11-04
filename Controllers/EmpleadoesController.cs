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
    public class EmpleadoesController : Controller
    {
        private readonly GDVTsmV3Context _context;

        public EmpleadoesController(GDVTsmV3Context context)
        {
            _context = context;
        }

        // GET: Empleadoes
        public async Task<IActionResult> Index()
        {
            var gDVTsmV3Context = _context.Empleado.Include(e => e.Persona).Include(e => e.Usuario);
            return View(await gDVTsmV3Context.ToListAsync());
        }

        // GET: Empleadoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.Persona)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Empleado_Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // GET: Empleadoes/Create
        public IActionResult Create()
        {
            ViewData["Persona_Id"] = new SelectList(_context.Persona, "Persona_Id", "Nombre");
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Nombre_Usuario");
            return View();
        }

        // POST: Empleadoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Empleado_Id,Persona_Id,Usuario_Id")] Empleado empleado)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empleado);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Persona_Id"] = new SelectList(_context.Persona, "Persona_Id", "Persona_Id", empleado.Persona_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena", empleado.Usuario_Id);
            return View(empleado);
        }

        // GET: Empleadoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }
            ViewData["Persona_Id"] = new SelectList(_context.Persona, "Persona_Id", "Persona_Id", empleado.Persona_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena", empleado.Usuario_Id);
            return View(empleado);
        }

        // POST: Empleadoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Empleado_Id,Persona_Id,Usuario_Id")] Empleado empleado)
        {
            if (id != empleado.Empleado_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empleado);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpleadoExists(empleado.Empleado_Id))
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
            ViewData["Persona_Id"] = new SelectList(_context.Persona, "Persona_Id", "Persona_Id", empleado.Persona_Id);
            ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena", empleado.Usuario_Id);
            return View(empleado);
        }

        // GET: Empleadoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado
                .Include(e => e.Persona)
                .Include(e => e.Usuario)
                .FirstOrDefaultAsync(m => m.Empleado_Id == id);
            if (empleado == null)
            {
                return NotFound();
            }

            return View(empleado);
        }

        // POST: Empleadoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Empleado == null)
            {
                return Problem("Entity set 'GDVTsmV3Context.Empleado'  is null.");
            }
            var empleado = await _context.Empleado.FindAsync(id);
            if (empleado != null)
            {
                _context.Empleado.Remove(empleado);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpleadoExists(int id)
        {
          return (_context.Empleado?.Any(e => e.Empleado_Id == id)).GetValueOrDefault();
        }
    }
}
