using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Volo.Wish.Core.Interfaces.Repositories;

namespace Volo.Wish.Core.UseCases.GetWishes
{
    public class GetWishesUseCase : IGetWishesUseCase
    {
        private readonly IWishRepository _repository;

        public GetWishesUseCase(IWishRepository repository)
        {
            _repository = repository;
        }

        public Task<ReadOnlyCollection<Domain.Wish>> HandleAsync()
        {
            return _repository.ListAsync();
        }
    }
}