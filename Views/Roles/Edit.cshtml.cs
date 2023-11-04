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

namespace GDVTsmV3.Views.Roles
{
    public class EditModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public EditModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        [BindProperty]
        public Rol Rol { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol =  await _context.Rol.FirstOrDefaultAsync(m => m.Rol_Id == id);
            if (rol == null)
            {
                return NotFound();
            }
            Rol = rol;
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

            _context.Attach(Rol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(Rol.Rol_Id))
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

        private bool RolExists(int id)
        {
          return _context.Rol.Any(e => e.Rol_Id == id);
        }
    }
}
