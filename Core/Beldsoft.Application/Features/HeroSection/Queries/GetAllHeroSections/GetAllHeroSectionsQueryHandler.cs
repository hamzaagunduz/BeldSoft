using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using Beldsoft.Application.Features.HeroSection.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.HeroSection.Queries.GetAllHeroSections
{
    public class GetAllHeroSectionsQueryHandler : IRequestHandler<GetAllHeroSectionsQuery, CommonResponse<List<GetAllHeroSectionsResult>>>
    {
        private readonly IHeroSectionRepository _heroSectionRepository;

        public GetAllHeroSectionsQueryHandler(IHeroSectionRepository heroSectionRepository)
        {
            _heroSectionRepository = heroSectionRepository;
        }

        public async Task<CommonResponse<List<GetAllHeroSectionsResult>>> Handle(GetAllHeroSectionsQuery request, CancellationToken cancellationToken)
        {
            var heroSections = await _heroSectionRepository.GetAllAsync();

            var result = heroSections.Select(h => new GetAllHeroSectionsResult
            {
                Id= h.Id,
                SubTitle = h.SubTitle,
                MainTitle = h.MainTitle,
                MainTitleHighlight = h.MainTitleHighlight,
                Description = h.Description,
                BigImageUrl = h.BigImageUrl,
                SmallImageUrl=h.SmallImageUrl
            }).ToList();

            return CommonResponse<List<GetAllHeroSectionsResult>>.Success(result);
        }
    }
}
