using MediatR;
using Beldsoft.Application.Responses;

namespace Beldsoft.Application.Features.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommand : IRequest<CommonResponse<bool>>
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; } // Opsiyonel þifre güncelleme
    }
}
