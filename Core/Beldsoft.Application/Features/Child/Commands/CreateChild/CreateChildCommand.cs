using Beldsoft.Application.Responses;
using MediatR;
using System;

namespace Beldsoft.Application.Features.Child.Commands.CreateChild
{
    public class CreateChildCommand : IRequest<CommonResponse<int>>
    {
        // Çocuk bilgileri
        public string? FirstName { get; set; }        // Ad
        public string? LastName { get; set; }         // Soyad
        public string? ParentPhone { get; set; }      // Veli telefonu

        // Giriþ bilgileri
        public DateTime? ArrivalTime { get; set; }    // Geliþ zamaný
        public int? DurationMinutes { get; set; }     // Kalýþ süresi (dk)
    }
}
