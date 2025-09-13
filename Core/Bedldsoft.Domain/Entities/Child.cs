using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bedldsoft.Domain.Entities
{
    public class Child
    {
        public int Id { get; set; }                 // Birincil anahtar
        public string? FirstName { get; set; }       // Çocuğun adı
        public string? LastName { get; set; }        // Çocuğun soyadı
        public string ?ParentPhone { get; set; }     // Veli telefon numarası
        public DateTime? ArrivalTime { get; set; }   // Çocuğun geldiği zaman
        public int? DurationMinutes { get; set; }    // Kalacağı süre (dakika cinsinden)
        public bool? IsExpired { get; set; } = false; // Süre doldu mu?
        [NotMapped]
        public DateTime? ExpirationTime
        => ArrivalTime.HasValue && DurationMinutes.HasValue
            ? ArrivalTime.Value.AddMinutes(DurationMinutes.Value)
        : null;
    }
}
