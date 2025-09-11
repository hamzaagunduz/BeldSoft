using Microsoft.AspNetCore.Http;

namespace Beldsoft.MVC.ViewModels.GallerySection
{
    public class GallerySectionUpdateViewModel
    {
        public int Id { get; set; }

        public string? SubTitle { get; set; }
        public string? MainTitle { get; set; }

        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }

        public IFormFile? Image1 { get; set; }
        public IFormFile? Image2 { get; set; }
        public IFormFile? Image3 { get; set; }
        public IFormFile? Image4 { get; set; }

        public string? Category1 { get; set; }
        public string? Category2 { get; set; }
        public string? Category3 { get; set; }
        public string? Category4 { get; set; }

        public string? Heading1 { get; set; }
        public string? Heading2 { get; set; }
        public string? Heading3 { get; set; }
        public string? Heading4 { get; set; }
    }
}
