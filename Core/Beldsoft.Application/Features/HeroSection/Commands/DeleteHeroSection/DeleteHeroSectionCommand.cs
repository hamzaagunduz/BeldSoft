using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.HeroSection.Commands.DeleteHeroSection
{
    public class DeleteHeroSectionCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        public DeleteHeroSectionCommand(int id)
        {
            Id = id;
        }
    }
}
