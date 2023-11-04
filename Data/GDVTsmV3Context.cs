using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GDVTsmV3.Models;

namespace GDVTsmV3.Data
{
    public class GDVTsmV3Context : DbContext
    {
        public GDVTsmV3Context (DbContextOptions<GDVTsmV3Context> options)
            : base(options)
        {
        }

        public GDVTsmV3Context()
        {
        }

        
        public DbSet<GDVTsmV3.Models.Empleado> Empleado { get; set; } = default!;

        public DbSet<GDVTsmV3.Models.Persona>? Persona { get; set; }

        public DbSet<GDVTsmV3.Models.Rol>? Rol { get; set; }

        public DbSet<GDVTsmV3.Models.Usuario>? Usuario { get; set; }


        
    }
}

