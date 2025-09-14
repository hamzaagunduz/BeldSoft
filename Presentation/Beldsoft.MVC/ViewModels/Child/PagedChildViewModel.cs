namespace Beldsoft.MVC.ViewModels.Child
{
    public class PagedChildViewModel
    {
        public List<GetAllChildForTodayViewModel> Children { get; set; } = new();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
    }
}
