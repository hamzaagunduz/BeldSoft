using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ServiceSection.Commands.DeleteServiceSection
{
    public class DeleteServiceSectionCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        public DeleteServiceSectionCommand(int id)
        {
            Id = id;
        }
    }
}
