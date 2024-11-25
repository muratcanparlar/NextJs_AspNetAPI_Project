using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Ginosis.SchoolHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamController : ControllerBase
    {
        [HttpPost("create")]
        [SwaggerOperation(OperationId = "Exam.Create")]
        [Authorize(Policy = "exams:add")]
        public async Task<IActionResult> Create()
        {
            return Ok();

        }
    }
}
