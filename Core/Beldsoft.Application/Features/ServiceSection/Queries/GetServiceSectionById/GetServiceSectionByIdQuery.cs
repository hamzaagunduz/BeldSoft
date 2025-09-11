using Beldsoft.Application.Features.ServiceSection.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ServiceSection.Queries.GetServiceSectionById
{
    public class GetServiceSectionByIdQuery : IRequest<CommonResponse<GetServiceSectionByIdResult>>
    {
        public int Id { get; set; }

        public GetServiceSectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
