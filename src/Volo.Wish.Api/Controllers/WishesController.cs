using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Volo.Wish.Api.Models;
using Volo.Wish.Core.UseCases.CreateWish;
using Volo.Wish.Core.UseCases.GetWishes;

namespace Volo.Wish.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishesController : ControllerBase
    {
        private readonly ICreateWishUseCase _createWishUseCase;
        private readonly IGetWishesUseCase _getWishesUseCase;
        private readonly IDistributedCache _cache;

        public WishesController(ICreateWishUseCase createWishUseCase, IGetWishesUseCase getWishesUseCase, IDistributedCache cache)
        {
            _createWishUseCase = createWishUseCase;
            _getWishesUseCase = getWishesUseCase;
            _cache = cache;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishDto>>> Get()
        {
            var wishes = await _getWishesUseCase.HandleAsync();

            return Ok(wishes.Select(WishDto.FromWish));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateWishRequest createWishRequest)
        {
            var wish = await _createWishUseCase.HandleAsync(createWishRequest);

            return Created("/api/wishes/" + wish.Id, wish.Id);
        }

        [Route("lastupdate")]
        [HttpGet]
        public async Task<ActionResult<string>> GetLastUpdate()
        {
            var cachedTimeUTC = "Cached Time Expired";
            var encodedCachedTimeUTC = await _cache.GetAsync("cachedTimeUTC");

            if (encodedCachedTimeUTC != null)
            {
                cachedTimeUTC = Encoding.UTF8.GetString(encodedCachedTimeUTC);
            }

            return Ok(cachedTimeUTC);
        }
    }
}
