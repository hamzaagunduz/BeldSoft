using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ServiceSection.Commands.UpdateServiceSection
{
    public class UpdateServiceSectionCommandHandler : IRequestHandler<UpdateServiceSectionCommand, CommonResponse<int>>
    {
        private readonly IServiceSectionRepository _serviceSectionRepository;

        public UpdateServiceSectionCommandHandler(IServiceSectionRepository serviceSectionRepository)
        {
            _serviceSectionRepository = serviceSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateServiceSectionCommand request, CancellationToken cancellationToken)
        {
            var serviceSection = await _serviceSectionRepository.GetByIdAsync(request.Id);
            if (serviceSection == null)
                return CommonResponse<int>.Fail(new[] { "ServiceSection not found" });

            serviceSection.Title = request.Title;
            serviceSection.Description = request.Description;
            serviceSection.IconUrl = request.IconUrl;

            if (!string.IsNullOrEmpty(request.ImageUrl))
                serviceSection.ImageUrl = request.ImageUrl;

            await _serviceSectionRepository.UpdateAsync(serviceSection);

            return CommonResponse<int>.Success(serviceSection.Id);
        }
    }
}
