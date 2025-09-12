using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.ViewComponents.ContactComponents
{
    public class ContactMapComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
