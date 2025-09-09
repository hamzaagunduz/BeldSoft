using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IAppUserRepository;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
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

   
    }
}
