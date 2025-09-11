using AutoMapper;
using Beldsoft.Application.Features.FeedbackSection.Commands.UpdateFeedbackSection;
using Beldsoft.Application.Features.FeedbackSection.Queries.GetAllFeedbackSections;
using Beldsoft.Application.Features.FeedbackSection.Queries.GetFeedbackSectionById;
using Beldsoft.Application.Interfaces.IFileService;
using Beldsoft.MVC.ViewModels.FeedbackSection;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class FeedbackSectionController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IFileService _fileService;

        public FeedbackSectionController(IMediator mediator, IMapper mapper, IFileService fileService)
        {
            _mediator = mediator;
            _mapper = mapper;
            _fileService = fileService;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var response = await _mediator.Send(new GetAllFeedbackSectionsQuery());
            if (!response.Succeeded || response.Data == null)
                return View(new List<FeedbackSectionGetAllViewModel>());

            var model = _mapper.Map<List<FeedbackSectionGetAllViewModel>>(response.Data);
            return View(model);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _mediator.Send(new GetFeedbackSectionByIdQuery(id));
            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<FeedbackSectionUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(FeedbackSectionUpdateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // Görsel işlemleri
            string bigImageUrl = model.BigImageUrl;
            string userImageUrl1 = model.UserImageUrl1;
            string userImageUrl2 = model.UserImageUrl2;
            string userImageUrl3 = model.UserImageUrl3;

            if (model.BigImage != null)
            {
                if (!string.IsNullOrEmpty(model.BigImageUrl))
                    await _fileService.DeleteFileAsync(model.BigImageUrl);

                bigImageUrl = await _fileService.UploadFileAsync(model.BigImage, "uploads/feedback");
            }

            if (model.UserImage1 != null)
            {
                if (!string.IsNullOrEmpty(model.UserImageUrl1))
                    await _fileService.DeleteFileAsync(model.UserImageUrl1);

                userImageUrl1 = await _fileService.UploadFileAsync(model.UserImage1, "uploads/feedback");
            }

            if (model.UserImage2 != null)
            {
                if (!string.IsNullOrEmpty(model.UserImageUrl2))
                    await _fileService.DeleteFileAsync(model.UserImageUrl2);

                userImageUrl2 = await _fileService.UploadFileAsync(model.UserImage2, "uploads/feedback");
            }

            if (model.UserImage3 != null)
            {
                if (!string.IsNullOrEmpty(model.UserImageUrl3))
                    await _fileService.DeleteFileAsync(model.UserImageUrl3);

                userImageUrl3 = await _fileService.UploadFileAsync(model.UserImage3, "uploads/feedback");
            }

            var command = _mapper.Map<UpdateFeedbackSectionCommand>(model);
            command.BigImageUrl = bigImageUrl;
            command.UserImageUrl1 = userImageUrl1;
            command.UserImageUrl2 = userImageUrl2;
            command.UserImageUrl3 = userImageUrl3;

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
