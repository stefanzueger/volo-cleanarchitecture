using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Volo.Wish.Core.Interfaces.Repositories;

namespace Volo.Wish.Infrastructure.Repositories
{
    public class InMemoryWishRepository : IWishRepository
    {
        private List<Core.Domain.Wish> _wishes;

        public InMemoryWishRepository()
        {
            _wishes = new List<Core.Domain.Wish>();
        }

        public Task<Core.Domain.Wish> AddAsync(Core.Domain.Wish wish)
        {
            wish.Id = _wishes.Count + 1;
            _wishes.Add(wish);

            return Task.FromResult(wish);
        }

        public Task<ReadOnlyCollection<Core.Domain.Wish>> ListAsync()
        {
            return Task.FromResult(new ReadOnlyCollection<Core.Domain.Wish>(_wishes));
        }
    }
}