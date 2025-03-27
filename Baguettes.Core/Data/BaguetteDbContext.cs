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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Baguette>().HasData(
                new Baguette
                {
                    Id = 1,
                    Name = "Traditional Baguette",
                    Description = "Classic French baguette with a crispy crust."
                },
                new Baguette
                {
                    Id = 2,
                    Name = "Whole Wheat Baguette",
                    Description = "Healthy whole wheat variation of the classic baguette."
                },
                new Baguette
                {
                    Id = 3,
                    Name = "Sourdough Baguette",
                    Description = "Tangy sourdough baguette with a chewy texture."
                },
                new Baguette
                {
                    Id = 4,
                    Name = "Garlic Baguette",
                    Description = "Baguette infused with roasted garlic flavors."
                }
            );
        }
    }
}
