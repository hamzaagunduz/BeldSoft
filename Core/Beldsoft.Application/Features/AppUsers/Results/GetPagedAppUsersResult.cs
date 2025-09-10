using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Features.AppUsers.Results
{
    public class GetPagedAppUsersResult
    {
        public List<GetAllAppUsersResult> Users { get; set; }
        public int TotalCount { get; set; }
    }
}
