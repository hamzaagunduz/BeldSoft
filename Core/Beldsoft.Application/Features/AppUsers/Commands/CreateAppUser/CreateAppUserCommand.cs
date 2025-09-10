using MediatR;
using Beldsoft.Application.Responses; // CommonResponse namespace

namespace Beldsoft.Application.Features.AppUsers.Commands.CreateAppUser
{
    public class CreateAppUserCommand : IRequest<CommonResponse<int>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
