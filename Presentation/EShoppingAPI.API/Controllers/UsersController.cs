using EShoppingAPI.Application.Abstraction.Services;
using EShoppingAPI.Application.Features.Commands.AppUser.FacebookLogin;
using EShoppingAPI.Application.Features.Commands.AppUser.GoogleLogin;
using EShoppingAPI.Application.Features.Commands.AppUser.UpdatePssword;
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
        readonly IMailService _mailService;
        public UsersController(IMediator mediator, IMailService mailService)
        {
            _mediator = mediator;
            _mailService = mailService;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUsersCommentRequest createUsersCommentRequest)
        {
            CreateUsersCommentRespons respons = await _mediator.Send(createUsersCommentRequest);
            return Ok(respons);
        }

        [HttpGet]
        public async Task<IActionResult> ExampleTest()
        {
            await _mailService.SendMailAsync("asl98@gmail.com", "ornek", "<strong>ornek message</strong>");
            return Ok();
        }

        [HttpPost("update-password")]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordCommandRequest updatePasswordCommandRequest)
        {
            UpdatePasswordCommandRespons respons = await _mediator.Send(updatePasswordCommandRequest);
            return Ok(respons);
        }
       
    }
}
