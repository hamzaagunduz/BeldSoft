using Beldsoft.Application.Features.SiteSettings.Results;
using Beldsoft.Application.Interfaces.ISiteSettingsRepository;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.SiteSettings.Queries.GetAllSiteSettings
{
    public class GetAllSiteSettingsQueryHandler : IRequestHandler<GetAllSiteSettingsQuery, CommonResponse<List<GetAllSiteSettingsResult>>>
    {
        private readonly ISiteSettingsRepository _siteSettingsRepository;

        public GetAllSiteSettingsQueryHandler(ISiteSettingsRepository siteSettingsRepository)
        {
            _siteSettingsRepository = siteSettingsRepository;
        }

        public async Task<CommonResponse<List<GetAllSiteSettingsResult>>> Handle(GetAllSiteSettingsQuery request, CancellationToken cancellationToken)
        {
            var siteSettingsList = await _siteSettingsRepository.GetAllAsync();

            var result = siteSettingsList.Select(s => new GetAllSiteSettingsResult
            {
                Id = s.Id,
                SiteName = s.SiteName,
                LogoUrl = s.LogoUrl,
                FooterLogoUrl = s.FooterLogoUrl,
                GoogleMapAddress=s.GoogleMapAddress,
                CopyrightText = s.CopyrightText,
                PhoneNumber = s.PhoneNumber,
                SupportPhone = s.SupportPhone,
                Email = s.Email,
                Address = s.Address,
                OpeningTime = s.OpeningTime,
                FacebookUrl = s.FacebookUrl,
                LinkedinUrl = s.LinkedinUrl,
                YoutubeUrl = s.YoutubeUrl,
                InstagramUrl = s.InstagramUrl,
                TermsUrl = s.TermsUrl,
                PrivacyPolicyUrl = s.PrivacyPolicyUrl,
                ContactPageUrl = s.ContactPageUrl,
                ParentQueryPageUrl = s.ParentQueryPageUrl
            }).ToList();

            return CommonResponse<List<GetAllSiteSettingsResult>>.Success(result);
        }
    }
}
