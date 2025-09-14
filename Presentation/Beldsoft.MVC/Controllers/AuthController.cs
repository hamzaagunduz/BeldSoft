using Beldsoft.Application.Features.Auth.Commands.Login;
using Beldsoft.MVC.ViewModels.AppUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Beldsoft.MVC.Controllers
{
    [Route("yonetim")]
    public class AuthController : Controller
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: /yonetim/giris
        [HttpGet("giris")]
        public IActionResult Login()
        {
            return View();
        }

        // POST: /yonetim/giris
        [HttpPost("giris")]
        public async Task<IActionResult> Login(AppUserLoginViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = new LoginCommand
            {
                Email = model.Email,
                Password = model.Password
            };

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }

                return View(model);
            }

            var loginData = result.Data;

            if (loginData.Role == "Admin")
                return RedirectToAction("Index", "Child", new { area = "Admin" });

            return RedirectToAction("Index", "Home");
        }
    }
}
