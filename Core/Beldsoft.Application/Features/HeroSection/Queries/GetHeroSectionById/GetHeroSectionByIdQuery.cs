using Beldsoft.Application.Features.HeroSection.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.HeroSection.Queries.GetHeroSectionById
{
    public class GetHeroSectionByIdQuery : IRequest<CommonResponse<GetHeroSectionByIdResult>>
    {
        public int Id { get; set; }
        public GetHeroSectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
