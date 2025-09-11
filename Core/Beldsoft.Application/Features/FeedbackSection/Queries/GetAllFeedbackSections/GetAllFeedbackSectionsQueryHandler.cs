using Beldsoft.Application.Features.FeedbackSection.Results;
using Beldsoft.Application.Interfaces.IFeedbackSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.FeedbackSection.Queries.GetAllFeedbackSections
{
    public class GetAllFeedbackSectionsQueryHandler : IRequestHandler<GetAllFeedbackSectionsQuery, CommonResponse<List<GetAllFeedbackSectionsResult>>>
    {
        private readonly IFeedbackSectionRepository _feedbackSectionRepository;

        public GetAllFeedbackSectionsQueryHandler(IFeedbackSectionRepository feedbackSectionRepository)
        {
            _feedbackSectionRepository = feedbackSectionRepository;
        }

        public async Task<CommonResponse<List<GetAllFeedbackSectionsResult>>> Handle(GetAllFeedbackSectionsQuery request, CancellationToken cancellationToken)
        {
            var feedbackSections = await _feedbackSectionRepository.GetAllAsync();

            var result = feedbackSections.Select(f => new GetAllFeedbackSectionsResult
            {
                Id = f.Id,
                BigImageUrl = f.BigImageUrl,
                UserImageUrl1 = f.UserImageUrl1,
                UserImageUrl2 = f.UserImageUrl2,
                UserImageUrl3 = f.UserImageUrl3,
                UserName1 = f.UserName1,
                UserName2 = f.UserName2,
                UserName3 = f.UserName3,
                UserPosition1 = f.UserPosition1,
                UserPosition2 = f.UserPosition2,
                UserPosition3 = f.UserPosition3,
                Comment1 = f.Comment1,
                Comment2 = f.Comment2,
                Comment3 = f.Comment3,
                Rating1 = f.Rating1,
                Rating2 = f.Rating2,
                Rating3 = f.Rating3
            }).ToList();

            return CommonResponse<List<GetAllFeedbackSectionsResult>>.Success(result);
        }
    }
}
