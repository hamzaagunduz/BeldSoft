using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.Areas.Admin.ViewComponents.UILayoutViewComponents
{
    public class HeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View(); // Default.cshtml çağrılır
        }
    }
}
