using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.AppUsers
{
    public class AppUserCreateViewModel
    {
        public string Email { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string PhoneNumber { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
