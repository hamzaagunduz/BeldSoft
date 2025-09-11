using AutoMapper;
using Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection;
using Beldsoft.MVC.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Beldsoft.Infrastructure.Services;
using Beldsoft.Application.Interfaces.IFileService;
using Beldsoft.MVC.ViewModels.HeroSection;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HeroSectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public HeroSectionController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(HeroSectionViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string smallImageUrl = null;
            string bigImageUrl = null;

            if (model.SmallImage != null)
                smallImageUrl = await _fileService.UploadFileAsync(model.SmallImage, "uploads/hero");

            if (model.BigImage != null)
                bigImageUrl = await _fileService.UploadFileAsync(model.BigImage, "uploads/hero");

            // ViewModel -> Command
            var command = _mapper.Map<CreateHeroSectionCommand>(model);
            command.SmallImageUrl = smallImageUrl;
            command.BigImageUrl = bigImageUrl;

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
