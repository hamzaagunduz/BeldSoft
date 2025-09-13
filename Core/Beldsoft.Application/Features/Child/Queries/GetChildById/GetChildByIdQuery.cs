using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.Child.Queries.GetChildById
{
    public class GetChildByIdQuery : IRequest<CommonResponse<GetChildByIdResult>>
    {
        public int Id { get; set; }

        public GetChildByIdQuery(int id)
        {
            Id = id;
        }
    }
}
