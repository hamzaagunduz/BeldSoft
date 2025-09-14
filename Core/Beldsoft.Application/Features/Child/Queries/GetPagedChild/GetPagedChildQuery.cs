using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetPagedChild
{
    public class GetPagedChildQuery : IRequest<CommonResponse<PagedChildResult>>
    {
        public int PageNumber { get; set; } = 1;  // Default 1
        public int PageSize { get; set; } = 10;   // Default 10
    }
}
