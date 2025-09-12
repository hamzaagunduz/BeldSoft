using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ContactMessage.Commands.DeleteContactMessage
{
    public class DeleteContactMessageCommandHandler : IRequestHandler<DeleteContactMessageCommand, CommonResponse<int>>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public DeleteContactMessageCommandHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<CommonResponse<int>> Handle(DeleteContactMessageCommand request, CancellationToken cancellationToken)
        {
            var contactMessage = await _contactMessageRepository.GetByIdAsync(request.Id);

            if (contactMessage == null)
                return CommonResponse<int>.Fail(new[] { $"ContactMessage with Id {request.Id} not found." });

            await _contactMessageRepository.RemoveAsync(contactMessage);

            return CommonResponse<int>.Success(contactMessage.Id);
        }
    }
}
