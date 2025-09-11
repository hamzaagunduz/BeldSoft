using AutoMapper;
using Beldsoft.Application.Features.ServiceSection.Commands.CreateServiceSection;

using Beldsoft.MVC.ViewModels.ServiceSection;
using Beldsoft.Application.Interfaces.IFileService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beldsoft.Application.Features.ServiceSection.Queries.GetAllServiceSections;
using Beldsoft.Application.Features.ServiceSection.Results;
using Beldsoft.MVC.ViewModels.HeroSection;
using Beldsoft.Application.Features.ServiceSection.Queries.GetServiceSectionById;
using Beldsoft.Application.Features.ServiceSection.Commands.UpdateServiceSection;
using Beldsoft.Application.Features.ServiceSection.Commands.DeleteServiceSection;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ServiceSectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public ServiceSectionController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllServiceSectionsQuery();
            var response = await _mediator.Send(query);

            var model = _mapper.Map<List<ServiceSectionGetAllViewModel>>(response.Data);

            return View(model);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ServiceSectionCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string imageUrl = null;
            if (model.Image != null)
                imageUrl = await _fileService.UploadFileAsync(model.Image, "uploads/service");

            var command = _mapper.Map<CreateServiceSectionCommand>(model);
            command.ImageUrl = imageUrl;

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
            var response = await _mediator.Send(new GetServiceSectionByIdQuery(id));

            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<ServiceSectionUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(ServiceSectionUpdateViewModel model)
        {
            string imageUrl = model.ImageUrl;

            if (model.Image != null)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl))
                    await _fileService.DeleteFileAsync(model.ImageUrl);

                imageUrl = await _fileService.UploadFileAsync(model.Image, "uploads/service");
            }

            var command = _mapper.Map<UpdateServiceSectionCommand>(model);
            command.ImageUrl = imageUrl;

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(model);
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteServiceSectionCommand(id));

            if (!result.Succeeded)
            {
                TempData["Error"] = string.Join(", ", result.Errors);
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Service Section başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }
    }
}
