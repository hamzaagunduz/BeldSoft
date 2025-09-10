using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AppUsers.Queries.GetPagedAppUsers
{
    public class GetPagedAppUsersQuery : IRequest<CommonResponse<List<GetPagedAppUsersResult>>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
