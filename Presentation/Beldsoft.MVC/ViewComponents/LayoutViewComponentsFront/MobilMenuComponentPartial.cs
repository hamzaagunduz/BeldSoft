using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.LayoutViewComponentsFront
{
    public class MobilMenuComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml çağrılır
        }
    }
}
