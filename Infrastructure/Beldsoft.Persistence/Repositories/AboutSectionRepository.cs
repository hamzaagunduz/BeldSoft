using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IAboutSectionRepository;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beldsoft.Persistence.Repositories
{

    public class AboutSectionRepository:Repository<AboutSection>,IAboutSectionRepository
    {
        private readonly BeldsoftContext _context;

        public AboutSectionRepository(BeldsoftContext context):base(context)
        {
            _context = context;
        }
    }
}
