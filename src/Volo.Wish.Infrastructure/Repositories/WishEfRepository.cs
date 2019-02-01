using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Wish.Core.Interfaces.Repositories;

namespace Volo.Wish.Infrastructure.Repositories
{
    public class WishEfRepository : IWishRepository
    {
        private readonly AppDbContext _dbContext;

        public WishEfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Core.Domain.Wish> AddAsync(Core.Domain.Wish wish)
        {
            await _dbContext.Set<Core.Domain.Wish>().AddAsync(wish);
            await _dbContext.SaveChangesAsync();

            return wish;
        }

        public async Task<ReadOnlyCollection<Core.Domain.Wish>> ListAsync()
        {
            var result = await _dbContext.Set<Core.Domain.Wish>().ToListAsync();

            return new ReadOnlyCollection<Core.Domain.Wish>(result);
        }
    }
}