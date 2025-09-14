using AutoMapper;
using Beldsoft.Application.Features.Child.Queries.GetChildrenByParentPhone;
using Beldsoft.MVC.ViewModels.Child;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Controllers
{
    public class FamilyController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FamilyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("veli")]
        public IActionResult Index()
        {
            return View();
        }

        // Telefon numarasına göre çocukları getir
        [HttpGet("veli/children")]
        public async Task<IActionResult> GetChildren(string parentPhone)
        {
            if (string.IsNullOrWhiteSpace(parentPhone))
                return Json(new List<ChildByParentPhoneViewModel>());

            var query = new GetChildrenByParentPhoneQuery(parentPhone);
            var response = await _mediator.Send(query);

            var model = response.Data != null
                ? _mapper.Map<List<ChildByParentPhoneViewModel>>(response.Data)
                : new List<ChildByParentPhoneViewModel>();

            return Json(model);
        }

    }
}
