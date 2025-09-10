using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IAppUserRepository;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Persistence.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        private readonly BeldsoftContext _context;

        public AppUserRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<AppUser>> GetPagedUsersAsync(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) pageNumber = 1;
            if (pageSize < 1) pageSize = 10;

            return await _context.AppUsers
                .OrderBy(u => u.UserName) // İsteğe göre farklı sıralama
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<int> GetUserCountAsync()
        {
            return await _context.AppUsers.CountAsync();
        }

    }
}
