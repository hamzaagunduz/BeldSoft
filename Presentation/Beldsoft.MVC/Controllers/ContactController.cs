using AutoMapper;
using Beldsoft.Application.Features.ContactMessage.Commands.CreateContactMessage;
using Beldsoft.MVC.ViewModels.Contact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("iletisim")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ContactSpaceViewModel model)
        {
            // ContactMessage property’si üzerinden al
            var command = _mapper.Map<CreateContactMessageCommand>(model.ContactMessage);

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error);

                // SiteSettings eksik olmaması için yeniden doldur
                // Örn: var siteSettings = await _mediator.Send(new GetAllSiteSettingsQuery());
                return View(model);
            }

            TempData["SuccessMessage"] = "Mesajınız başarıyla gönderildi!";
            return RedirectToAction(nameof(Index));
        }

    }
}
