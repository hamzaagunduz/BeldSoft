using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.Child.Queries.GetAllChild
{
    public class GetAllChildQuery : IRequest<CommonResponse<List<GetAllChildResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
