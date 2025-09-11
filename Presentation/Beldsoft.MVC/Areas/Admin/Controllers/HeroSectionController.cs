using AutoMapper;
using Beldsoft.Application.Features.HeroSection.Commands.CreateHeroSection;
using Beldsoft.MVC.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Beldsoft.Infrastructure.Services;
using Beldsoft.Application.Interfaces.IFileService;
using Beldsoft.MVC.ViewModels.HeroSection;
using Beldsoft.MVC.ViewModels.AppUsers;
using Beldsoft.Application.Features.HeroSection.Commands.UpdateHeroSection;
using Beldsoft.Application.Features.HeroSection.Queries.GetHeroSectionById;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]

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

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllHeroSectionsQuery();
            var response = await _mediator.Send(query);

            // AutoMapper ile map et
            var model = _mapper.Map<List<HeroSectionGetAllViewModel>>(response.Data);

            return View(model);
        }
        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(HeroSectionCreateViewModel model)
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


        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetHeroSectionByIdQuery(id));

            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<HeroSectionUpdateViewModel>(response.Data);
            return View(model);
        }


        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(HeroSectionUpdateViewModel model)
        {
            string smallImageUrl = model.SmallImageUrl;
            string bigImageUrl = model.BigImageUrl;

            if (model.SmallImage != null)
            {
                if (!string.IsNullOrEmpty(model.SmallImageUrl))
                    await _fileService.DeleteFileAsync(model.SmallImageUrl);

                smallImageUrl = await _fileService.UploadFileAsync(model.SmallImage, "uploads/hero");
            }

            if (model.BigImage != null)
            {
                if (!string.IsNullOrEmpty(model.BigImageUrl))
                    await _fileService.DeleteFileAsync(model.BigImageUrl);

                bigImageUrl = await _fileService.UploadFileAsync(model.BigImage, "uploads/hero");
            }

            var command = _mapper.Map<UpdateHeroSectionCommand>(model);
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
