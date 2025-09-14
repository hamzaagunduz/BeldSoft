using System.ComponentModel.DataAnnotations;

namespace Beldsoft.MVC.ViewModels.Contact
{
    public class ContactMessageCreateViewModel
    {
        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad 2–50 karakter arasında olmalıdır.")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Soyad alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Soyad 2–50 karakter arasında olmalıdır.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Email alanı zorunludur.")]
        [EmailAddress(ErrorMessage = "Geçerli bir email adresi giriniz.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        [RegularExpression(@"^0[0-9]{10}$", ErrorMessage = "Telefon numarasını 05XXXXXXXXX formatında giriniz.")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Mesaj alanı boş bırakılamaz.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Mesaj 10–500 karakter arasında olmalıdır.")]
        public string? Message { get; set; }
    }
}
