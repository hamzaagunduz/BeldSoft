using Beldsoft.Application.Features.HeroSection.Results;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.HeroSection.Queries.GetHeroSectionById
{
    public class GetHeroSectionByIdQueryHandler
        : IRequestHandler<GetHeroSectionByIdQuery, CommonResponse<GetHeroSectionByIdResult>>
    {
        private readonly IServiceSectionRepository _heroSectionRepository;

        public GetHeroSectionByIdQueryHandler(IServiceSectionRepository heroSectionRepository)
        {
            _heroSectionRepository = heroSectionRepository;
        }

        public async Task<CommonResponse<GetHeroSectionByIdResult>> Handle(GetHeroSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var hero = await _heroSectionRepository.GetByIdAsync(request.Id);


            var result = new GetHeroSectionByIdResult
            {
                Id = hero.Id,
                SubTitle = hero.SubTitle,
                MainTitle = hero.MainTitle,
                MainTitleHighlight = hero.MainTitleHighlight,
                Description = hero.Description,
                SmallImageUrl = hero.SmallImageUrl,
                BigImageUrl = hero.BigImageUrl
            };

            return CommonResponse<GetHeroSectionByIdResult>.Success(result);
        }
    }
}
