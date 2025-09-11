using Microsoft.AspNetCore.Http;

namespace Beldsoft.MVC.ViewModels.FeedbackSection
{
    public class FeedbackSectionUpdateViewModel
    {
        public int Id { get; set; }

        public string? BigImageUrl { get; set; }
        public IFormFile? BigImage { get; set; }

        public string? UserImageUrl1 { get; set; }
        public IFormFile? UserImage1 { get; set; }

        public string? UserImageUrl2 { get; set; }
        public IFormFile? UserImage2 { get; set; }

        public string? UserImageUrl3 { get; set; }
        public IFormFile? UserImage3 { get; set; }

        public string? UserName1 { get; set; }
        public string? UserName2 { get; set; }
        public string? UserName3 { get; set; }

        public string? UserPosition1 { get; set; }
        public string? UserPosition2 { get; set; }
        public string? UserPosition3 { get; set; }

        public string? Comment1 { get; set; }
        public string? Comment2 { get; set; }
        public string? Comment3 { get; set; }

        public int? Rating1 { get; set; }
        public int? Rating2 { get; set; }
        public int? Rating3 { get; set; }
    }
}
