using MediatR;

namespace EShoppingAPI.Application.Features.Commands.AppUser.VerifyResetToken
{
    public class VerifyResetTokenCommandRequest:IRequest<VerifyResetTokenCommandRespons>
    {
        public string ResetToken { get; set; }
        public string UserId { get; set; }
    }
}