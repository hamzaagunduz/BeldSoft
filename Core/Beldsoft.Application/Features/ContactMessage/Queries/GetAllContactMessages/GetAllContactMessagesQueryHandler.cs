using Beldsoft.Application.Features.ContactMessage.Results;
using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.ContactMessage.Queries.GetAllContactMessages
{
    public class GetAllContactMessagesQueryHandler : IRequestHandler<GetAllContactMessagesQuery, CommonResponse<List<GetAllContactMessagesResult>>>
    {
        private readonly IContactMessageRepository _contactMessageRepository;

        public GetAllContactMessagesQueryHandler(IContactMessageRepository contactMessageRepository)
        {
            _contactMessageRepository = contactMessageRepository;
        }

        public async Task<CommonResponse<List<GetAllContactMessagesResult>>> Handle(GetAllContactMessagesQuery request, CancellationToken cancellationToken)
        {
            var contactMessages = await _contactMessageRepository.GetAllAsync();

            var result = contactMessages.Select(cm => new GetAllContactMessagesResult
            {
                Id = cm.Id,
                FirstName = cm.FirstName,
                LastName = cm.LastName,
                Email = cm.Email,
                Phone = cm.Phone,
                Message = cm.Message,
                CreatedDate = cm.CreatedDate
            }).ToList();

            return CommonResponse<List<GetAllContactMessagesResult>>.Success(result);
        }
    }
}
