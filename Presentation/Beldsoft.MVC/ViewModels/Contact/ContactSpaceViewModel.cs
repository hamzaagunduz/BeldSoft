using Beldsoft.MVC.ViewModels.SiteSettings;

namespace Beldsoft.MVC.ViewModels.Contact
{
    public class ContactSpaceViewModel
    {
        public SiteSettingsGetAllViewModel SiteSettings { get; set; }
        public ContactMessageCreateViewModel ContactMessage { get; set; }
    }
}
