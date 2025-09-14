using Beldsoft.Application.Features.Child.Results;
using Beldsoft.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.Child.Queries.GetChildrenByParentPhone
{
    public class GetChildrenByParentPhoneQuery : IRequest<CommonResponse<List<GetAllChildForTodayResult>>>
    {
        public string ParentPhone { get; set; }

        public GetChildrenByParentPhoneQuery(string parentPhone)
        {
            ParentPhone = parentPhone;
        }
    }
}
