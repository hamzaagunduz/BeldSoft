using Microsoft.AspNetCore.Http;

namespace Beldsoft.MVC.ViewModels.AboutSection
{
    public class AboutSectionUpdateViewModel
    {
        public int? Id { get; set; }

        // Görseller
        public string? BigImageUrl { get; set; }
        public IFormFile? BigImage { get; set; }

        public string? SmallImageUrl { get; set; }
        public IFormFile? SmallImage { get; set; }

        // Genel Başlık
        public string? SubTitle { get; set; }
        public string? MainTitle { get; set; }

        // Deneyim kısmı
        public string? ExperienceNumber { get; set; }
        public string? ExperienceText { get; set; }

        // Tab 1 (Our History)
        public string? Title1 { get; set; }
        public string? Title1Description { get; set; }
        public string? Title1Step1 { get; set; }
        public string? Title1Step2 { get; set; }

        // Tab 2 (School)
        public string? Title2 { get; set; }
        public string? Title2Description { get; set; }
        public string? Title2Step1 { get; set; }
        public string? Title2Step2 { get; set; }

        // Tab 3 (Kids)
        public string? Title3 { get; set; }
        public string? Title3Description { get; set; }
        public string? Title3Step1 { get; set; }
        public string? Title3Step2 { get; set; }
    }
}
