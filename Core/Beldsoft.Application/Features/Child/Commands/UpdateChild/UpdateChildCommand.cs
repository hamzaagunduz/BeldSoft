using Beldsoft.Application.Responses;
using MediatR;
using System;

namespace Beldsoft.Application.Features.Child.Commands.UpdateChild
{
    public class UpdateChildCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        // Çocuk bilgileri
        public string? FirstName { get; set; }        // Ad
        public string? LastName { get; set; }         // Soyad
        public string? ParentPhone { get; set; }      // Veli telefonu

        // Giriþ bilgileri
        public DateTime? ArrivalTime { get; set; }    // Geliþ zamaný
        public int? DurationMinutes { get; set; }     // Kalýþ süresi (dk)
        public bool? IsExpired { get; set; }          // Süre doldu mu?
    }
}
