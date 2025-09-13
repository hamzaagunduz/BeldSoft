using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Results
{
    public class GetAllChildForTodayResult
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? ParentPhone { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public int? DurationMinutes { get; set; }
        public bool? IsExpired { get; set; }
    }
}
