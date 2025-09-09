using Beldsoft.Application.Features.Auth.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.Auth.Commands.Login
{
    public class LoginCommand : IRequest<CommonResponse<LoginResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
