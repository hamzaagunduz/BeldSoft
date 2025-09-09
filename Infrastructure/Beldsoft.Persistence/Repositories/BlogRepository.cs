using Bedldsoft.Domain.Entities;
using Beldsoft.Application.Interfaces.IBlogRepository;
using Beldsoft.Infrastructure.Repositories;
using Beldsoft.Persistence.Context;
using Microsoft.EntityFrameworkCore;

public class BlogRepository : Repository<Blog>, IBlogRepository
{
    private readonly BeldsoftContext _context;

    public BlogRepository(BeldsoftContext context) : base(context)
    {
        _context = context;

    }

    public async Task<IEnumerable<Blog>> GetRecentBlogsAsync(int count)
    {
        return await _context.Blogs
                             .OrderByDescending(b => b.CreatedAt)
                             .Take(count)
                             .ToListAsync();
    }
}
