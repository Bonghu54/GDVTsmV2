using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;

namespace GDVTsmV3.Views.Empleados
{
    public class DeleteModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public DeleteModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Empleado Empleado { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }

            var empleado = await _context.Empleado.FirstOrDefaultAsync(m => m.Empleado_Id == id);

            if (empleado == null)
            {
                return NotFound();
            }
            else 
            {
                Empleado = empleado;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Empleado == null)
            {
                return NotFound();
            }
            var empleado = await _context.Empleado.FindAsync(id);

            if (empleado != null)
            {
                Empleado = empleado;
                _context.Empleado.Remove(Empleado);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
