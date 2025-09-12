using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.ContactComponents
{
    public class ContactTopComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
