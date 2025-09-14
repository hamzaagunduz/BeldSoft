using AutoMapper;
using Beldsoft.Application.Features.AppUsers.Commands.CreateAppUser;
using Beldsoft.Application.Features.AppUsers.Queries.GetAllAppUsers;
using Beldsoft.MVC.ViewModels.AppUsers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace Beldsoft.MVC.Controllers
{
    public class AppUserController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public AppUserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        // Listeleme
        public async Task<IActionResult> Index()
        {
            var users = await _mediator.Send(new GetAllAppUsersQuery());
            var model = _mapper.Map<List<AppUserListViewModel>>(users);
            return View(model);
        }


    }
}
