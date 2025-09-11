using AutoMapper;
using Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection;
using Beldsoft.Application.Features.HeroSection.Commands.UpdateHeroSection;
using Beldsoft.Application.Features.HeroSection.Results;
using Beldsoft.MVC.ViewModels.HeroSection;

namespace Beldsoft.MVC.Mapping
{
    public class HeroSectionProfile : Profile
    {
        public HeroSectionProfile()
        {
            CreateMap<HeroSectionCreateViewModel, CreateHeroSectionCommand>();
            CreateMap<GetAllHeroSectionsResult, HeroSectionGetAllViewModel>();
            CreateMap<HeroSectionUpdateViewModel, UpdateHeroSectionCommand>();
            CreateMap<GetHeroSectionByIdResult, HeroSectionUpdateViewModel>();


        }
    }
}
