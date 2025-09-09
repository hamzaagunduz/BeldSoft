using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AppUsers.Queries.GetAllAppUsers
{
    public class GetAllAppUsersQueryHandler : IRequestHandler<GetAllAppUsersQuery, CommonResponse<List<GetAllAppUsersResult>>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAllAppUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public Task<CommonResponse<List<GetAllAppUsersResult>>> Handle(GetAllAppUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _userManager.Users.Select(u => new GetAllAppUsersResult
            {
                UserId = u.Id,
                UserName = u.UserName,
                Email = u.Email
            }).ToList();

            return Task.FromResult(CommonResponse<List<GetAllAppUsersResult>>.Success(users));
        }
    }
}
