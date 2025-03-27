using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baguettes.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaguettesController : ControllerBase
    {
        [HttpGet]
        public GetBaguette()
        {
            test

        }
        [HttpPost]
        public AddBaguette()
        {

        }
    }
}
