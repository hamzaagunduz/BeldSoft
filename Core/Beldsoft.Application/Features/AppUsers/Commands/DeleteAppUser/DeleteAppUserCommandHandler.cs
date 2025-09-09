using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AppUsers.Commands.DeleteAppUser
{
    public class DeleteAppUserCommandHandler : IRequestHandler<DeleteAppUserCommand, CommonResponse<bool>>
    {
        private readonly UserManager<AppUser> _userManager;

        public DeleteAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommonResponse<bool>> Handle(DeleteAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return CommonResponse<bool>.Fail(new List<string> { "Kullanýcý bulunamadý." });

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
                return CommonResponse<bool>.Fail(result.Errors.Select(e => e.Description));

            return CommonResponse<bool>.Success(true);
        }
    }
}
