using Baguettes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baguettes.Core.Data
{
    public class BaguetteDbContext : DbContext
    {
        public BaguetteDbContext(DbContextOptions<BaguetteDbContext> options) : base(options)
        {
        }

        public DbSet<Baguette> Baguettes { get; set; }
    }
}
