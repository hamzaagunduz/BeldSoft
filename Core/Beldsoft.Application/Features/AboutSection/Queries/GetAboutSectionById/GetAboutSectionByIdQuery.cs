using Beldsoft.Application.Features.AboutSection.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.AboutSection.Queries.GetAboutSectionById
{
    public class GetAboutSectionByIdQuery : IRequest<CommonResponse<GetAboutSectionByIdResult>>
    {
        public int Id { get; set; }

        public GetAboutSectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
