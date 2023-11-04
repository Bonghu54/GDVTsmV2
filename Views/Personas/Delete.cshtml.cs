﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;

namespace GDVTsmV3.Views.Personas
{
    public class DeleteModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public DeleteModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        [BindProperty]
      public Persona Persona { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }

            var persona = await _context.Persona.FirstOrDefaultAsync(m => m.Persona_Id == id);

            if (persona == null)
            {
                return NotFound();
            }
            else 
            {
                Persona = persona;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Persona == null)
            {
                return NotFound();
            }
            var persona = await _context.Persona.FindAsync(id);

            if (persona != null)
            {
                Persona = persona;
                _context.Persona.Remove(Persona);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
