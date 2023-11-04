using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;

namespace GDVTsmV3.Views.Empleados
{
    public class EditModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public EditModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Empleado Empleado { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado =  await _context.Empleado.FirstOrDefaultAsync(m => m.Empleado_Id == id);
            if (empleado == null)
            {
                return NotFound();
            }
            Empleado = empleado;
           ViewData["Persona_Id"] = new SelectList(_context.Persona, "Persona_Id", "Persona_Id");
           ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(Empleado.Empleado_Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool EmpleadoExists(int id)
        {
          return _context.Empleado.Any(e => e.Empleado_Id == id);
        }
    }
}
