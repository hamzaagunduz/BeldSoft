using Beldsoft.Application.Features.SessionSection.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.SessionSection.Queries.GetSessionSectionById
{
    public class GetSessionSectionByIdQuery : IRequest<CommonResponse<GetSessionSectionByIdResult>>
    {
        public int Id { get; set; }

        public GetSessionSectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
