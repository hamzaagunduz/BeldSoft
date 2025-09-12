using System;

namespace Beldsoft.MVC.ViewModels.Contact
{
    public class ContactMessageGetAllViewModel
    {
        public int? Id { get; set; }

        // Gönderen bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }

        // Mesaj içeriği
        public string? Message { get; set; }

        // Oluşturulma tarihi
        public DateTime? CreatedDate { get; set; }
    }
}
