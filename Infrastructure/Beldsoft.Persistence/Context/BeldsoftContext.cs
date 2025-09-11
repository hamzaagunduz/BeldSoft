using Bedldsoft.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Beldsoft.Persistence.Context
{
    public class BeldsoftContext : IdentityDbContext<AppUser, AppRole, int>
    {

        public BeldsoftContext(DbContextOptions<BeldsoftContext> options) : base(options)
        {
        }

        // Domain tabloları
        public DbSet<AppUser> AppUsers { get; set; }      
        public DbSet<AppRole> AppRoles { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<HeroSection> HeroSections { get; set; }
        public DbSet<ServiceSection> ServiceSections { get; set; }

    }
}
