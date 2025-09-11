using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.HeroSection.Commands.UpdateHeroSection
{
    public class UpdateHeroSectionCommandHandler : IRequestHandler<UpdateHeroSectionCommand, CommonResponse<int>>
    {
        private readonly IServiceSectionRepository _heroSectionRepository;

        public UpdateHeroSectionCommandHandler(IServiceSectionRepository heroSectionRepository)
        {
            _heroSectionRepository = heroSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateHeroSectionCommand request, CancellationToken cancellationToken)
        {
            var heroSection = await _heroSectionRepository.GetByIdAsync(request.Id);
            if (heroSection == null)
                return CommonResponse<int>.Fail(new[] { "HeroSection not found" });


            heroSection.SubTitle = request.SubTitle;
            heroSection.MainTitle = request.MainTitle;
            heroSection.MainTitleHighlight = request.MainTitleHighlight;
            heroSection.Description = request.Description;

            if (!string.IsNullOrEmpty(request.SmallImageUrl))
                heroSection.SmallImageUrl = request.SmallImageUrl;

            if (!string.IsNullOrEmpty(request.BigImageUrl))
                heroSection.BigImageUrl = request.BigImageUrl;

            await _heroSectionRepository.UpdateAsync(heroSection);

            return CommonResponse<int>.Success(heroSection.Id);
        }
    }
}
