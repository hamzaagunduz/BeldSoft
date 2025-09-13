using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetAllChildForToday
{
    public class GetAllChildForTodayQueryHandler : IRequestHandler<GetAllChildForTodayQuery, CommonResponse<List<GetAllChildForTodayResult>>>
    {
        private readonly IChildRepository _childRepository;

        public GetAllChildForTodayQueryHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<List<GetAllChildForTodayResult>>> Handle(GetAllChildForTodayQuery request, CancellationToken cancellationToken)
        {
            var children = await _childRepository.GetChildrenForTodayAsync();
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
