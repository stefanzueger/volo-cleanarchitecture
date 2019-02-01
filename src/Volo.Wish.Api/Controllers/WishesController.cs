using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public WishesController(ICreateWishUseCase createWishUseCase, IGetWishesUseCase getWishesUseCase)
        {
            _createWishUseCase = createWishUseCase;
            _getWishesUseCase = getWishesUseCase;
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WishDto>>> Get()
        {
            var wishes = await _getWishesUseCase.HandleAsync();

            return Ok(wishes.Select(WishDto.FromWish));
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CreateWishRequest createWishRequest)
        {
            var wish = await _createWishUseCase.HandleAsync(createWishRequest);

            return Created("/api/wishes/", wish.Id);
        }
    }
}
