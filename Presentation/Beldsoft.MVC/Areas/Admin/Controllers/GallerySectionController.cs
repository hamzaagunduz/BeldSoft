using AutoMapper;
using Beldsoft.Application.Features.GallerySection.Commands.UpdateGallerySection;
using Beldsoft.Application.Features.GallerySection.Queries.GetAllGallerySections;
using Beldsoft.Application.Features.GallerySection.Queries.GetGallerySectionById;
using Beldsoft.Application.Interfaces.IFileService;
using Beldsoft.MVC.ViewModels.GallerySection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class GallerySectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public GallerySectionController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllGallerySectionsQuery());
            if (!response.Succeeded || response.Data == null)
                return View(new List<GallerySectionGetAllViewModel>());

            var model = _mapper.Map<List<GallerySectionGetAllViewModel>>(response.Data);
            return View(model);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetGallerySectionByIdQuery(id));
            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<GallerySectionUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(GallerySectionUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Görsel işlemleri
            string imageUrl1 = model.ImageUrl1;
            string imageUrl2 = model.ImageUrl2;
            string imageUrl3 = model.ImageUrl3;
            string imageUrl4 = model.ImageUrl4;

            if (model.Image1 != null)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl1))
                    await _fileService.DeleteFileAsync(model.ImageUrl1);

                imageUrl1 = await _fileService.UploadFileAsync(model.Image1, "uploads/gallery");
            }

            if (model.Image2 != null)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl2))
                    await _fileService.DeleteFileAsync(model.ImageUrl2);

                imageUrl2 = await _fileService.UploadFileAsync(model.Image2, "uploads/gallery");
            }

            if (model.Image3 != null)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl3))
                    await _fileService.DeleteFileAsync(model.ImageUrl3);

                imageUrl3 = await _fileService.UploadFileAsync(model.Image3, "uploads/gallery");
            }

            if (model.Image4 != null)
            {
                if (!string.IsNullOrEmpty(model.ImageUrl4))
                    await _fileService.DeleteFileAsync(model.ImageUrl4);

                imageUrl4 = await _fileService.UploadFileAsync(model.Image4, "uploads/gallery");
            }

            var command = _mapper.Map<UpdateGallerySectionCommand>(model);
            command.ImageUrl1 = imageUrl1;
            command.ImageUrl2 = imageUrl2;
            command.ImageUrl3 = imageUrl3;
            command.ImageUrl4 = imageUrl4;

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
