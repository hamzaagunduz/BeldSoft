using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetChildrenByParentPhone
{
    public class GetChildrenByParentPhoneQueryHandler : IRequestHandler<GetChildrenByParentPhoneQuery, CommonResponse<List<GetAllChildForTodayResult>>>
    {
        private readonly IChildRepository _childRepository;

        public GetChildrenByParentPhoneQueryHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<List<GetAllChildForTodayResult>>> Handle(GetChildrenByParentPhoneQuery request, CancellationToken cancellationToken)
        {
            var children = await _childRepository.GetChildrenByParentPhoneAsync(request.ParentPhone);

            var result = children.Select(c => new GetAllChildForTodayResult
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                ParentPhone = c.ParentPhone,
                ArrivalTime = c.ArrivalTime,
                DurationMinutes = c.DurationMinutes,
                IsExpired = c.IsExpired,
            }).ToList();

            return CommonResponse<List<GetAllChildForTodayResult>>.Success(result);
        }
    }
}
