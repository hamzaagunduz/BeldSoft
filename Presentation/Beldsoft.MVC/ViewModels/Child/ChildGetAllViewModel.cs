using System;

namespace Beldsoft.MVC.ViewModels.Child
{
    public class ChildGetAllViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentPhone { get; set; }
        public DateTime? ArrivalTime { get; set; }
        public int? DurationMinutes { get; set; }
        public bool? IsExpired { get; set; }
    }
}
