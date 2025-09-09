using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Features.Auth.Results;
using Beldsoft.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Auth.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, CommonResponse<LoginResult>>
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginCommandHandler(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<CommonResponse<LoginResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {

                var user = await _userManager.FindByEmailAsync(request.Email);
                if (user == null)
                    return CommonResponse<LoginResult>.Fail(new[] { "Kullanıcı bulunamadı." });

                var result = await _signInManager.PasswordSignInAsync(user.UserName, request.Password, false, false);
                if (!result.Succeeded)
                    return CommonResponse<LoginResult>.Fail(new[] { "Hatalı şifre." });

                // Kullanıcının rollerini al
                var roles = await _userManager.GetRolesAsync(user);
                var role = roles.Contains("Admin") ? "Admin" : "User"; // veya ihtiyaca göre düzenle

                var loginResult = new LoginResult
                {
                    Success = true,
                    UserId = user.Id,
                    UserName = user.UserName,
                    Role = role
                };

                return CommonResponse<LoginResult>.Success(loginResult);
    
        }
    }
}
