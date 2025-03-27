using Baguettes.Core.Entities;

namespace Baguettes.Core.Services
{
    public interface IBaguetteService
    {
        Task<IEnumerable<Baguette>> GetBaguettesAsync();
        Task<Baguette> CreateBaguetteAsync(Baguette baguette);
        Task<bool> DoesBaguetteIdExistAsync(int id);
        Task<Baguette> GetByIdAsync(int id);
        Task<bool> UpdateBaguetteAsync(Baguette baguette);
    }
}