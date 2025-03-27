using Baguettes.Core.Entities;
using Baguettes.Core.Services;
using Baguettes.web.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
        public async Task<ActionResult<IEnumerable<BaguetteDto>>> GetBaguettes()
        {
            return Ok(await _baguetteService.GetBaguettesAsync());
        }

        [HttpPost]
        public async Task<ActionResult> AddBaguette(BaguetteDto baguette)
        {
            return Ok(await _baguetteService.CreateBaguetteAsync(new Core.Entities.Baguette()
            {
                Id = baguette.Id,
                Name = baguette.Name,
                Description = baguette.Description
            }));
        }

        [HttpPut]
        public async Task<ActionResult<BaguetteDto>> UpdateBaguette(Baguette baguette)
        {
            var updatedBaguette = await _baguetteService.UpdateBaguetteAsync(baguette.Id, baguette);

            if (updatedBaguette == null)
            {
                return NotFound();
            }

            return Ok(updatedBaguette);
        }
    }
}
