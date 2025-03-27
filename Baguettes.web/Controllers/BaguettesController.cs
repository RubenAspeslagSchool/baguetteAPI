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
        public async Task<IActionResult> UpdateBaguette(BaguetteDto baguetteDto)
        {
            if (!await _baguetteService.DoesBaguetteIdExistAsync(baguetteDto.Id))
            {
                return BadRequest($"No baguette with id '{baguetteDto.Id}' found");
            }

            var existingBaguette = await _baguetteService.GetByIdAsync(baguetteDto.Id);

            if (existingBaguette == null)
            {
                return BadRequest("Baguette not found");
            }

            existingBaguette.Name = baguetteDto.Name;
            existingBaguette.Description = baguetteDto.Description;

            var success = await _baguetteService.UpdateBaguetteAsync(existingBaguette);

            if (success)
            {
                return Ok($"Baguette {existingBaguette.Id} updated");
            }

            return BadRequest("Update failed");
        }
    }
}
