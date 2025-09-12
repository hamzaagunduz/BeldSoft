using Beldsoft.Application.Features.ContactMessage.Results;
using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ContactMessage.Queries.GetContactMessageById
{
    public class GetContactMessageByIdQueryHandler : IRequestHandler<GetContactMessageByIdQuery, CommonResponse<GetContactMessageByIdResult>>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public GetContactMessageByIdQueryHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<CommonResponse<GetContactMessageByIdResult>> Handle(GetContactMessageByIdQuery request, CancellationToken cancellationToken)
        {
            var contactMessage = await _contactMessageRepository.GetByIdAsync(request.Id);

            if (contactMessage == null)
                return CommonResponse<GetContactMessageByIdResult>.Fail(new[] { $"ContactMessage with Id {request.Id} not found." });

            var result = new GetContactMessageByIdResult
            {
                Id = contactMessage.Id,
                FirstName = contactMessage.FirstName,
                LastName = contactMessage.LastName,
                Email = contactMessage.Email,
                Phone = contactMessage.Phone,
                Message = contactMessage.Message,
                CreatedDate = contactMessage.CreatedDate
            };

            return CommonResponse<GetContactMessageByIdResult>.Success(result);
        }
    }
}
