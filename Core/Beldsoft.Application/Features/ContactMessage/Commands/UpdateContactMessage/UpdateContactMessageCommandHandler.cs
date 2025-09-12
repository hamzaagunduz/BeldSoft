using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ContactMessage.Commands.UpdateContactMessage
{
    public class UpdateContactMessageCommandHandler : IRequestHandler<UpdateContactMessageCommand, CommonResponse<int>>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public UpdateContactMessageCommandHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateContactMessageCommand request, CancellationToken cancellationToken)
        {
            var contactMessage = await _contactMessageRepository.GetByIdAsync(request.Id);
            if (contactMessage == null)
                return CommonResponse<int>.Fail(new[] { "ContactMessage not found" });

            // Gönderen bilgileri
            if (!string.IsNullOrEmpty(request.FirstName))
                contactMessage.FirstName = request.FirstName;

            if (!string.IsNullOrEmpty(request.LastName))
                contactMessage.LastName = request.LastName;

            if (!string.IsNullOrEmpty(request.Email))
                contactMessage.Email = request.Email;

            if (!string.IsNullOrEmpty(request.Phone))
                contactMessage.Phone = request.Phone;

            // Mesaj içeriði
            if (!string.IsNullOrEmpty(request.Message))
                contactMessage.Message = request.Message;

            await _contactMessageRepository.UpdateAsync(contactMessage);

            return CommonResponse<int>.Success(contactMessage.Id);
        }
    }
}
