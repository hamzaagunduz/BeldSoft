using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.Child.Queries.GetAllChild
{
    public class GetAllChildQuery : IRequest<CommonResponse<List<GetAllChildResult>>>
    {
        // Ýleride filtreleme veya sayfalama için property eklenebilir
    }
}
