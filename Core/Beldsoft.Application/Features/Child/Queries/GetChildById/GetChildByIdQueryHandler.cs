using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetChildById
{
    public class GetChildByIdQueryHandler : IRequestHandler<GetChildByIdQuery, CommonResponse<GetChildByIdResult>>
    {
        private readonly IChildRepository _childRepository;

        public GetChildByIdQueryHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<GetChildByIdResult>> Handle(GetChildByIdQuery request, CancellationToken cancellationToken)
        {
            var child = await _childRepository.GetByIdAsync(request.Id);

            if (child == null)
                return CommonResponse<GetChildByIdResult>.Fail(new[] { $"Child with Id {request.Id} not found." });

            var result = new GetChildByIdResult
            {
                Id = child.Id,
                FirstName = child.FirstName,
                LastName = child.LastName,
                ParentPhone = child.ParentPhone,
                ArrivalTime = child.ArrivalTime,
                DurationMinutes = child.DurationMinutes,
                IsExpired = child.IsExpired,
            };

            return CommonResponse<GetChildByIdResult>.Success(result);
        }
    }
}
