using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection
{
    public class CreateHeroSectionCommand : IRequest<CommonResponse<int>>
    {
        public string SubTitle { get; set; }
        public string MainTitle { get; set; }
        public string MainTitleHighlight { get; set; }
        public string Description { get; set; }
        public string SmallImageUrl { get; set; }
        public string BigImageUrl { get; set; }
    }
}
