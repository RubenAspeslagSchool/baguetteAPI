using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Baguettes.web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaguettesController : ControllerBase
    {
        [HttpGet]
        public ActionResult GetBaguette()
        {
            return null;

        }
        [HttpPost]
        public ActionResult AddBaguette()
        {
            return null;
        }
    }
}
