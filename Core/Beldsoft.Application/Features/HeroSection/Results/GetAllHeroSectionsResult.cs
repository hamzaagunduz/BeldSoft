using Beldsoft.Application.Features.HeroSection.Results;
using Beldsoft.Application.Responses;
using MediatR;

public class GetAllHeroSectionsQuery : IRequest<CommonResponse<List<GetAllHeroSectionsResult>>>
{
    // �leride filtreleme i�in property eklenebilir
}