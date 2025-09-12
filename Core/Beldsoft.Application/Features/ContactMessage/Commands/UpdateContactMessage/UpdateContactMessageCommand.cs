using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ContactMessage.Commands.UpdateContactMessage
{
    public class UpdateContactMessageCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        // G�nderen bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Mesaj i�eri�i
        public string? Message { get; set; }
    }
}
