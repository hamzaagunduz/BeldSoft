using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.HeroSection
{
    public class HeroSectionUpdateViewModel
    {
        public int Id { get; set; }

        public string SubTitle { get; set; }

        public string MainTitle { get; set; }

        public string MainTitleHighlight { get; set; }

        public string Description { get; set; }

        // Yeni upload için
        public IFormFile SmallImage { get; set; }
        public IFormFile BigImage { get; set; }

        // Mevcut dosya yolları (edit sayfasında önizleme için)
        public string SmallImageUrl { get; set; }
        public string BigImageUrl { get; set; }
    }
}
