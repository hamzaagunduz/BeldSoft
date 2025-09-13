using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Commands.DeleteChild
{
    public class DeleteChildCommandHandler : IRequestHandler<DeleteChildCommand, CommonResponse<int>>
    {
        private readonly IChildRepository _childRepository;

        public DeleteChildCommandHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<int>> Handle(DeleteChildCommand request, CancellationToken cancellationToken)
        {
            var child = await _childRepository.GetByIdAsync(request.Id);

            if (child == null)
                return CommonResponse<int>.Fail(new[] { $"Child with Id {request.Id} not found." });

            await _childRepository.RemoveAsync(child);

            return CommonResponse<int>.Success(child.Id);
        }
    }
}
