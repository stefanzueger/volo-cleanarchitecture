using System;

namespace Volo.Wish.Api.Models
{
    public class WishDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? FulfillmentDate { get; set; }

        public static WishDto FromWish(Core.Domain.Wish wish)
        {
            return new WishDto
            {
                Id = wish.Id,
                Title = wish.Title,
                Description = wish.Description,
                FulfillmentDate = wish.FulfillmentDate
            };
        }
    }
}