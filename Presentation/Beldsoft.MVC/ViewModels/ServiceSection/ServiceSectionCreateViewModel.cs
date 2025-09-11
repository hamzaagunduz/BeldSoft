using System.ComponentModel.DataAnnotations;

    namespace Beldsoft.MVC.ViewModels.ServiceSection
    {
        public class ServiceSectionCreateViewModel
        {
            public string Title { get; set; }

            public string Description { get; set; }

            public string IconUrl { get; set; }

            public IFormFile Image { get; set; }
        }
    }
