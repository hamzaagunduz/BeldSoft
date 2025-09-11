using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.ServiceSection
{
    public class ServiceSectionUpdateViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string IconUrl { get; set; }

        // Image upload için IFormFile
        public IFormFile Image { get; set; }

        // Mevcut Image URL
        public string ImageUrl { get; set; }
    }
}
