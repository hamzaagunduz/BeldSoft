using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ServiceSection.Commands.DeleteServiceSection
{
    public class DeleteServiceSectionCommandHandler : IRequestHandler<DeleteServiceSectionCommand, CommonResponse<int>>
    {
        private readonly IServiceSectionRepository _serviceSectionRepository;

        public DeleteServiceSectionCommandHandler(IServiceSectionRepository serviceSectionRepository)
        {
            _serviceSectionRepository = serviceSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(DeleteServiceSectionCommand request, CancellationToken cancellationToken)
        {
            var serviceSection = await _serviceSectionRepository.GetByIdAsync(request.Id);


            await _serviceSectionRepository.RemoveAsync(serviceSection);

            return CommonResponse<int>.Success(request.Id);
        }
    }
}
