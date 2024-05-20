using System.ComponentModel.DataAnnotations;

namespace CardsShopAPIWebAppF.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }

        public string OrderStatus { get; set; } = null!;

        public string PersonName { get; set; } = null!;

        public string PersonPhone { get; set; } = null!;

        public string DeliveryAddress { get; set; } = null!;

        public int DeckId { get; set; }

        public virtual CardDeck Deck { get; set; } = null!;
    }
}
