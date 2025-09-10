using Bedldsoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Application.Interfaces.IAppUserRepository
{
    public interface IAppUserRepository : IRepository<AppUser>
    {
        Task<List<AppUser>> GetPagedUsersAsync(int pageNumber, int pageSize);

        Task<int> GetUserCountAsync();

    }
}