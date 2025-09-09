using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.AppUsers
{
    public class AppUserCreateViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
