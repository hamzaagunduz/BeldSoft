using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class HeroComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml çağrılır
        }
    }
}
