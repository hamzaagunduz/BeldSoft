using AutoMapper;
using Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection;
using Beldsoft.Application.Features.HeroSection.Commands.UpdateHeroSection;
using Beldsoft.Application.Features.HeroSection.Results;
using Beldsoft.Application.Features.ServiceSection.Commands.CreateServiceSection;
using Beldsoft.Application.Features.ServiceSection.Commands.UpdateServiceSection;
using Beldsoft.Application.Features.ServiceSection.Queries.GetAllServiceSections;
using Beldsoft.Application.Features.ServiceSection.Results;
using Beldsoft.MVC.ViewModels.HeroSection;
using Beldsoft.MVC.ViewModels.ServiceSection;

namespace Beldsoft.MVC.Mapping
{
    public class ServiceSectionProfile : Profile
    {
        public ServiceSectionProfile()
        {
            CreateMap<ServiceSectionCreateViewModel, CreateServiceSectionCommand>();
            CreateMap<ServiceSectionUpdateViewModel, UpdateServiceSectionCommand>();

            CreateMap<GetAllServiceSectionsResult, ServiceSectionGetAllViewModel>();
            CreateMap<GetServiceSectionByIdResult, ServiceSectionUpdateViewModel>();

        }
    }
}
