using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Beldsoft.Application.Features.AppUsers.Results;
using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Responses;

namespace Beldsoft.Application.Features.AppUsers.Queries.GetAppUserById
{
    public class GetAppUserByIdQueryHandler : IRequestHandler<GetAppUserByIdQuery, CommonResponse<GetAppUserByIdResult>>
    {
        private readonly UserManager<AppUser> _userManager;

        public GetAppUserByIdQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CommonResponse<GetAppUserByIdResult>> Handle(GetAppUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());

            if (user == null)
                return CommonResponse<GetAppUserByIdResult>.Fail(new[] { "Kullanıcı bulunamadı." });

            var result = new GetAppUserByIdResult
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return CommonResponse<GetAppUserByIdResult>.Success(result);
        }
    }
}
