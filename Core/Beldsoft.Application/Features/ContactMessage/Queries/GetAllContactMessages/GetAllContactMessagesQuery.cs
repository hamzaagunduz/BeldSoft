using Beldsoft.Application.Features.ContactMessage.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.ContactMessage.Queries.GetAllContactMessages
{
    public class GetAllContactMessagesQuery : IRequest<CommonResponse<List<GetAllContactMessagesResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
