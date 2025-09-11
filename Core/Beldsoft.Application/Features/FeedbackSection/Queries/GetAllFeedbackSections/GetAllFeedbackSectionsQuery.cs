using Beldsoft.Application.Features.FeedbackSection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.FeedbackSection.Queries.GetAllFeedbackSections
{
    public class GetAllFeedbackSectionsQuery : IRequest<CommonResponse<List<GetAllFeedbackSectionsResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
