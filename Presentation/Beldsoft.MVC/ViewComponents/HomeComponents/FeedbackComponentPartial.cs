using MediatR;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using System.Linq;
using System.Threading.Tasks;
using Beldsoft.Application.Features.FeedbackSection.Queries.GetAllFeedbackSections;
using Beldsoft.MVC.ViewModels.FeedbackSection;

namespace Beldsoft.MVC.ViewComponents.HomeComponents
{
    public class FeedbackComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FeedbackComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllFeedbackSectionsQuery());

            if (!result.Succeeded || result.Data == null || !result.Data.Any())
                return View(null);

            // Tek satır veriyi al
            var feedback = result.Data.First();
            var model = _mapper.Map<FeedbackSectionGetAllViewModel>(feedback);

            return View(model);
        }
    }
}
