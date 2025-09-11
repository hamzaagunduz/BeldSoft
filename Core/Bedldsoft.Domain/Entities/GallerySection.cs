using System;

namespace Beldsoft.Domain.Entities
{
    public class GallerySection
    {
        public int Id { get; set; }

        public string? SubTitle { get; set; }   // Küçük başlık
        public string? MainTitle { get; set; }  // Büyük başlık

        public string? ImageUrl1 { get; set; }
        public string? ImageUrl2 { get; set; }
        public string? ImageUrl3 { get; set; }
        public string? ImageUrl4 { get; set; }

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
