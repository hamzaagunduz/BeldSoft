using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetPagedChild
{
    public class GetPagedChildQueryHandler : IRequestHandler<GetPagedChildQuery, CommonResponse<PagedChildResult>>
    {
        private readonly IChildRepository _childRepository;

        public GetPagedChildQueryHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<PagedChildResult>> Handle(GetPagedChildQuery request, CancellationToken cancellationToken)
        {
            // Toplam kayıt sayısı
            var totalCount = await _childRepository.CountAsync();

            // Sayfalı veriler
            var children = await _childRepository.GetChildrenPagedAsync(request.PageNumber, request.PageSize);

            var result = new PagedChildResult
            {
                Children = children.Select(c => new GetAllChildResult
                {
                    Id = c.Id,
                    FirstName = c.FirstName,
                    LastName = c.LastName,
                    ParentPhone = c.ParentPhone,
                    ArrivalTime = c.ArrivalTime,
                    DurationMinutes = c.DurationMinutes,
                    IsExpired = c.IsExpired,
                }).ToList(),
                CurrentPage = request.PageNumber,
                PageSize = request.PageSize,
                TotalCount = totalCount,
                TotalPages = (int)System.Math.Ceiling((double)totalCount / request.PageSize)
            };

            return CommonResponse<PagedChildResult>.Success(result);
        }
    }
}
