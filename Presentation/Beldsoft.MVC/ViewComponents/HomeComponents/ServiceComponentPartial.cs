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
    public class ServiceComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ServiceComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllServiceSectionsQuery());

            if (!result.Succeeded || result.Data == null)
                return View(Enumerable.Empty<ServiceSectionGetAllViewModel>());

            var model = _mapper.Map<List<ServiceSectionGetAllViewModel>>(result.Data);

            return View(model);
        }
    }
}
