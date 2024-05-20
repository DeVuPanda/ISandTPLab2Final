using System.ComponentModel.DataAnnotations;

namespace CardsShopAPIWebAppF.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string Review1 { get; set; } = null!;

        public int DeckId { get; set; }

        public virtual CardDeck Deck { get; set; } = null!;
    }
}
