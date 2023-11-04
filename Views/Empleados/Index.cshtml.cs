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
    public class IndexModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public IndexModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        public IList<Empleado> Empleado { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Empleado != null)
            {
                Empleado = await _context.Empleado
                .Include(e => e.Persona)
                .Include(e => e.Usuario).ToListAsync();
            }
        }
    }
}
