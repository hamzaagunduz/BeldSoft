using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using Beldsoft.Persistence.Context;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Application.Interfaces.IServiceSectionRepository;


namespace Beldsoft.Persistence.Repositories
{
    public class ServiceSectionRepository : Repository<ServiceSection>, IServiceSectionRepository
    {
        private readonly BeldsoftContext _context;

        public ServiceSectionRepository(BeldsoftContext context) : base(context)
        {
                _context = context;
        }
    }
}