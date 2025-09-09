using AutoMapper;
using Beldsoft.Application.Features.AppUsers.Commands.CreateAppUser;
using Beldsoft.Application.Features.AppUsers.Commands.UpdateAppUser;
using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.MVC.ViewModels.AppUsers;

namespace Beldsoft.MVC.Mapping
{
    public class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUserCreateViewModel, CreateAppUserCommand>();
            CreateMap<AppUserEditViewModel, UpdateAppUserCommand>();
            CreateMap<GetAllAppUsersResult, AppUserListViewModel>();
            CreateMap<GetAppUserByIdResult, AppUserEditViewModel>();
        }
    }
}
