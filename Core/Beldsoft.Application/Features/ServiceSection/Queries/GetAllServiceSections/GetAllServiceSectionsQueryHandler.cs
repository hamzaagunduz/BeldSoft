using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using Beldsoft.Application.Features.ServiceSection.Results;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ServiceSection.Queries.GetAllServiceSections
{
    public class GetAllServiceSectionsQueryHandler : IRequestHandler<GetAllServiceSectionsQuery, CommonResponse<List<GetAllServiceSectionsResult>>>
    {
        private readonly IServiceSectionRepository _serviceSectionRepository;

        public GetAllServiceSectionsQueryHandler(IServiceSectionRepository serviceSectionRepository)
        {
            _serviceSectionRepository = serviceSectionRepository;
        }

        public async Task<CommonResponse<List<GetAllServiceSectionsResult>>> Handle(GetAllServiceSectionsQuery request, CancellationToken cancellationToken)
        {
            var serviceSections = await _serviceSectionRepository.GetAllAsync();

            var result = serviceSections.Select(s => new GetAllServiceSectionsResult
            {
                Id = s.Id,
                Title = s.Title,
                Description = s.Description,
                IconUrl = s.IconUrl,
                ImageUrl = s.ImageUrl
            }).ToList();

            return CommonResponse<List<GetAllServiceSectionsResult>>.Success(result);
        }
    }
}
