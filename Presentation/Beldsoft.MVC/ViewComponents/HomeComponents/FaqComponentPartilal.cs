using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class FaqComponentPartilal : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
