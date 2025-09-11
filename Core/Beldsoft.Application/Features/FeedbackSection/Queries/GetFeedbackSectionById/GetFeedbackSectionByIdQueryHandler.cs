using Beldsoft.Application.Features.FeedbackSection.Results;
using Beldsoft.Application.Interfaces.IFeedbackSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.FeedbackSection.Queries.GetFeedbackSectionById
{
    public class GetFeedbackSectionByIdQueryHandler : IRequestHandler<GetFeedbackSectionByIdQuery, CommonResponse<GetFeedbackSectionByIdResult>>
    {
        private readonly IFeedbackSectionRepository _feedbackSectionRepository;

        public GetFeedbackSectionByIdQueryHandler(IFeedbackSectionRepository feedbackSectionRepository)
        {
            _feedbackSectionRepository = feedbackSectionRepository;
        }

        public async Task<CommonResponse<GetFeedbackSectionByIdResult>> Handle(GetFeedbackSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var feedbackSection = await _feedbackSectionRepository.GetByIdAsync(request.Id);

            if (feedbackSection == null)
            {
                return CommonResponse<GetFeedbackSectionByIdResult>.Fail(new[] { $"FeedbackSection with Id {request.Id} not found." });
            }

            var result = new GetFeedbackSectionByIdResult
            {
                Id = feedbackSection.Id,
                BigImageUrl = feedbackSection.BigImageUrl,
                UserImageUrl1 = feedbackSection.UserImageUrl1,
                UserImageUrl2 = feedbackSection.UserImageUrl2,
                UserImageUrl3 = feedbackSection.UserImageUrl3,
                UserName1 = feedbackSection.UserName1,
                UserName2 = feedbackSection.UserName2,
                UserName3 = feedbackSection.UserName3,
                UserPosition1 = feedbackSection.UserPosition1,
                UserPosition2 = feedbackSection.UserPosition2,
                UserPosition3 = feedbackSection.UserPosition3,
                Comment1 = feedbackSection.Comment1,
                Comment2 = feedbackSection.Comment2,
                Comment3 = feedbackSection.Comment3,
                Rating1 = feedbackSection.Rating1,
                Rating2 = feedbackSection.Rating2,
                Rating3 = feedbackSection.Rating3
            };

            return CommonResponse<GetFeedbackSectionByIdResult>.Success(result);
        }
    }
}
