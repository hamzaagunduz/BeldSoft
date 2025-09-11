using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using Beldsoft.Application.Features.ServiceSection.Queries.GetAllServiceSections;
using Beldsoft.MVC.ViewModels.ServiceSection;
using System.Collections.Generic;
using System.Linq;

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

        public IViewComponentResult InvokeAsync()
        {
            return View();
        }

    }
}
