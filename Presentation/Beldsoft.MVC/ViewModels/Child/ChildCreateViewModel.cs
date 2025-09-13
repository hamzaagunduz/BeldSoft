using System;

namespace Beldsoft.MVC.ViewModels.Child
{
    public class ChildCreateViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ParentPhone { get; set; }
        public DateTime ArrivalTime { get; set; }
        public int DurationMinutes { get; set; }
    }
}
