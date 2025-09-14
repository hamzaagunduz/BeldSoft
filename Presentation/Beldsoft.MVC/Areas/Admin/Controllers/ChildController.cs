using AutoMapper;
using Beldsoft.Application.Features.Child.Commands.CreateChild;
using Beldsoft.Application.Features.Child.Commands.DeleteChild;
using Beldsoft.Application.Features.Child.Commands.UpdateChild;
using Beldsoft.Application.Features.Child.Queries.GetAllChild;
using Beldsoft.Application.Features.Child.Queries.GetAllChildForToday;
using Beldsoft.Application.Features.Child.Queries.GetChildById;
using Beldsoft.Application.Features.Child.Queries.GetPagedChild;
using Beldsoft.MVC.ViewModels.Child;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")]
    public class ChildController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ChildController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var query = new GetAllChildForTodayQuery();
            var response = await _mediator.Send(query);

            var model = _mapper.Map<List<GetAllChildForTodayViewModel>>(response.Data);
            return View(model);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ChildCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var command = _mapper.Map<CreateChildCommand>(model);
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
            var response = await _mediator.Send(new GetChildByIdQuery(id));
            if (!response.Succeeded || response.Data == null)
                return NotFound();

            var model = _mapper.Map<ChildUpdateViewModel>(response.Data);
            return View(model);
        }

        [HttpPost("Edit")]
        public async Task<IActionResult> Edit(ChildUpdateViewModel model)
        {
            var command = _mapper.Map<UpdateChildCommand>(model);
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error);

                return View(model);
            }

            return RedirectToAction("Index", "Child", new { area = "Admin" });
        }



        [HttpPost("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteChildCommand(id));

            if (!result.Succeeded)
            {
                TempData["Error"] = string.Join(", ", result.Errors);
                return RedirectToAction(nameof(Index));
            }

            TempData["Success"] = "Çocuk kaydı başarıyla silindi.";
            return RedirectToAction(nameof(Index));
        }



    }
}
