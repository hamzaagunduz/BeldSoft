using AutoMapper;
using Beldsoft.Application.Features.AboutSection.Commands.UpdateAboutSection;
using Beldsoft.Application.Features.AboutSection.Results;
using Beldsoft.MVC.ViewModels.AboutSection;

namespace Beldsoft.MVC.MappingProfiles
{
    public class AboutSectionProfile : Profile
    {
        public AboutSectionProfile()
        {
            // Query result -> ViewModel
            CreateMap<GetAboutSectionByIdResult, AboutSectionUpdateViewModel>().ReverseMap();
            CreateMap<GetAllAboutSectionsResult, AboutSectionGetAllViewModel>().ReverseMap();

            // ViewModel -> Command
            CreateMap<AboutSectionUpdateViewModel, UpdateAboutSectionCommand>().ReverseMap();
        }
    }
}
