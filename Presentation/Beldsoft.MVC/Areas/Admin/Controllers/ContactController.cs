using AutoMapper;
using Beldsoft.Application.Features.ContactMessage.Commands.DeleteContactMessage;
using Beldsoft.Application.Features.ContactMessage.Queries.GetAllContactMessages;
using Beldsoft.MVC.ViewModels.Contact;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]

    public class ContactController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllContactMessagesQuery();
            var response = await _mediator.Send(query);

            var model = _mapper.Map<List<ContactMessageGetAllViewModel>>(response.Data);

            return View(model);
        }

        [HttpPost("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteContactMessageCommand(id);
            var response = await _mediator.Send(command);

            if (!response.Succeeded)
            {
                return BadRequest(response.Errors);
            }

            return RedirectToAction(nameof(Index));
        }

    }
}
