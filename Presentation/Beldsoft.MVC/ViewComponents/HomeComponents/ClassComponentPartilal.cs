using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class ClassComponentPartilal : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
