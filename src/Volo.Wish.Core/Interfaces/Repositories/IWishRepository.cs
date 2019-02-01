using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Volo.Wish.Core.Interfaces.Repositories
{
    public interface IWishRepository
    {
        Task<Domain.Wish> AddAsync(Domain.Wish wish);

        Task<ReadOnlyCollection<Domain.Wish>> ListAsync();
    }
}