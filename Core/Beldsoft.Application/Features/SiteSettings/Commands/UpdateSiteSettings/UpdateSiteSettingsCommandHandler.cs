using Beldsoft.Application.Interfaces.ISiteSettingsRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.SiteSettings.Commands.UpdateSiteSettings
{
    public class UpdateSiteSettingsCommandHandler : IRequestHandler<UpdateSiteSettingsCommand, CommonResponse<int>>
    {
        private readonly ISiteSettingsRepository _siteSettingsRepository;

        public UpdateSiteSettingsCommandHandler(ISiteSettingsRepository siteSettingsRepository)
        {
            _siteSettingsRepository = siteSettingsRepository;
        }

        public async Task<CommonResponse<int>> Handle(UpdateSiteSettingsCommand request, CancellationToken cancellationToken)
        {
            var siteSettings = await _siteSettingsRepository.GetByIdAsync(request.Id);
            if (siteSettings == null)
                return CommonResponse<int>.Fail(new[] { "SiteSettings bulunamadý" });

            // Genel Bilgiler
            siteSettings.SiteName = request.SiteName;
            siteSettings.LogoUrl = request.LogoUrl;
            siteSettings.FooterLogoUrl = request.FooterLogoUrl;
            siteSettings.CopyrightText = request.CopyrightText;
            siteSettings.GoogleMapAddress = request.GoogleMapAddress;

            // Ýletiþim Bilgileri
            siteSettings.PhoneNumber = request.PhoneNumber;
            siteSettings.SupportPhone = request.SupportPhone;
            siteSettings.Email = request.Email;
            siteSettings.Address = request.Address;
            siteSettings.OpeningTime = request.OpeningTime;

            // Sosyal Medya
            siteSettings.FacebookUrl = request.FacebookUrl;
            siteSettings.LinkedinUrl = request.LinkedinUrl;
            siteSettings.YoutubeUrl = request.YoutubeUrl;
            siteSettings.InstagramUrl = request.InstagramUrl;

            // Footer Menü Linkleri
            siteSettings.TermsUrl = request.TermsUrl;
            siteSettings.PrivacyPolicyUrl = request.PrivacyPolicyUrl;
            siteSettings.ContactPageUrl = request.ContactPageUrl;
            siteSettings.ParentQueryPageUrl = request.ParentQueryPageUrl;

            await _siteSettingsRepository.UpdateAsync(siteSettings);

            return CommonResponse<int>.Success(siteSettings.Id);
        }
    }
}
