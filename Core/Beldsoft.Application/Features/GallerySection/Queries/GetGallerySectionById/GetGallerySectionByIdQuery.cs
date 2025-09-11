using Beldsoft.Application.Features.GallerySection.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.GallerySection.Queries.GetGallerySectionById
{
    public class GetGallerySectionByIdQuery : IRequest<CommonResponse<GetGallerySectionByIdResult>>
    {
        public int Id { get; set; }

        public GetGallerySectionByIdQuery(int id)
        {
            Id = id;
        }
    }
}
