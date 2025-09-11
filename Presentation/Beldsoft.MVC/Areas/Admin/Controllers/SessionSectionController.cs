using AutoMapper;
using Beldsoft.Application.Features.SessionSection.Commands.UpdateSessionSection;
using Beldsoft.Application.Features.SessionSection.Queries.GetSessionSectionById;
using Beldsoft.Application.Features.SessionSection.Queries.GetAllSessionSections;
using Beldsoft.Application.Interfaces.IFileService;
using Beldsoft.MVC.ViewModels.SessionSection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class SessionSectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public SessionSectionController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllSessionSectionsQuery());
            if (!response.Succeeded || response.Data == null)
                return View(new List<SessionSectionGetAllViewModel>());

            var model = _mapper.Map<List<SessionSectionGetAllViewModel>>(response.Data);
            return View(model);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetSessionSectionByIdQuery(id));

            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<SessionSectionUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(SessionSectionUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Icon alanlarında dosya yükleme yapılacaksa buraya ekleyebilirsin
            // (AboutSection'daki BigImage/SmallImage gibi)

            var command = _mapper.Map<UpdateSessionSectionCommand>(model);

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
