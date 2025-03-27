using Baguettes.Core.Data;
using Baguettes.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baguettes.Core.Services
{
    public class BaguetteService : IBaguetteService
    {
        private readonly BaguetteDbContext _baguetteDbContext;

        public BaguetteService(BaguetteDbContext baguetteDbContext)
        {
            _baguetteDbContext = baguetteDbContext;
        }

        public async Task<IEnumerable<Baguette>> GetBaguettesAsync()
        {
            return await _baguetteDbContext.Baguettes
                .Select(b => new Baguette
                {
                    Id = b.Id,
                    Name = b.Name,
                    Description = b.Description
                })
                .ToListAsync();
        }

        public async Task<Baguette> CreateBaguetteAsync(Baguette baguette)
        {
            var createBaguette = new Baguette
            {
                Name = baguette.Name,
                Description = baguette.Description
            };

            _baguetteDbContext.Baguettes.Add(baguette);
            await _baguetteDbContext.SaveChangesAsync();

            baguette.Id = baguette.Id;

            return baguette;
        }

        public async Task<Baguette> UpdateBaguetteAsync(int id, Baguette baguette)
        {
            var baguetteToUpdate = await _baguetteDbContext.Baguettes.FindAsync(id);

            if (baguette == null)
            {
                return null;
            }

            baguette.Name = baguette.Name;
            baguette.Description = baguette.Description;

            await _baguetteDbContext.SaveChangesAsync();

            return baguette;
        }
    }
}
