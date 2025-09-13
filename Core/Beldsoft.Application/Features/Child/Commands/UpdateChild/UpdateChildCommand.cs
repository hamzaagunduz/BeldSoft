using Beldsoft.Application.Responses;
using MediatR;
using System;

namespace Beldsoft.Application.Features.Child.Commands.UpdateChild
{
    public class UpdateChildCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        // �ocuk bilgileri
        public string? FirstName { get; set; }        // Ad
        public string? LastName { get; set; }         // Soyad
        public string? ParentPhone { get; set; }      // Veli telefonu

        // Giri� bilgileri
        public DateTime? ArrivalTime { get; set; }    // Geli� zaman�
        public int? DurationMinutes { get; set; }     // Kal�� s�resi (dk)
        public bool? IsExpired { get; set; }          // S�re doldu mu?
    }
}
