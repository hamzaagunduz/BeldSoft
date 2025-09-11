using Beldsoft.Application.Features.ServiceSection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.ServiceSection.Queries.GetAllServiceSections
{
    public class GetAllServiceSectionsQuery : IRequest<CommonResponse<List<GetAllServiceSectionsResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
