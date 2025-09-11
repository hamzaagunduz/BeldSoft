using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AboutSection.Commands.UpdateAboutSection
{
    public class UpdateAboutSectionCommandHandler : IRequestHandler<UpdateAboutSectionCommand, CommonResponse<int>>
    {
        private readonly IAboutSectionRepository _aboutSectionRepository;

        public UpdateAboutSectionCommandHandler(IAboutSectionRepository aboutSectionRepository)
        {
            _aboutSectionRepository = aboutSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateAboutSectionCommand request, CancellationToken cancellationToken)
        {
            var aboutSection = await _aboutSectionRepository.GetByIdAsync(request.Id);
            if (aboutSection == null)
                return CommonResponse<int>.Fail(new[] { "AboutSection not found" });

            // Görseller
            if (!string.IsNullOrEmpty(request.BigImageUrl))
                aboutSection.BigImageUrl = request.BigImageUrl;

            if (!string.IsNullOrEmpty(request.SmallImageUrl))
                aboutSection.SmallImageUrl = request.SmallImageUrl;

            // Genel Baþlýk
            aboutSection.SubTitle = request.SubTitle;
            aboutSection.MainTitle = request.MainTitle;

            // Deneyim kýsmý
            aboutSection.ExperienceNumber = request.ExperienceNumber;
            aboutSection.ExperienceText = request.ExperienceText;

            // Tab 1
            aboutSection.Title1 = request.Title1;
            aboutSection.Title1Description = request.Title1Description;
            aboutSection.Title1Step1 = request.Title1Step1;
            aboutSection.Title1Step2 = request.Title1Step2;

            // Tab 2
            aboutSection.Title2 = request.Title2;
            aboutSection.Title2Description = request.Title2Description;
            aboutSection.Title2Step1 = request.Title2Step1;
            aboutSection.Title2Step2 = request.Title2Step2;

            // Tab 3
            aboutSection.Title3 = request.Title3;
            aboutSection.Title3Description = request.Title3Description;
            aboutSection.Title3Step1 = request.Title3Step1;
            aboutSection.Title3Step2 = request.Title3Step2;

            await _aboutSectionRepository.UpdateAsync(aboutSection);

            return CommonResponse<int>.Success(aboutSection.Id ?? 0);
        }
    }
}
