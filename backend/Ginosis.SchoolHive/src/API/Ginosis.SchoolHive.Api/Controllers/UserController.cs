using Ginosis.Common.Application;
using Ginosis.SchoolHive.Rest.Contracts.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SchoolHive.Modules.Users.Application.Users.RegisterUser;
using Ginosis.Common.Presentation.ApiResults;
using Swashbuckle.AspNetCore.Annotations;

namespace Ginosis.SchoolHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> logger, ISender sender) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;

        [HttpPost("register")]
        [SwaggerOperation(OperationId ="User.Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            Result<Guid> result = await sender.Send(new RegisterUserCommand(request.FirstName, request.LastName, request.Email,request.Password));
            return result.Match<IActionResult>(
               onSuccess: () => Ok(new { result.Value }),
               onFailure: ApiResults.Problem);
           
        }
    }
}
