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
            return await _baguetteDbContext.Baguettes.ToListAsync();
        }

        public async Task<Baguette> CreateBaguetteAsync(Baguette baguette)
        {
            _baguetteDbContext.Baguettes.Add(baguette);
            await _baguetteDbContext.SaveChangesAsync();
            return baguette;
        }

        public async Task<bool> DoesBaguetteIdExistAsync(int id)
        {
            return await _baguetteDbContext.Baguettes.AnyAsync(b => b.Id == id);
        }

        public async Task<Baguette> GetByIdAsync(int id)
        {
            return await _baguetteDbContext.Baguettes.FindAsync(id);
        }

        public async Task<bool> UpdateBaguetteAsync(Baguette baguette)
        {
            _baguetteDbContext.Baguettes.Update(baguette);
            return await _baguetteDbContext.SaveChangesAsync() > 0;
        }
    }
}
