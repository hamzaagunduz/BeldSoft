using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.AboutSection.Commands.DeleteAboutSection
{
    public class DeleteAboutSectionCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        public DeleteAboutSectionCommand(int id)
        {
            Id = id;
        }
    }
}
