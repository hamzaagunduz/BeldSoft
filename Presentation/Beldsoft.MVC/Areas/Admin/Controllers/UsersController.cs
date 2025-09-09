using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")] // sadece admin girebilir
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
