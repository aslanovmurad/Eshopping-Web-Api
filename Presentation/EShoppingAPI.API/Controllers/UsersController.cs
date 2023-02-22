using EShoppingAPI.Application.Features.Commands.AppUser.FacebookLogin;
using EShoppingAPI.Application.Features.Commands.AppUser.GoogleLogin;
using EShoppingAPI.Application.Features.Commants.AppUser.CreateUser;
using EShoppingAPI.Application.Features.Commants.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUsersCommentRequest createUsersCommentRequest)
        {
            CreateUsersCommentRespons respons = await _mediator.Send(createUsersCommentRequest);
            return Ok(respons);
        }
       
    }
}
