using Beldsoft.Application.Features.ContactMessage.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ContactMessage.Queries.GetContactMessageById
{
    public class GetContactMessageByIdQuery : IRequest<CommonResponse<GetContactMessageByIdResult>>
    {
        public int Id { get; set; }

        public GetContactMessageByIdQuery(int id)
        {
            Id = id;
        }
    }
}
