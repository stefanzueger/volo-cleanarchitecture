using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Volo.Wish.Core.UseCases.GetWishes
{
    public interface IGetWishesUseCase
    {
        Task<ReadOnlyCollection<Domain.Wish>> HandleAsync();
    }
}