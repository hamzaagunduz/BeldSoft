namespace Beldsoft.MVC.ViewModels.AppUsers
{
    public class PagedAppUserListViewModel
    {
        public List<AppUserListViewModel> Users { get; set; }
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public int TotalPages => (int)Math.Ceiling((double)TotalCount / PageSize);
    }
}
