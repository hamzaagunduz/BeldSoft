using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Features.AppUsers.Results;
using Beldsoft.Application.Interfaces.IAppUserRepository;
using Beldsoft.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Beldsoft.Application.Features.AppUsers.Queries.GetPagedAppUsers
{
    public class GetPagedAppUsersQueryHandler
        : IRequestHandler<GetPagedAppUsersQuery, CommonResponse<List<GetPagedAppUsersResult>>>
    {
        private readonly IAppUserRepository _appUserRepository;
        private readonly UserManager<AppUser> _userManager;

        public GetPagedAppUsersQueryHandler(IAppUserRepository appUserRepository, UserManager<AppUser> userManager)
        {
            _appUserRepository = appUserRepository;
            _userManager = userManager;
        }

        public async Task<CommonResponse<List<GetPagedAppUsersResult>>> Handle(GetPagedAppUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _appUserRepository.GetPagedUsersAsync(request.PageNumber, request.PageSize);
            var totalCount = await _appUserRepository.GetUserCountAsync();

            var userResults = new List<GetAllAppUsersResult>();

            foreach (var u in users)
            {
                var roles = await _userManager.GetRolesAsync(u); // Rolleri al
                userResults.Add(new GetAllAppUsersResult
                {
                    UserId = u.Id,
                    UserName = u.UserName,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Name = u.Name,
                    Surname = u.Surname,
                    Role = roles.FirstOrDefault() 
                });
            }

            var result = new GetPagedAppUsersResult
            {
                Users = userResults,
                TotalCount = totalCount
            };

            return CommonResponse<List<GetPagedAppUsersResult>>.Success(new List<GetPagedAppUsersResult> { result });
        }
    }
}
