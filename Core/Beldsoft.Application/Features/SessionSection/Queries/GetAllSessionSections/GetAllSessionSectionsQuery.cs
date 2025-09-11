using Beldsoft.Application.Features.SessionSection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.SessionSection.Queries.GetAllSessionSections
{
    public class GetAllSessionSectionsQuery : IRequest<CommonResponse<List<GetAllSessionSectionsResult>>>
    {
        // Ýleride filtreleme, sayfalama veya arama için property eklenebilir
    }
}
