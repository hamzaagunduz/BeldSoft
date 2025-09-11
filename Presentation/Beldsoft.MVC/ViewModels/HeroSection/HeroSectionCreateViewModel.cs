using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.HeroSection
{
    public class HeroSectionCreateViewModel
    {
        public string SubTitle { get; set; }

        public string MainTitle { get; set; }

        public string MainTitleHighlight { get; set; }

        public string Description { get; set; }

        [Display(Name = "Small Image")]
        public IFormFile SmallImage { get; set; }

        [Display(Name = "Big Image")]
        public IFormFile BigImage { get; set; }
    }
}
