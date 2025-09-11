using Beldsoft.Application.Features.GallerySection.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.GallerySection.Queries.GetAllGallerySections
{
    public class GetAllGallerySectionsQuery : IRequest<CommonResponse<List<GetAllGallerySectionsResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
