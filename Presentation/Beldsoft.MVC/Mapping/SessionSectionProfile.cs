using AutoMapper;
using Beldsoft.Application.Features.SessionSection.Commands.UpdateSessionSection;
using Beldsoft.Application.Features.SessionSection.Results;
using Beldsoft.MVC.ViewModels.SessionSection;

namespace Beldsoft.MVC.Mapping
{
    public class SessionSectionProfile : Profile
    {
        public SessionSectionProfile()
        {
            // GetAll
            CreateMap<GetAllSessionSectionsResult, SessionSectionGetAllViewModel>();

            // GetById -> UpdateViewModel
            CreateMap<GetSessionSectionByIdResult, SessionSectionUpdateViewModel>();

            // UpdateViewModel -> Command
            CreateMap<SessionSectionUpdateViewModel, UpdateSessionSectionCommand>();
        }
    }
}
