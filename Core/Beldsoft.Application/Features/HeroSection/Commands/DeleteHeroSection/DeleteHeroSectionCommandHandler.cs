using Beldsoft.Application.Responses;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.HeroSection.Commands.DeleteHeroSection
{
    public class DeleteHeroSectionCommandHandler : IRequestHandler<DeleteHeroSectionCommand, CommonResponse<int>>
    {
        private readonly IServiceSectionRepository _heroSectionRepository;

        public DeleteHeroSectionCommandHandler(IServiceSectionRepository heroSectionRepository)
        {
            _heroSectionRepository = heroSectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(DeleteHeroSectionCommand request, CancellationToken cancellationToken)
        {
            var heroSection = await _heroSectionRepository.GetByIdAsync(request.Id);


            await _heroSectionRepository.RemoveAsync(heroSection);

            return CommonResponse<int>.Success(request.Id);
        }
    }
}
