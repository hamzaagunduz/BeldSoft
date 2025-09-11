using Beldsoft.Application.Interfaces.ISessionSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.SessionSection.Commands.UpdateSessionSection
{
    public class UpdateSessionSectionCommandHandler : IRequestHandler<UpdateSessionSectionCommand, CommonResponse<int>>
    {
        private readonly ISessionSectionRepository _sessionSectionRepository;

        public UpdateSessionSectionCommandHandler(ISessionSectionRepository sessionSectionRepository)
        {
            _sessionSectionRepository = sessionSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateSessionSectionCommand request, CancellationToken cancellationToken)
        {
            var sessionSection = await _sessionSectionRepository.GetByIdAsync(request.Id);
            if (sessionSection == null)
                return CommonResponse<int>.Fail(new[] { "SessionSection not found" });

            // Genel baþlýklar
            sessionSection.SubTitle = request.SubTitle;
            sessionSection.MainTitle = request.MainTitle;

            // Session 1
            sessionSection.Title1 = request.Title1;
            sessionSection.Time1 = request.Time1;
            sessionSection.IconUrl1 = request.IconUrl1;

            // Session 2
            sessionSection.Title2 = request.Title2;
            sessionSection.Time2 = request.Time2;
            sessionSection.IconUrl2 = request.IconUrl2;

            // Session 3
            sessionSection.Title3 = request.Title3;
            sessionSection.Time3 = request.Time3;
            sessionSection.IconUrl3 = request.IconUrl3;

            // Session 4
            sessionSection.Title4 = request.Title4;
            sessionSection.Time4 = request.Time4;
            sessionSection.IconUrl4 = request.IconUrl4;

            await _sessionSectionRepository.UpdateAsync(sessionSection);

            return CommonResponse<int>.Success(sessionSection.Id);
        }
    }
}
