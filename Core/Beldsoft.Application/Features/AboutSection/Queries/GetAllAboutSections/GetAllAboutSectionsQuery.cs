using Beldsoft.Application.Features.AboutSection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.AboutSection.Queries.GetAllAboutSections
{
    public class GetAllAboutSectionsQuery : IRequest<CommonResponse<List<GetAllAboutSectionsResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
