using System;

namespace Beldsoft.Application.Features.ContactMessage.Results
{
    public class GetContactMessageByIdResult
    {
        public int? Id { get; set; }

        // G�nderen bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Mesaj i�eri�i
        public string? Message { get; set; }

        // Olu�turulma tarihi
        public DateTime? CreatedDate { get; set; }
    }
}
