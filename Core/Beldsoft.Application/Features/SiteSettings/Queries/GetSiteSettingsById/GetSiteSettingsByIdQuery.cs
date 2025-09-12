using Beldsoft.Application.Features.SiteSettings.Results;
using Beldsoft.Application.Responses;
using MediatR;

namespace Beldsoft.Application.Features.SiteSettings.Queries.GetSiteSettingsById
{
    public class GetSiteSettingsByIdQuery : IRequest<CommonResponse<GetSiteSettingsByIdResult>>
    {
        public int Id { get; set; }

        public GetSiteSettingsByIdQuery(int id)
        {
            Id = id;
        }
    }
}
