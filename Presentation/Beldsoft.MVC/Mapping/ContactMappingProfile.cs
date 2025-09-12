using AutoMapper;
using Beldsoft.Application.Features.ContactMessage.Commands.CreateContactMessage;
using Beldsoft.Application.Features.ContactMessage.Results;
using Beldsoft.MVC.ViewModels.Contact;

namespace Beldsoft.MVC.Mapping
{
    public class ContactMappingProfile : Profile
    {
        public ContactMappingProfile()
        {
            CreateMap<ContactMessageCreateViewModel, CreateContactMessageCommand>();
            CreateMap<GetAllContactMessagesResult, ContactMessageGetAllViewModel>().ReverseMap();

        }
    }
}
