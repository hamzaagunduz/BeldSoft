using System;

namespace Beldsoft.Application.Features.Child.Results
{
    public class GetChildByIdResult
    {
        public int? Id { get; set; }

        // Çocuk bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ParentPhone { get; set; }

        // Giriþ bilgileri
        public DateTime? ArrivalTime { get; set; }
        public int? DurationMinutes { get; set; }
        public bool? IsExpired { get; set; }

        // Oluþturulma tarihi
    }
}
