using MediatR;
using Beldsoft.Application.Responses;

namespace Beldsoft.Application.Features.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommand : IRequest<CommonResponse<bool>>
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Password { get; set; } // Opsiyonel þifre güncelleme
        public string? Role { get; set; }
    }
}
