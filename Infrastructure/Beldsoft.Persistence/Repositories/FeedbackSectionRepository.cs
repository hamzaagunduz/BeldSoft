using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using Beldsoft.Application.Interfaces.IFeedbackSectionRepository;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Persistence.Repositories
{
    public class FeedbackSectionRepository : Repository<FeedbackSection>, IFeedbackSectionRepository
    {
        private readonly BeldsoftContext _context;

        public FeedbackSectionRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
    }
}

