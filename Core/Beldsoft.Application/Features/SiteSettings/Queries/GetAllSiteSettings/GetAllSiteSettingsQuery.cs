using Beldsoft.Application.Features.SiteSettings.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System.Collections.Generic;

namespace Beldsoft.Application.Features.SiteSettings.Queries.GetAllSiteSettings
{
    public class GetAllSiteSettingsQuery : IRequest<CommonResponse<List<GetAllSiteSettingsResult>>>
    {
        // Ýleride filtreleme veya sayfalama için property eklenebilir
    }
}
