using AutoMapper;
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
    public class FullChildController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FullChildController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 25)
        {
            var query = new GetPagedChildQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            if (!response.Succeeded || response.Data == null)
                return View(new PagedChildViewModel());

            var model = new PagedChildViewModel
            {
                Children = _mapper.Map<List<GetAllChildForTodayViewModel>>(response.Data.Children),
                CurrentPage = response.Data.CurrentPage,
                PageSize = response.Data.PageSize,
                TotalCount = response.Data.TotalCount,
                TotalPages = response.Data.TotalPages
            };

            return View(model);
        }

    }
}
