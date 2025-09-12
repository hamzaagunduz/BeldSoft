using AutoMapper;
using Beldsoft.Application.Features.SiteSettings.Commands.UpdateSiteSettings;
using Beldsoft.Application.Features.SiteSettings.Queries.GetAllSiteSettings;
using Beldsoft.Application.Features.SiteSettings.Queries.GetSiteSettingsById;
using Beldsoft.Application.Interfaces.IFileService;
using Beldsoft.MVC.ViewModels.SiteSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class SiteSettingsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public SiteSettingsController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllSiteSettingsQuery());
            if (!response.Succeeded || response.Data == null)
                return View(new List<SiteSettingsGetAllViewModel>());

            var model = _mapper.Map<List<SiteSettingsGetAllViewModel>>(response.Data);
            return View(model);
        }


        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetSiteSettingsByIdQuery(id));
            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<SiteSettingsUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(SiteSettingsUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Logo işlemi
            string logoUrl = model.LogoUrl;

            if (model.LogoFile != null)
            {
                if (!string.IsNullOrEmpty(model.LogoUrl))
                    await _fileService.DeleteFileAsync(model.LogoUrl);

                logoUrl = await _fileService.UploadFileAsync(model.LogoFile, "uploads/logos");
            }

            var command = _mapper.Map<UpdateSiteSettingsCommand>(model);
            command.LogoUrl = logoUrl;

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
