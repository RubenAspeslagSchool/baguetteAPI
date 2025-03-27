using Baguettes.Core.Entities;

namespace Baguettes.Core.Services
{
    public interface IBaguetteService
    {
        Task<Baguette> CreateBaguetteAsync(Baguette baguette);
        Task<IEnumerable<Baguette>> GetBaguettesAsync();
        Task<Baguette> UpdateBaguetteAsync(int id, Baguette baguette);
    }
}