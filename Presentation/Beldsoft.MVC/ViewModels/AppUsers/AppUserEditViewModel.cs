using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.AppUsers
{
    public class AppUserEditViewModel
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string? Password { get; set; } // Şifre opsiyonel
    }
}
