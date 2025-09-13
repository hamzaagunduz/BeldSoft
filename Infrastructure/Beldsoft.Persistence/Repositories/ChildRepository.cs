using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IChildRepository;
using Beldsoft.Application.Interfaces.IContactMessageRepository;
using Beldsoft.Domain.Entities;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Child>> GetChildrenForTodayAsync()
        {
            var today = DateTime.Now.Date;

            var children = await _context.Childs
                .Where(c => c.ArrivalTime.HasValue && c.ArrivalTime.Value.Date == today)
                .ToListAsync();

            var ordered = children
                .OrderBy(c => c.IsExpired ?? false) // false önce
                .ThenBy(c =>
                    !(c.IsExpired ?? false)
                        ? (c.ExpirationTime?.Ticks ?? long.MaxValue)        // false: artan Ticks
                        : -(c.ExpirationTime?.Ticks ?? long.MaxValue)      // true: azalan Ticks
                )
                .ToList();


            return ordered;
        }



        public async Task<List<Child>> GetChildrenByParentPhoneAsync(string parentPhone)
        {
            if (string.IsNullOrWhiteSpace(parentPhone))
                return new List<Child>();

            return await _context.Childs
                .Where(c => c.ParentPhone == parentPhone)
                .ToListAsync();
        }
    }
}
