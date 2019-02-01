using System;

namespace Volo.Wish.Core.Domain
{
    public class Wish
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? FulfillmentDate { get; set; }

        public Wish(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void Fulfill()
        {
            FulfillmentDate = DateTime.UtcNow;
        }
    }
}