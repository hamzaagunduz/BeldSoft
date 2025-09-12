using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ContactMessage.Commands.DeleteContactMessage
{
    public class DeleteContactMessageCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        public DeleteContactMessageCommand(int id)
        {
            Id = id;
        }
    }
}
