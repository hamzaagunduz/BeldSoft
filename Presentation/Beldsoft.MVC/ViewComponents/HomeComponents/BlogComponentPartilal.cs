using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class BlogComponentPartilal : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
