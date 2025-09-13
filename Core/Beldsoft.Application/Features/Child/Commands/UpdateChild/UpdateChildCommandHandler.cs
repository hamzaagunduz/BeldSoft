using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Commands.UpdateChild
{
    public class UpdateChildCommandHandler : IRequestHandler<UpdateChildCommand, CommonResponse<int>>
    {
        private readonly IChildRepository _childRepository;

        public UpdateChildCommandHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateChildCommand request, CancellationToken cancellationToken)
        {
            var child = await _childRepository.GetByIdAsync(request.Id);
            if (child == null)
                return CommonResponse<int>.Fail(new[] { "Child not found" });

            // �ocuk bilgileri
            if (!string.IsNullOrEmpty(request.FirstName))
                child.FirstName = request.FirstName;

            if (!string.IsNullOrEmpty(request.LastName))
                child.LastName = request.LastName;

            if (!string.IsNullOrEmpty(request.ParentPhone))
                child.ParentPhone = request.ParentPhone;

            // Giri� bilgileri
            if (request.ArrivalTime.HasValue)
                child.ArrivalTime = request.ArrivalTime;

            if (request.DurationMinutes.HasValue)
                child.DurationMinutes = request.DurationMinutes;

            if (request.IsExpired.HasValue)
                child.IsExpired = request.IsExpired.Value;

            await _childRepository.UpdateAsync(child);

            return CommonResponse<int>.Success(child.Id);
        }
    }
}
