using Beldsoft.Application.Features.AboutSection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.AboutSection.Queries.GetAllAboutSections
{
    public class GetAllAboutSectionsQuery : IRequest<CommonResponse<List<GetAllAboutSectionsResult>>>
    {
        // Ýleride filtreleme veya sayfalama için property eklenebilir
    }
}
