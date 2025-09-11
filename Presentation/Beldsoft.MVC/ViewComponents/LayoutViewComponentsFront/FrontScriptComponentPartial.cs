using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.LayoutViewComponentsFront
{
    public class FrontScriptComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml çağrılır
        }
    }
}
