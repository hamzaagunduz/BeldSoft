using Beldsoft.Application.Features.AboutSection.Results;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AboutSection.Queries.GetAllAboutSections
{
    public class GetAllAboutSectionsQueryHandler : IRequestHandler<GetAllAboutSectionsQuery, CommonResponse<List<GetAllAboutSectionsResult>>>
    {
        private readonly IAboutSectionRepository _aboutSectionRepository;

        public GetAllAboutSectionsQueryHandler(IAboutSectionRepository aboutSectionRepository)
        {
            _aboutSectionRepository = aboutSectionRepository;
        }

        public async Task<CommonResponse<List<GetAllAboutSectionsResult>>> Handle(GetAllAboutSectionsQuery request, CancellationToken cancellationToken)
        {
            var aboutSections = await _aboutSectionRepository.GetAllAsync();

            var result = aboutSections.Select(a => new GetAllAboutSectionsResult
            {
                Id = a.Id,
                BigImageUrl = a.BigImageUrl,
                SmallImageUrl = a.SmallImageUrl,
                SubTitle = a.SubTitle,
                MainTitle = a.MainTitle,
                ExperienceNumber = a.ExperienceNumber,
                ExperienceText = a.ExperienceText,
                Title1 = a.Title1,
                Title1Description = a.Title1Description,
                Title1Step1 = a.Title1Step1,
                Title1Step2 = a.Title1Step2,
                Title2 = a.Title2,
                Title2Description = a.Title2Description,
                Title2Step1 = a.Title2Step1,
                Title2Step2 = a.Title2Step2,
                Title3 = a.Title3,
                Title3Description = a.Title3Description,
                Title3Step1 = a.Title3Step1,
                Title3Step2 = a.Title3Step2
            }).ToList();

            return CommonResponse<List<GetAllAboutSectionsResult>>.Success(result);
        }
    }
}
