using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using Beldsoft.Application.Features.HeroSection.Queries.GetAllHeroSections;
using Beldsoft.MVC.ViewModels.HeroSection;
using Beldsoft.Application.Features.AboutSection.Queries.GetAllAboutSections;
using Beldsoft.MVC.ViewModels.AboutSection;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class AboutComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AboutComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllAboutSectionsQuery());

            if (!result.Succeeded || result.Data == null)
                return View(Enumerable.Empty<AboutSectionGetAllViewModel>());

            var model = _mapper.Map<List<AboutSectionGetAllViewModel>>(result.Data);

            return View(model);
        }
    }
}
