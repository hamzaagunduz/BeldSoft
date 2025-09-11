using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.ISessionSectionRepository;
using Beldsoft.Application.Features.SessionSection.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.SessionSection.Queries.GetAllSessionSections
{
    public class GetAllSessionSectionsQueryHandler : IRequestHandler<GetAllSessionSectionsQuery, CommonResponse<List<GetAllSessionSectionsResult>>>
    {
        private readonly ISessionSectionRepository _sessionSectionRepository;

        public GetAllSessionSectionsQueryHandler(ISessionSectionRepository sessionSectionRepository)
        {
            _sessionSectionRepository = sessionSectionRepository;
        }

        public async Task<CommonResponse<List<GetAllSessionSectionsResult>>> Handle(GetAllSessionSectionsQuery request, CancellationToken cancellationToken)
        {
            var sessionSections = await _sessionSectionRepository.GetAllAsync();

            var result = sessionSections.Select(s => new GetAllSessionSectionsResult
            {
                Id = s.Id,
                SubTitle = s.SubTitle,
                MainTitle = s.MainTitle,

                Title1 = s.Title1,
                Time1 = s.Time1,
                IconUrl1 = s.IconUrl1,

                Title2 = s.Title2,
                Time2 = s.Time2,
                IconUrl2 = s.IconUrl2,

                Title3 = s.Title3,
                Time3 = s.Time3,
                IconUrl3 = s.IconUrl3,

                Title4 = s.Title4,
                Time4 = s.Time4,
                IconUrl4 = s.IconUrl4
            }).ToList();

            return CommonResponse<List<GetAllSessionSectionsResult>>.Success(result);
        }
    }
}
