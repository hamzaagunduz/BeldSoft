using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Responses;
using Beldsoft.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Commands.CreateChild
{
    public class CreateChildCommandHandler : IRequestHandler<CreateChildCommand, CommonResponse<int>>
    {
        private readonly IChildRepository _childRepository;

        public CreateChildCommandHandler(IChildRepository childRepository)
        {
            _childRepository = childRepository;
        }

        public async Task<CommonResponse<int>> Handle(CreateChildCommand request, CancellationToken cancellationToken)
        {
            var child = new Bedldsoft.Domain.Entities.Child
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ParentPhone = request.ParentPhone,
                ArrivalTime = DateTime.Now,
                DurationMinutes = request.DurationMinutes,
                IsExpired = false // yeni eklenen çocuk için default false
            };

            await _childRepository.AddAsync(child);

            return CommonResponse<int>.Success(child.Id);
        }
    }
}
