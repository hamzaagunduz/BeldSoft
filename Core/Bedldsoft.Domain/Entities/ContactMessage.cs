using System;

namespace Beldsoft.Domain.Entities
{
    public class ContactMessage
    {
        public int Id { get; set; }

        // Gönderen bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Mesaj içeriği
        public string? Message { get; set; }

        // Oluşturulma tarihi
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
