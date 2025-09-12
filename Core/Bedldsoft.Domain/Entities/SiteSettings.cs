using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Domain.Entities
{
    public class SiteSettings
    {
        public int Id { get; set; }

        // Genel Bilgiler
        public string? SiteName { get; set; }
        public string? LogoUrl { get; set; }
        public string? FooterLogoUrl { get; set; }
        public string? CopyrightText { get; set; }
        public string? GoogleMapAddress { get; set; }


        // İletişim Bilgileri
        public string? PhoneNumber { get; set; }
        public string? SupportPhone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? OpeningTime { get; set; }

        // Sosyal Medya
        public string? FacebookUrl { get; set; }
        public string? LinkedinUrl { get; set; }
        public string? YoutubeUrl { get; set; }
        public string? InstagramUrl { get; set; }

        // Footer Menü Linkleri
        public string? TermsUrl { get; set; }
        public string? PrivacyPolicyUrl { get; set; }
        public string? ContactPageUrl { get; set; }
        public string? ParentQueryPageUrl { get; set; }
    }
}
