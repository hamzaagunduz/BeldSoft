using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ContactMessage.Commands.CreateContactMessage
{
    public class CreateContactMessageCommand : IRequest<CommonResponse<int>>
    {
        // Gönderen bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Mesaj içeriði
        public string? Message { get; set; }
    }
}
