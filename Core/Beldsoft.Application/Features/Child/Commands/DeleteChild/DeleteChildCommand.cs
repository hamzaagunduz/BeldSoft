using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.Child.Commands.DeleteChild
{
    public class DeleteChildCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        public DeleteChildCommand(int id)
        {
            Id = id;
        }
    }
}
