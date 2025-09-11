using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AboutSection.Commands.DeleteAboutSection
{
    public class DeleteAboutSectionCommandHandler : IRequestHandler<DeleteAboutSectionCommand, CommonResponse<int>>
    {
        private readonly IAboutSectionRepository _aboutSectionRepository;

        public DeleteAboutSectionCommandHandler(IAboutSectionRepository aboutSectionRepository)
        {
            _aboutSectionRepository = aboutSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(DeleteAboutSectionCommand request, CancellationToken cancellationToken)
        {
            var aboutSection = await _aboutSectionRepository.GetByIdAsync(request.Id);

        

            await _aboutSectionRepository.RemoveAsync(aboutSection);

            return CommonResponse<int>.Success(request.Id);
        }
    }
}
