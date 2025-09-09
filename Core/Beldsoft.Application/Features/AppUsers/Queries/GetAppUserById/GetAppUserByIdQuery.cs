using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.AppUsers.Queries.GetAppUserById
{
    public class GetAppUserByIdQuery : IRequest<CommonResponse<GetAppUserByIdResult>>
    {
        public int UserId { get; set; }
    }
}
