using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.LayoutViewComponentsFront
{
    public class FrontFooterComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml çağrılır
        }
    }
}
