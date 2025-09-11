using Beldsoft.Application.Features.GallerySection.Results;
using Beldsoft.Application.Interfaces.IGallerySectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.GallerySection.Queries.GetGallerySectionById
{
    public class GetGallerySectionByIdQueryHandler : IRequestHandler<GetGallerySectionByIdQuery, CommonResponse<GetGallerySectionByIdResult>>
    {
        private readonly IGallerySectionRepository _gallerySectionRepository;

        public GetGallerySectionByIdQueryHandler(IGallerySectionRepository gallerySectionRepository)
        {
            _gallerySectionRepository = gallerySectionRepository;
        }

        public async Task<CommonResponse<GetGallerySectionByIdResult>> Handle(GetGallerySectionByIdQuery request, CancellationToken cancellationToken)
        {
            var gallerySection = await _gallerySectionRepository.GetByIdAsync(request.Id);

            if (gallerySection == null)
            {
                return CommonResponse<GetGallerySectionByIdResult>.Fail(new[] { $"GallerySection with Id {request.Id} not found." });
            }

            var result = new GetGallerySectionByIdResult
            {
                Id = gallerySection.Id,
                SubTitle = gallerySection.SubTitle,
                MainTitle = gallerySection.MainTitle,
                ImageUrl1 = gallerySection.ImageUrl1,
                ImageUrl2 = gallerySection.ImageUrl2,
                ImageUrl3 = gallerySection.ImageUrl3,
                ImageUrl4 = gallerySection.ImageUrl4,
                Category1 = gallerySection.Category1,
                Category2 = gallerySection.Category2,
                Category3 = gallerySection.Category3,
                Category4 = gallerySection.Category4,
                Heading1 = gallerySection.Heading1,
                Heading2 = gallerySection.Heading2,
                Heading3 = gallerySection.Heading3,
                Heading4 = gallerySection.Heading4
            };

            return CommonResponse<GetGallerySectionByIdResult>.Success(result);
        }
    }
}
