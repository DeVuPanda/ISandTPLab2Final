using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CardsShopAPIWebAppF.Models
{
    public class CardsShopAPIContext: DbContext
    {
        public virtual DbSet<CardDeck> CardDecks { get; set; }

        public virtual DbSet<Firm> Firms { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Question> Questions { get; set; }

        public virtual DbSet<Review> Reviews { get; set; }

        public CardsShopAPIContext(DbContextOptions<CardsShopAPIContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
