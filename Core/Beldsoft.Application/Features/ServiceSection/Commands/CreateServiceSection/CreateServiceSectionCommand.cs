using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.ServiceSection.Commands.CreateServiceSection
{
    public class CreateServiceSectionCommand : IRequest<CommonResponse<int>>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string IconUrl { get; set; }
        public string ImageUrl { get; set; }
    }
}
