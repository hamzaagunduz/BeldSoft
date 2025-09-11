using AutoMapper;
using Beldsoft.Application.Features.AboutSection.Commands.UpdateAboutSection;
using Beldsoft.Application.Features.AboutSection.Queries.GetAboutSectionById;
using Beldsoft.MVC.ViewModels.AboutSection;
using Beldsoft.Application.Interfaces.IFileService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Beldsoft.Application.Features.ServiceSection.Queries.GetAllServiceSections;
using Beldsoft.Application.Features.AboutSection.Queries.GetAllAboutSections;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class AboutSectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllAboutSectionsQuery()); // bu query'i yazman lazım
            if (!response.Succeeded || response.Data == null)
                return View(new List<AboutSectionGetAllViewModel>());

            var model = _mapper.Map<List<AboutSectionGetAllViewModel>>(response.Data);
            return View(model);
        }


        public AboutSectionController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetAboutSectionByIdQuery(id));

            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<AboutSectionUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(AboutSectionUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Resim işlemleri
            string bigImageUrl = model.BigImageUrl;
            string smallImageUrl = model.SmallImageUrl;

            if (model.BigImage != null)
            {
                if (!string.IsNullOrEmpty(model.BigImageUrl))
                    await _fileService.DeleteFileAsync(model.BigImageUrl);

                bigImageUrl = await _fileService.UploadFileAsync(model.BigImage, "uploads/about");
            }

            if (model.SmallImage != null)
            {
                if (!string.IsNullOrEmpty(model.SmallImageUrl))
                    await _fileService.DeleteFileAsync(model.SmallImageUrl);

                smallImageUrl = await _fileService.UploadFileAsync(model.SmallImage, "uploads/about");
            }

            var command = _mapper.Map<UpdateAboutSectionCommand>(model);
            command.BigImageUrl = bigImageUrl;
            command.SmallImageUrl = smallImageUrl;

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
