using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using Beldsoft.Application.Features.SessionSection.Queries.GetAllSessionSections;
using Beldsoft.MVC.ViewModels.SessionSection;
using System.Collections.Generic;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class SessionComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SessionComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllSessionSectionsQuery());

            if (!result.Succeeded || result.Data == null)
                return View(Enumerable.Empty<SessionSectionGetAllViewModel>());

            var model = _mapper.Map<SessionSectionGetAllViewModel>(result.Data.First());

            return View(model);
        }
    }
}
