using EShoppingAPI.Application.Features.Commands.AppUser.FacebookLogin;
using EShoppingAPI.Application.Features.Commands.AppUser.GoogleLogin;
using EShoppingAPI.Application.Features.Commants.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EShoppingAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginUserCommandRequest loginUserCommandRequest)
        {
            LoginUserCommandRespons respons = await _mediator.Send(loginUserCommandRequest);
            return Ok(respons);
        }
        [HttpPost("google-login")]
        public async Task<IActionResult> GoogleLogen(GoogleLoginCommandRequest googleLoginCommandRequest)
        {
            GoogleLoginCommandRespons respons = await _mediator.Send(googleLoginCommandRequest);
            return Ok(respons);
        }
        [HttpPost("facebook-login")]
        public async Task<IActionResult> FacebookLogen(FacebookLoginCommandRequest facebookLoginCommandRequest)
        {
            FacebookLoginCommandRespons respons = await _mediator.Send(facebookLoginCommandRequest);
            return Ok(respons);
        }
    }
}
