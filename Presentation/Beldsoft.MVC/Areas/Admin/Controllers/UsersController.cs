using AutoMapper;
using Beldsoft.Application.Features.AppUsers.Commands.CreateAppUser;
using Beldsoft.Application.Features.AppUsers.Commands.DeleteAppUser;
using Beldsoft.Application.Features.AppUsers.Commands.UpdateAppUser;
using Beldsoft.Application.Features.AppUsers.Queries.GetPagedAppUsers;
using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.MVC.ViewModels.AppUsers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace Beldsoft.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("admin/[controller]")] 
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpGet("")]
        public IActionResult Index()
        {
            // İlk yüklemede model boş olabilir, AJAX tablodan dolduracak
            var emptyModel = new PagedAppUserListViewModel
            {
                Users = new List<AppUserListViewModel>(),
                PageNumber = 1,
                PageSize = 5,
                TotalCount = 0
            };

            return View(emptyModel);
        }


        [HttpGet("GetPagedUsers")]
        public async Task<IActionResult> GetPagedUsers(int pageNumber = 1, int pageSize = 5)
        {
            var query = new GetPagedAppUsersQuery
            {
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            var response = await _mediator.Send(query);

            if (!response.Succeeded)
                return Json(new { success = false });

            var data = response.Data.First();

            var model = new PagedAppUserListViewModel
            {
                Users = _mapper.Map<List<AppUserListViewModel>>(data.Users),
                TotalCount = data.TotalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return PartialView("~/Areas/Admin/Views/Shared/Components/UsersTable/Default.cshtml", model);

        }



        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser([FromForm] AppUserCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<CreateAppUserCommand>(model);
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok(new { success = true });
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteAppUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { success = true });
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromForm] AppUserEditViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var command = _mapper.Map<UpdateAppUserCommand>(model);

            var result = await _mediator.Send(command);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            return Ok(new { success = true });
        }


    }
}
