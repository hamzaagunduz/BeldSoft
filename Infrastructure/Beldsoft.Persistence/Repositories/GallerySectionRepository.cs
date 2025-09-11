using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IGallerySectionRepository;
using Beldsoft.Application.Interfaces.IHeroSectionRepository;
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
    public class GallerySectionRepository : Repository<GallerySection>, IGallerySectionRepository
    {
        private readonly BeldsoftContext _context;

        public GallerySectionRepository(BeldsoftContext context) : base(context)
        {
            _context = context;
        }
    }
}
