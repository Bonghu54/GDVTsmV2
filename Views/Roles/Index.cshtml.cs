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
    public class IndexModel : PageModel
    {
        private readonly GDVTsmV3.Data.GDVTsmV3Context _context;

        public IndexModel(GDVTsmV3.Data.GDVTsmV3Context context)
        {
            _context = context;
        }

        public IList<Rol> Rol { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Rol != null)
            {
                Rol = await _context.Rol.ToListAsync();
            }
        }
    }
}
