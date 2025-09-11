using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ServiceSection.Commands.CreateServiceSection
{
    public class CreateServiceSectionCommandHandler : IRequestHandler<CreateServiceSectionCommand, CommonResponse<int>>
    {
        private readonly IServiceSectionRepository _serviceSectionRepository;

        public CreateServiceSectionCommandHandler(IServiceSectionRepository serviceSectionRepository)
        {
            _serviceSectionRepository = serviceSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(CreateServiceSectionCommand request, CancellationToken cancellationToken)
        {
            var serviceSection = new Bedldsoft.Domain.Entities.ServiceSection
            {
                Title = request.Title,
                Description = request.Description,
                IconUrl = request.IconUrl,
                ImageUrl = request.ImageUrl
            };

            await _serviceSectionRepository.AddAsync(serviceSection);

            return CommonResponse<int>.Success(serviceSection.Id);
        }
    }
}
