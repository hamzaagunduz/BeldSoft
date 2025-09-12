using System;

namespace Beldsoft.Application.Features.ContactMessage.Results
{
    public class GetContactMessageByIdResult
    {
        public int? Id { get; set; }

        // Gönderen bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Mesaj içeriði
        public string? Message { get; set; }

        // Oluþturulma tarihi
        public DateTime? CreatedDate { get; set; }
    }
}
