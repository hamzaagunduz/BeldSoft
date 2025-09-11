using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Threading.Tasks;
using Beldsoft.Application.Features.GallerySection.Queries.GetAllGallerySections;
using Beldsoft.MVC.ViewModels.GallerySection;
using System.Linq;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class GalleryComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GalleryComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllGallerySectionsQuery());

            if (!result.Succeeded || result.Data == null || !result.Data.Any())
                return View(null);

            // Tek satır veriyi al
            var gallery = result.Data.First();
            var model = _mapper.Map<GallerySectionGetAllViewModel>(gallery);

            return View(model);
        }
    }
}
