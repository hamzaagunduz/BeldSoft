using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class GradeComponentPartilal : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
