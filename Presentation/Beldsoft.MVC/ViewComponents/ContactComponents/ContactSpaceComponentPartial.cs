using AutoMapper;
using Beldsoft.Application.Features.SiteSettings.Queries.GetAllSiteSettings;
using Beldsoft.MVC.ViewModels.SiteSettings;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Beldsoft.MVC.ViewComponents.ContactComponents
{
    public class ContactSpaceComponentPartial : ViewComponent
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ContactSpaceComponentPartial(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var result = await _mediator.Send(new GetAllSiteSettingsQuery());

            if (!result.Succeeded || result.Data == null || !result.Data.Any())
                return View(null);

            // Tek satır veri al
            var settings = result.Data.First();
            var model = _mapper.Map<SiteSettingsGetAllViewModel>(settings);

            return View(model);
        }
    }
}
