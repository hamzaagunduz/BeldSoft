using Beldsoft.Application.Responses;
using Bedldsoft.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AppUsers.Commands.CreateAppUser
{
    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, CommonResponse<int>>
    {
        private readonly UserManager<AppUser> _userManager;

        public CreateAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommonResponse<int>> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = new AppUser
            {
                UserName = Guid.NewGuid().ToString("N"),
                Name = request.Name,
                Surname = request.Surname,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return CommonResponse<int>.Fail(result.Errors.Select(e => e.Description));

            var roleResult = await _userManager.AddToRoleAsync(user, "User"); 

            if (!roleResult.Succeeded)
                return CommonResponse<int>.Fail(roleResult.Errors.Select(e => e.Description));

            return CommonResponse<int>.Success(user.Id);
        }
    }
}
