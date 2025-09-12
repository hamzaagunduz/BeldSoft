using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Application.Interfaces.IFeedbackSectionRepository;
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
    public class ContactMessageRepository : Repository<ContactMessage>, IContactMessageRepository
    {
        private readonly BeldsoftContext _context;

        public ContactMessageRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
    }
}
