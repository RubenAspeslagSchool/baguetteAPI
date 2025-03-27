using Baguettes.Core.Services;
using Baguettes.web.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baguettes.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaguettesController : ControllerBase
    {
        private readonly IBaguetteService _baguetteService;
        public BaguettesController(IBaguetteService baguetteService)
        {
            _baguetteService = baguetteService;
        }

        [HttpGet]
        public async Task<IEnumerable<BaguetteDto>> GetBaguette()
        {
            IEnumerable<Core.Entities.Baguette>? Baguettes = await _baguetteService.GetBaguettesAsync();
            return Baguettes.Select(b => new BaguetteDto() { Id = b.Id, Description = b.Description, Name = b.Name});

        }
        [HttpPost]
        public ActionResult AddBaguette()
        {
            return null;
        }
    }
}
