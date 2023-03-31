using MediatR;

namespace EShoppingAPI.Application.Features.Commands.AppUser.UpdatePssword
{
    public class UpdatePasswordCommandRequest:IRequest<UpdatePasswordCommandRespons>
    {
        public string UserId { get; set; }
        public string ResetToken { get; set; }
        public string Password { get; set; }
        public string PasswordConfirm { get; set; }
    }
}