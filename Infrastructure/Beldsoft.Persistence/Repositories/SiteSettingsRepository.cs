using Beldsoft.Application.Interfaces.IGallerySectionRepository;
using Beldsoft.Application.Interfaces.ISiteSettingsRepository;
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
    public class SiteSettingsRepository : Repository<SiteSettings>, ISiteSettingsRepository
    {
        private readonly BeldsoftContext _context;

        public SiteSettingsRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
    }
}
