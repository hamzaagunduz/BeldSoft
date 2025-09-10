using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AppUsers.Commands.UpdateAppUser
{
    public class UpdateAppUserCommandHandler : IRequestHandler<UpdateAppUserCommand, CommonResponse<bool>>
    {
        private readonly UserManager<AppUser> _userManager;

        public UpdateAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommonResponse<bool>> Handle(UpdateAppUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
                return CommonResponse<bool>.Fail(new[] { "Kullanýcý bulunamadý." });

            user.Email = request.Email;
            user.Name = request.Name;
            user.Surname = request.Surname;
            user.PhoneNumber = request.PhoneNumber;

            var updateResult = await _userManager.UpdateAsync(user);
            if (!updateResult.Succeeded)
                return CommonResponse<bool>.Fail(updateResult.Errors.Select(e => e.Description));

            if (!string.IsNullOrEmpty(request.Password))
            {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passResult = await _userManager.ResetPasswordAsync(user, token, request.Password);
                if (!passResult.Succeeded)
                    return CommonResponse<bool>.Fail(passResult.Errors.Select(e => e.Description));
            }

            // Rol güncellemesi
            if (!string.IsNullOrEmpty(request.Role))
            {
                var currentRoles = await _userManager.GetRolesAsync(user);
                var removeResult = await _userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                    return CommonResponse<bool>.Fail(removeResult.Errors.Select(e => e.Description));

                var addResult = await _userManager.AddToRoleAsync(user, request.Role);
                if (!addResult.Succeeded)
                    return CommonResponse<bool>.Fail(addResult.Errors.Select(e => e.Description));
            }

            return CommonResponse<bool>.Success(true);
        }

    }
}
