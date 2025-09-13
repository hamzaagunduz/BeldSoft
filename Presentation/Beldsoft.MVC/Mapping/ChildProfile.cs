using AutoMapper;
using Beldsoft.Application.Features.Child.Commands.CreateChild;
using Beldsoft.Application.Features.Child.Commands.UpdateChild;
using Beldsoft.Application.Features.Child.Results;
using Beldsoft.MVC.ViewModels.Child;

namespace Beldsoft.MVC.Mapping
{
    public class ChildProfile : Profile
    {
        public ChildProfile()
        {
            CreateMap<ChildCreateViewModel, CreateChildCommand>();
            CreateMap<ChildUpdateViewModel, UpdateChildCommand>();
            CreateMap<GetAllChildResult, ChildGetAllViewModel>();
            CreateMap<GetChildByIdResult, ChildGetByIdViewModel>();
        }
    }
}
