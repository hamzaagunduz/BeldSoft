using Beldsoft.MVC.ViewModels.SiteSettings;

namespace Beldsoft.MVC.ViewModels.Contact
{
    public class ContactPageViewModel
    {
        public SiteSettingsGetAllViewModel SiteSettings { get; set; }
        public ContactMessageCreateViewModel ContactMessage { get; set; }
    }
}
