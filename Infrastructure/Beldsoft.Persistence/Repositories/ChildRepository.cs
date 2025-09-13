using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Domain.Entities;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Persistence.Repositories
{
    public class ChildRepository : Repository<Child>, IChildRepository
    {
        private readonly BeldsoftContext _context;

        public ChildRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
    }
}
