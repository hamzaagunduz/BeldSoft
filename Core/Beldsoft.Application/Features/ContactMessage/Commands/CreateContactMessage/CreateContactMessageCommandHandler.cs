using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Application.Responses;
using Beldsoft.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ContactMessage.Commands.CreateContactMessage
{
    public class CreateContactMessageCommandHandler : IRequestHandler<CreateContactMessageCommand, CommonResponse<int>>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public CreateContactMessageCommandHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<CommonResponse<int>> Handle(CreateContactMessageCommand request, CancellationToken cancellationToken)
        {
            var contactMessage = new Domain.Entities.ContactMessage
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Phone = request.Phone,
                Message = request.Message
            };

            await _contactMessageRepository.AddAsync(contactMessage);

            return CommonResponse<int>.Success(contactMessage.Id);
        }
    }
}
