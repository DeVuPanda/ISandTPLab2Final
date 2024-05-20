using System.ComponentModel.DataAnnotations;

namespace CardsShopAPIWebAppF.Models
{
    public class Firm
    {
        [Key]
        public int FirmId { get; set; }

        public string FirmName { get; set; } 

        public virtual ICollection<CardDeck> CardDecks { get; set; } = new List<CardDeck>();
    }
}
