using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
using Beldsoft.Persistence.Context;
using Beldsoft.Infrastructure.Repositories;


namespace Beldsoft.Persistence.Repositories
{
    public class HeroSectionRepository : Repository<HeroSection>, IHeroSectionRepository
    {
        private readonly BeldsoftContext _context;

        public HeroSectionRepository(BeldsoftContext context) : base(context)
        {
                _context = context;
        }
    }
}