using MediatR;
using Beldsoft.Application.Responses; // CommonResponse namespace

namespace Beldsoft.Application.Features.AppUsers.Commands.CreateAppUser
{
    public class CreateAppUserCommand : IRequest<CommonResponse<int>>
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
