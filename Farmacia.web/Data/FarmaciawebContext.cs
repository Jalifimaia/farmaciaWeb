using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Farmacia.Entidades;

namespace Farmacia.web.Data
{
    public class FarmaciawebContext : DbContext
    {
        public FarmaciawebContext (DbContextOptions<FarmaciawebContext> options)
            : base(options)
        {
        }

        public DbSet<Farmacia.Entidades.Administrador> Administrador { get; set; } = default!;
    }
}
