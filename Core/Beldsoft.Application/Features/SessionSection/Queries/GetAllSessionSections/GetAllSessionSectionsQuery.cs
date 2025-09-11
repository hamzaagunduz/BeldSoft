using Beldsoft.Application.Features.SessionSection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.SessionSection.Queries.GetAllSessionSections
{
    public class GetAllSessionSectionsQuery : IRequest<CommonResponse<List<GetAllSessionSectionsResult>>>
    {
        // �leride filtreleme, sayfalama veya arama i�in property eklenebilir
    }
}
