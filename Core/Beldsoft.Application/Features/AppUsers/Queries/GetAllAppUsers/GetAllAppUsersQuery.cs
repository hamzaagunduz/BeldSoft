using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.AppUsers.Queries.GetAllAppUsers
{
    public class GetAllAppUsersQuery : IRequest<CommonResponse<List<GetAllAppUsersResult>>>
    {
    }
}
