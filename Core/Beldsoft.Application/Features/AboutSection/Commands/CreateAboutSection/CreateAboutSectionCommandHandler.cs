using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AboutSection.Commands.CreateAboutSection
{
    public class CreateAboutSectionCommandHandler : IRequestHandler<CreateAboutSectionCommand, CommonResponse<int>>
    {
        private readonly IAboutSectionRepository _aboutSectionRepository;

        public CreateAboutSectionCommandHandler(IAboutSectionRepository aboutSectionRepository)
        {
            _aboutSectionRepository = aboutSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(CreateAboutSectionCommand request, CancellationToken cancellationToken)
        {
            var aboutSection = new Bedldsoft.Domain.Entities.AboutSection
            {
                BigImageUrl = request.BigImageUrl,
                SmallImageUrl = request.SmallImageUrl,
                SubTitle = request.SubTitle,
                MainTitle = request.MainTitle,
                ExperienceNumber = request.ExperienceNumber,
                ExperienceText = request.ExperienceText,
                Title1 = request.Title1,
                Title1Description = request.Title1Description,
                Title1Step1 = request.Title1Step1,
                Title1Step2 = request.Title1Step2,
                Title2 = request.Title2,
                Title2Description = request.Title2Description,
                Title2Step1 = request.Title2Step1,
                Title2Step2 = request.Title2Step2,
                Title3 = request.Title3,
                Title3Description = request.Title3Description,
                Title3Step1 = request.Title3Step1,
                Title3Step2 = request.Title3Step2
            };

            await _aboutSectionRepository.AddAsync(aboutSection);

            return CommonResponse<int>.Success(aboutSection.Id ?? 0);
        }
    }
}
