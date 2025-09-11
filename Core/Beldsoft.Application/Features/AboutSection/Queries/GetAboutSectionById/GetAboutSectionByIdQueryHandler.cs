using Beldsoft.Application.Features.AboutSection.Results;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AboutSection.Queries.GetAboutSectionById
{
    public class GetAboutSectionByIdQueryHandler : IRequestHandler<GetAboutSectionByIdQuery, CommonResponse<GetAboutSectionByIdResult>>
    {
        private readonly IAboutSectionRepository _aboutSectionRepository;

        public GetAboutSectionByIdQueryHandler(IAboutSectionRepository aboutSectionRepository)
        {
            _aboutSectionRepository = aboutSectionRepository;
        }

        public async Task<CommonResponse<GetAboutSectionByIdResult>> Handle(GetAboutSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var aboutSection = await _aboutSectionRepository.GetByIdAsync(request.Id);

            if (aboutSection == null)
            {
                return CommonResponse<GetAboutSectionByIdResult>.Fail(new[] { $"AboutSection with Id {request.Id} not found." });
            }

            var result = new GetAboutSectionByIdResult
            {
                Id = aboutSection.Id,
                BigImageUrl = aboutSection.BigImageUrl,
                SmallImageUrl = aboutSection.SmallImageUrl,
                SubTitle = aboutSection.SubTitle,
                MainTitle = aboutSection.MainTitle,
                ExperienceNumber = aboutSection.ExperienceNumber,
                ExperienceText = aboutSection.ExperienceText,
                Title1 = aboutSection.Title1,
                Title1Description = aboutSection.Title1Description,
                Title1Step1 = aboutSection.Title1Step1,
                Title1Step2 = aboutSection.Title1Step2,
                Title2 = aboutSection.Title2,
                Title2Description = aboutSection.Title2Description,
                Title2Step1 = aboutSection.Title2Step1,
                Title2Step2 = aboutSection.Title2Step2,
                Title3 = aboutSection.Title3,
                Title3Description = aboutSection.Title3Description,
                Title3Step1 = aboutSection.Title3Step1,
                Title3Step2 = aboutSection.Title3Step2
            };

            return CommonResponse<GetAboutSectionByIdResult>.Success(result);
        }
    }
}
