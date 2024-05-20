using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace CardsShopAPIWebAppF.Models
{
    public class CardDeck
    {
        [Key]
        public int DeckId { get; set; }

        public int NumberOfCards { get; set; }

        public string Description { get; set; } = null!;

        public string DeckName { get; set; } = null!;

        public double DeckPrice { get; set; }

        public int FirmId { get; set; }

        public virtual Firm Firm { get; set; } = null!;

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

        public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    }
}
