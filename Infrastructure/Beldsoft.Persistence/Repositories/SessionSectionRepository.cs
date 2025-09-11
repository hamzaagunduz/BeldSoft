using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;
using Beldsoft.Application.Interfaces.ISessionSectionRepository;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Persistence.Repositories
{
    public class SessionSectionRepository : Repository<SessionSection>, ISessionSectionRepository
    {
        private readonly BeldsoftContext _context;

        public SessionSectionRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
    }
}
