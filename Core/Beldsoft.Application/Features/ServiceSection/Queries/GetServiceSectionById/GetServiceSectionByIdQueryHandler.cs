using Beldsoft.Application.Features.ServiceSection.Results;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ServiceSection.Queries.GetServiceSectionById
{
    public class GetServiceSectionByIdQueryHandler : IRequestHandler<GetServiceSectionByIdQuery, CommonResponse<GetServiceSectionByIdResult>>
    {
        private readonly IServiceSectionRepository _serviceSectionRepository;

        public GetServiceSectionByIdQueryHandler(IServiceSectionRepository serviceSectionRepository)
        {
            _serviceSectionRepository = serviceSectionRepository;
        }

        public async Task<CommonResponse<GetServiceSectionByIdResult>> Handle(GetServiceSectionByIdQuery request, CancellationToken cancellationToken)
        {
            var serviceSection = await _serviceSectionRepository.GetByIdAsync(request.Id);

            var result = new GetServiceSectionByIdResult
            {
                Id = serviceSection.Id,
                Title = serviceSection.Title,
                Description = serviceSection.Description,
                IconUrl = serviceSection.IconUrl,
                ImageUrl = serviceSection.ImageUrl
            };

            return CommonResponse<GetServiceSectionByIdResult>.Success(result);
        }
    }
}
