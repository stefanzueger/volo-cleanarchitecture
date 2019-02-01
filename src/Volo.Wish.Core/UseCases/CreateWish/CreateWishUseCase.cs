using System.Threading.Tasks;
using Volo.Wish.Core.Interfaces.Repositories;

namespace Volo.Wish.Core.UseCases.CreateWish
{
    public class CreateWishUseCase : ICreateWishUseCase
    {
        private readonly IWishRepository _wishRepository;

        public CreateWishUseCase(IWishRepository wishRepository)
        {
            _wishRepository = wishRepository;
        }

        public Task<Domain.Wish> HandleAsync(CreateWishRequest request)
        {
            return _wishRepository.AddAsync(new Domain.Wish(request.Title, request.Description));
        }
    }
}