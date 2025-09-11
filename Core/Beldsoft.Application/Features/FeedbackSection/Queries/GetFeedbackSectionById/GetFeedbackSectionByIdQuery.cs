using Beldsoft.Application.Features.FeedbackSection.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.FeedbackSection.Queries.GetFeedbackSectionById
{
    public class GetFeedbackSectionByIdQuery : IRequest<CommonResponse<GetFeedbackSectionByIdResult>>
    {
        public int Id { get; set; }

        public GetFeedbackSectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
