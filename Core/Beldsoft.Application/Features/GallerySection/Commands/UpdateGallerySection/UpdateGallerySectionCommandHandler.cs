using Beldsoft.Application.Interfaces.IGallerySectionRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.GallerySection.Commands.UpdateGallerySection
{
    public class UpdateGallerySectionCommandHandler : IRequestHandler<UpdateGallerySectionCommand, CommonResponse<int>>
    {
        private readonly IGallerySectionRepository _gallerySectionRepository;

        public UpdateGallerySectionCommandHandler(IGallerySectionRepository gallerySectionRepository)
        {
            _gallerySectionRepository = gallerySectionRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateGallerySectionCommand request, CancellationToken cancellationToken)
        {
            var gallerySection = await _gallerySectionRepository.GetByIdAsync(request.Id);
            if (gallerySection == null)
                return CommonResponse<int>.Fail(new[] { "GallerySection not found" });

            // Baþlýklar
            gallerySection.SubTitle = request.SubTitle;
            gallerySection.MainTitle = request.MainTitle;

            // Görseller
            if (!string.IsNullOrEmpty(request.ImageUrl1)) gallerySection.ImageUrl1 = request.ImageUrl1;
            if (!string.IsNullOrEmpty(request.ImageUrl2)) gallerySection.ImageUrl2 = request.ImageUrl2;
            if (!string.IsNullOrEmpty(request.ImageUrl3)) gallerySection.ImageUrl3 = request.ImageUrl3;
            if (!string.IsNullOrEmpty(request.ImageUrl4)) gallerySection.ImageUrl4 = request.ImageUrl4;

            // Kategoriler
            gallerySection.Category1 = request.Category1;
            gallerySection.Category2 = request.Category2;
            gallerySection.Category3 = request.Category3;
            gallerySection.Category4 = request.Category4;

            // Headingler
            gallerySection.Heading1 = request.Heading1;
            gallerySection.Heading2 = request.Heading2;
            gallerySection.Heading3 = request.Heading3;
            gallerySection.Heading4 = request.Heading4;

            await _gallerySectionRepository.UpdateAsync(gallerySection);

            return CommonResponse<int>.Success(gallerySection.Id);
        }
    }
}
