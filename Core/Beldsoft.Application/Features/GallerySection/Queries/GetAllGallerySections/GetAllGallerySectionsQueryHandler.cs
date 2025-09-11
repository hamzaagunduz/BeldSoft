using Beldsoft.Application.Features.GallerySection.Results;
using Beldsoft.Application.Interfaces.IGallerySectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.GallerySection.Queries.GetAllGallerySections
{
    public class GetAllGallerySectionsQueryHandler : IRequestHandler<GetAllGallerySectionsQuery, CommonResponse<List<GetAllGallerySectionsResult>>>
    {
        private readonly IGallerySectionRepository _gallerySectionRepository;

        public GetAllGallerySectionsQueryHandler(IGallerySectionRepository gallerySectionRepository)
        {
            _gallerySectionRepository = gallerySectionRepository;
        }

        public async Task<CommonResponse<List<GetAllGallerySectionsResult>>> Handle(GetAllGallerySectionsQuery request, CancellationToken cancellationToken)
        {
            var gallerySections = await _gallerySectionRepository.GetAllAsync();

            var result = gallerySections.Select(g => new GetAllGallerySectionsResult
            {
                Id = g.Id,
                SubTitle = g.SubTitle,
                MainTitle = g.MainTitle,
                ImageUrl1 = g.ImageUrl1,
                ImageUrl2 = g.ImageUrl2,
                ImageUrl3 = g.ImageUrl3,
                ImageUrl4 = g.ImageUrl4,
                Category1 = g.Category1,
                Category2 = g.Category2,
                Category3 = g.Category3,
                Category4 = g.Category4,
                Heading1 = g.Heading1,
                Heading2 = g.Heading2,
                Heading3 = g.Heading3,
                Heading4 = g.Heading4
            }).ToList();

            return CommonResponse<List<GetAllGallerySectionsResult>>.Success(result);
        }
    }
}
