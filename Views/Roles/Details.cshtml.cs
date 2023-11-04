using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Data;
using GDVTsmV3.Models;

namespace GDVTsmV3.Views.Roles
{
    public class DetailsModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public DetailsModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

      public Rol Rol { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Rol == null)
            {
                return NotFound();
            }

            var rol = await _context.Rol.FirstOrDefaultAsync(m => m.Rol_Id == id);
            if (rol == null)
            {
                return NotFound();
            }
            else 
            {
                Rol = rol;
            }
            return Page();
        }
    }
}
