using MediatR;
using Beldsoft.Application.Responses;

namespace Beldsoft.Application.Features.AppUsers.Commands.DeleteAppUser
{
    public class DeleteAppUserCommand : IRequest<CommonResponse<bool>>
    {
        public int UserId { get; set; }
    }
}
