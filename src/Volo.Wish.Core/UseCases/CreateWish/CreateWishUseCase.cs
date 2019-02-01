using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Wish.Core.Interfaces.Repositories;

namespace Volo.Wish.Core.UseCases.CreateWish
{
    public class CreateWishUseCase : ICreateWishUseCase
    {
        private readonly IWishRepository _wishRepository;
        private readonly IDistributedCache _cache;

        public CreateWishUseCase(IWishRepository wishRepository, IDistributedCache cache)
        {
            _wishRepository = wishRepository;
            _cache = cache;
        }

        public async Task<Domain.Wish> HandleAsync(CreateWishRequest request)
        {
            var currentTimeUtc = DateTime.UtcNow.ToString();
            byte[] encodedCurrentTimeUtc = Encoding.UTF8.GetBytes(currentTimeUtc);
            var options = new DistributedCacheEntryOptions()
                .SetSlidingExpiration(TimeSpan.FromSeconds(20));
            await _cache.SetAsync("cachedTimeUTC", encodedCurrentTimeUtc, options);

            return await _wishRepository.AddAsync(new Domain.Wish(request.Title, request.Description));
        }
    }
}