using Beldsoft.Application.Features.SiteSettings.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.SiteSettings.Queries.GetAllSiteSettings
{
    public class GetAllSiteSettingsQuery : IRequest<CommonResponse<List<GetAllSiteSettingsResult>>>
    {
        // �leride filtreleme veya sayfalama i�in property eklenebilir
    }
}
