using Beldsoft.Application.Features.SessionSection.Results;
using Beldsoft.Application.Interfaces.ISessionSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.SessionSection.Queries.GetSessionSectionById
{
    public class GetSessionSectionByIdQueryHandler : IRequestHandler<GetSessionSectionByIdQuery, CommonResponse<GetSessionSectionByIdResult>>
    {
        private readonly ISessionSectionRepository _sessionSectionRepository;

        public GetSessionSectionByIdQueryHandler(ISessionSectionRepository sessionSectionRepository)
        {
            _sessionSectionRepository = sessionSectionRepository;
        }

        public async Task<CommonResponse<GetSessionSectionByIdResult>> Handle(GetSessionSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var sessionSection = await _sessionSectionRepository.GetByIdAsync(request.Id);
            if (sessionSection == null)
                return CommonResponse<GetSessionSectionByIdResult>.Fail(new[] { "SessionSection not found" });

            var result = new GetSessionSectionByIdResult
            {
                Id = sessionSection.Id,
                SubTitle = sessionSection.SubTitle,
                MainTitle = sessionSection.MainTitle,

                Title1 = sessionSection.Title1,
                Time1 = sessionSection.Time1,
                IconUrl1 = sessionSection.IconUrl1,

                Title2 = sessionSection.Title2,
                Time2 = sessionSection.Time2,
                IconUrl2 = sessionSection.IconUrl2,

                Title3 = sessionSection.Title3,
                Time3 = sessionSection.Time3,
                IconUrl3 = sessionSection.IconUrl3,

                Title4 = sessionSection.Title4,
                Time4 = sessionSection.Time4,
                IconUrl4 = sessionSection.IconUrl4
            };

            return CommonResponse<GetSessionSectionByIdResult>.Success(result);
        }
    }
}
