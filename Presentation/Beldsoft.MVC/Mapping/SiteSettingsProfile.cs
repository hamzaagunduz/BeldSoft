using AutoMapper;
using Beldsoft.Application.Features.SiteSettings.Commands.UpdateSiteSettings;
using Beldsoft.Application.Features.SiteSettings.Queries.GetAllSiteSettings;
using Beldsoft.Application.Features.SiteSettings.Queries.GetSiteSettingsById;
using Beldsoft.Application.Features.SiteSettings.Results;
using Beldsoft.MVC.ViewModels.SiteSettings;

namespace Beldsoft.MVC.Mapping
{
    public class SiteSettingsProfile : Profile
    {
        public SiteSettingsProfile()
        {
            // Tekil mapler
            CreateMap<GetSiteSettingsByIdResult, SiteSettingsUpdateViewModel>().ReverseMap();
            CreateMap<SiteSettingsUpdateViewModel, UpdateSiteSettingsCommand>().ReverseMap();

            // GetAll için ayrı map
            CreateMap<GetAllSiteSettingsResult, SiteSettingsGetAllViewModel>().ReverseMap();
        }
    }

}
