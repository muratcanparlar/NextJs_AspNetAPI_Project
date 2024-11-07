using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ginosis.SchoolHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register()
        {
            return Ok();
        }
    }
}
