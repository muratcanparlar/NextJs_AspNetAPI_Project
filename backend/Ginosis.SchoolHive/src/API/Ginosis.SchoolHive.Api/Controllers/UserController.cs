﻿using Ginosis.Common.Application;
using Ginosis.Common.Presentation.ApiResults;
using Ginosis.SchoolHive.Rest.Contracts.Requests.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SchoolHive.Modules.Users.Application.Users.RegisterUser;
using Swashbuckle.AspNetCore.Annotations;

namespace Ginosis.SchoolHive.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(ILogger<UserController> logger, ISender sender) : ControllerBase
    {
        private readonly ILogger<UserController> _logger = logger;

        [HttpPost("register")]
        [SwaggerOperation(OperationId = "User.Register")]
        //[Authorize]//todo: added for only testing. it will be removed.
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest request)
        {
            Result<Guid> result = await sender.Send(new RegisterUserCommand(request.FirstName, request.LastName, request.Email, request.Password));
            return result.Match<IActionResult>(
               onSuccess: () => Ok(new { result.Value }),
               onFailure: ApiResults.Problem);

        }

        [HttpGet("{id}/profile")]
        [SwaggerOperation(OperationId = "User.Profile")]
        [Authorize]
        public async Task<IActionResult> Profile([FromBody] UserRegisterRequest request)
        {
            Result<Guid> result = await sender.Send(new RegisterUserCommand(request.FirstName, request.LastName, request.Email, request.Password));
            return result.Match<IActionResult>(
               onSuccess: () => Ok(new { result.Value }),
               onFailure: ApiResults.Problem);

        }
    }
}
