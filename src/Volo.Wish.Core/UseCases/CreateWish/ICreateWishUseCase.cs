using System.Threading.Tasks;

namespace Volo.Wish.Core.UseCases.CreateWish
{
    public interface ICreateWishUseCase
    {
        Task<Domain.Wish> HandleAsync(CreateWishRequest request);
    }
}