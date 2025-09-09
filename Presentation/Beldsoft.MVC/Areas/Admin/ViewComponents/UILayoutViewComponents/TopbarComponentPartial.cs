using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.Areas.Admin.ViewComponents.UILayoutViewComponents
{
    public class TopbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml çağrılır
        }
    }
}
