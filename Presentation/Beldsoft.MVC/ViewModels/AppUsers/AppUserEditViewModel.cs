using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.AppUsers
{
    public class AppUserEditViewModel
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? Role { get; set; }
    }
}
