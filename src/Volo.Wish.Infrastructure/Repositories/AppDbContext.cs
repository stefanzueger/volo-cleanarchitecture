using Microsoft.EntityFrameworkCore;

namespace Volo.Wish.Infrastructure.Repositories
{
    public class AppDbContext : DbContext
    {
        public DbSet<Core.Domain.Wish> Wishes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }
}