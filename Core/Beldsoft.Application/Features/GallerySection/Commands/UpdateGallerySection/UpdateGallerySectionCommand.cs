using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.GallerySection.Commands.UpdateGallerySection
{
    public class UpdateGallerySectionCommand : IRequest<CommonResponse<int>>
    {
        public int Id { get; set; }

        // Ba�l�klar
        public string? SubTitle { get; set; }
        public string? MainTitle { get; set; }

        // G�rseller
        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }

        // Kategoriler
        public string? Category1 { get; set; }
        public string? Category2 { get; set; }
        public string? Category3 { get; set; }
        public string? Category4 { get; set; }

        // Alt ba�l�klar / Headingler
        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
        public string? Heading4 { get; set; }
    }
}
