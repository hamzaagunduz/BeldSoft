using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using Beldsoft.Application.Features.HeroSection.Queries.GetAllHeroSections;
using Beldsoft.MVC.ViewModels.HeroSection;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class HeroComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public HeroComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllHeroSectionsQuery());

            if (!result.Succeeded || result.Data == null)
                return View(Enumerable.Empty<HeroSectionGetAllViewModel>());

            var model = _mapper.Map<List<HeroSectionGetAllViewModel>>(result.Data);

            return View(model);
        }
    }
}
