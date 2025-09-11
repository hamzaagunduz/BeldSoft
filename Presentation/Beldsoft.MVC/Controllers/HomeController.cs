using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
