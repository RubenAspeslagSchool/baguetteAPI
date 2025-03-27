using Baguettes.Core.Entities;
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
        public async Task<ActionResult<IEnumerable<BaguetteDto>>> GetBaguettes()
        {
            return Ok(await _baguetteService.GetBaguettesAsync());
        }

        [HttpPost]
        public ActionResult AddBaguette()
        {
            return null;
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
