using System;

namespace Beldsoft.Application.Features.Child.Results
{
    public class GetChildByIdResult
    {
        public int? Id { get; set; }

        // �ocuk bilgileri
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ParentPhone { get; set; }

        // Giri� bilgileri
        public DateTime? ArrivalTime { get; set; }
        public int? DurationMinutes { get; set; }
        public bool? IsExpired { get; set; }

        // Olu�turulma tarihi
    }
}
