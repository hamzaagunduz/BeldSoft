using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetAllChild
{
    public class GetAllChildQueryHandler : IRequestHandler<GetAllChildQuery, CommonResponse<List<GetAllChildResult>>>
    {
        private readonly IChildRepository _childRepository;

        public GetAllChildQueryHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<List<GetAllChildResult>>> Handle(GetAllChildQuery request, CancellationToken cancellationToken)
        {
            var children = await _childRepository.GetAllAsync();

            var result = children.Select(c => new GetAllChildResult
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName,
                ParentPhone = c.ParentPhone,
                ArrivalTime = c.ArrivalTime,
                DurationMinutes = c.DurationMinutes,
                IsExpired = c.IsExpired,
            }).ToList();

            return CommonResponse<List<GetAllChildResult>>.Success(result);
        }
    }
}
