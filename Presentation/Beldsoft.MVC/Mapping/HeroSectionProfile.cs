using AutoMapper;
using Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection;
using Beldsoft.MVC.ViewModels.HeroSection;

namespace Beldsoft.MVC.Mapping
{
    public class HeroSectionProfile : Profile
    {
        public HeroSectionProfile()
        {
            CreateMap<HeroSectionViewModel, CreateHeroSectionCommand>();

        }
    }
}
