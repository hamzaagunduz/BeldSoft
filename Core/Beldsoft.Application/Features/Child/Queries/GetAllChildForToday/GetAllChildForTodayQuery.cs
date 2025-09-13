using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetAllChildForToday
{
    public class GetAllChildForTodayQuery :IRequest<CommonResponse<List<GetAllChildForTodayResult>>>
    {
    }
}
