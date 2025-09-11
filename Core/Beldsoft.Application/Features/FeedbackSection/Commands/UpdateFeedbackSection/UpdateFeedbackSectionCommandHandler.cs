using Beldsoft.Application.Interfaces.IFeedbackSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.FeedbackSection.Commands.UpdateFeedbackSection
{
    public class UpdateFeedbackSectionCommandHandler : IRequestHandler<UpdateFeedbackSectionCommand, CommonResponse<int>>
    {
        private readonly IFeedbackSectionRepository _feedbackSectionRepository;

        public UpdateFeedbackSectionCommandHandler(IFeedbackSectionRepository feedbackSectionRepository)
        {
            _feedbackSectionRepository = feedbackSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateFeedbackSectionCommand request, CancellationToken cancellationToken)
        {
            var feedbackSection = await _feedbackSectionRepository.GetByIdAsync(request.Id);
            if (feedbackSection == null)
                return CommonResponse<int>.Fail(new[] { "FeedbackSection not found" });

            // Slider
            if (!string.IsNullOrEmpty(request.BigImageUrl))
                feedbackSection.BigImageUrl = request.BigImageUrl;

            // Kullanýcý resimleri
            if (!string.IsNullOrEmpty(request.UserImageUrl1)) feedbackSection.UserImageUrl1 = request.UserImageUrl1;
            if (!string.IsNullOrEmpty(request.UserImageUrl2)) feedbackSection.UserImageUrl2 = request.UserImageUrl2;
            if (!string.IsNullOrEmpty(request.UserImageUrl3)) feedbackSection.UserImageUrl3 = request.UserImageUrl3;

            // Kullanýcý isimleri
            feedbackSection.UserName1 = request.UserName1;
            feedbackSection.UserName2 = request.UserName2;
            feedbackSection.UserName3 = request.UserName3;

            // Kullanýcý unvanlarý
            feedbackSection.UserPosition1 = request.UserPosition1;
            feedbackSection.UserPosition2 = request.UserPosition2;
            feedbackSection.UserPosition3 = request.UserPosition3;

            // Yorum metinleri
            feedbackSection.Comment1 = request.Comment1;
            feedbackSection.Comment2 = request.Comment2;
            feedbackSection.Comment3 = request.Comment3;

            // Yýldýz sayýlarý
            feedbackSection.Rating1 = request.Rating1;
            feedbackSection.Rating2 = request.Rating2;
            feedbackSection.Rating3 = request.Rating3;

            await _feedbackSectionRepository.UpdateAsync(feedbackSection);

            return CommonResponse<int>.Success(feedbackSection.Id);
        }
    }
}
