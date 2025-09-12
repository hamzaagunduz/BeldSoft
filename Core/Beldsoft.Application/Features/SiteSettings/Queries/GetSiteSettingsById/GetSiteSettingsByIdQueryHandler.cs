using Beldsoft.Application.Features.SiteSettings.Results;
using Beldsoft.Application.Interfaces.ISiteSettingsRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.SiteSettings.Queries.GetSiteSettingsById
{
    public class GetSiteSettingsByIdQueryHandler : IRequestHandler<GetSiteSettingsByIdQuery, CommonResponse<GetSiteSettingsByIdResult>>
    {
        private readonly ISiteSettingsRepository _siteSettingsRepository;

        public GetSiteSettingsByIdQueryHandler(ISiteSettingsRepository siteSettingsRepository)
        {
            _siteSettingsRepository = siteSettingsRepository;
        }

        public async Task<CommonResponse<GetSiteSettingsByIdResult>> Handle(GetSiteSettingsByIdQuery request, CancellationToken cancellationToken)
        {
            var siteSettings = await _siteSettingsRepository.GetByIdAsync(request.Id);

            if (siteSettings == null)
                return CommonResponse<GetSiteSettingsByIdResult>.Fail(new[] { $"SiteSettings with Id {request.Id} not found." });

            var result = new GetSiteSettingsByIdResult
            {
                Id = siteSettings.Id,
                SiteName = siteSettings.SiteName,
                LogoUrl = siteSettings.LogoUrl,
                FooterLogoUrl = siteSettings.FooterLogoUrl,
                CopyrightText = siteSettings.CopyrightText,
                PhoneNumber = siteSettings.PhoneNumber,
                SupportPhone = siteSettings.SupportPhone,
                Email = siteSettings.Email,
                Address = siteSettings.Address,
                OpeningTime = siteSettings.OpeningTime,
                FacebookUrl = siteSettings.FacebookUrl,
                LinkedinUrl = siteSettings.LinkedinUrl,
                YoutubeUrl = siteSettings.YoutubeUrl,
                InstagramUrl = siteSettings.InstagramUrl,
                TermsUrl = siteSettings.TermsUrl,
                PrivacyPolicyUrl = siteSettings.PrivacyPolicyUrl,
                ContactPageUrl = siteSettings.ContactPageUrl,
                ParentQueryPageUrl = siteSettings.ParentQueryPageUrl
            };

            return CommonResponse<GetSiteSettingsByIdResult>.Success(result);
        }
    }
}
