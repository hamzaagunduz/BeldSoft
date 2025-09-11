using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces;
using Bedldsoft.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;

namespace Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection
{
    public class CreateHeroSectionCommandHandler : IRequestHandler<CreateHeroSectionCommand, CommonResponse<int>>
    {
        private readonly IHeroSectionRepository _heroSectionRepository;

        public CreateHeroSectionCommandHandler(IHeroSectionRepository heroSectionRepository)
        {
            _heroSectionRepository = heroSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(CreateHeroSectionCommand request, CancellationToken cancellationToken)
        {
            var heroSection = new Bedldsoft.Domain.Entities.HeroSection
            {
                SubTitle = request.SubTitle,
                MainTitle = request.MainTitle,
                MainTitleHighlight = request.MainTitleHighlight,
                Description = request.Description,
                SmallImageUrl = request.SmallImageUrl,
                BigImageUrl = request.BigImageUrl
            };

            await _heroSectionRepository.AddAsync(heroSection);

            return CommonResponse<int>.Success(heroSection.Id);
        }
    }
}
