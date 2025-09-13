using Beldsoft.Application.Responses;
using MediatR;
using System;

namespace Beldsoft.Application.Features.Child.Commands.CreateChild
{
    public class CreateChildCommand : IRequest<CommonResponse<int>>
    {
        // �ocuk bilgileri
        public string? FirstName { get; set; }        // Ad
        public string? LastName { get; set; }         // Soyad
        public string? ParentPhone { get; set; }      // Veli telefonu

        // Giri� bilgileri
        public DateTime? ArrivalTime { get; set; }    // Geli� zaman�
        public int? DurationMinutes { get; set; }     // Kal�� s�resi (dk)
    }
}
