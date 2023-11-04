using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using GDVTsmV3.Data;
using GDVTsmV3.Models;

namespace GDVTsmV3.Views.Empleados
{
    public class CreateModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public CreateModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["Persona_Id"] = new SelectList(_context.Persona, "Persona_Id", "Persona_Id");
        ViewData["Usuario_Id"] = new SelectList(_context.Usuario, "Usuario_Id", "Contrasena");
            return Page();
        }

        [BindProperty]
        public Empleado Empleado { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Empleado.Add(Empleado);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
