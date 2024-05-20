using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CardsShopAPIWebAppF.Models;

namespace CardsShopAPIWebAppF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CardDecksController : ControllerBase
    {
        private readonly CardsShopAPIContext _context;

        public CardDecksController(CardsShopAPIContext context)
        {
            _context = context;
        }

        // GET: api/CardDecks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardDeck>>> GetCardDecks()
        {
            return await _context.CardDecks.ToListAsync();
        }

        // GET: api/CardDecks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CardDeck>> GetCardDeck(int id)
        {
            var cardDeck = await _context.CardDecks.FindAsync(id);

            if (cardDeck == null)
            {
                return NotFound();
            }

            return cardDeck;
        }

        // PUT: api/CardDecks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCardDeck(int id, CardDeck cardDeck)
        {
            if (id != cardDeck.DeckId)
            {
                return BadRequest();
            }

            _context.Entry(cardDeck).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CardDeckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/CardDecks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CardDeck>> PostCardDeck(CardDeck cardDeck)
        {
            _context.CardDecks.Add(cardDeck);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCardDeck", new { id = cardDeck.DeckId }, cardDeck);
        }

        // DELETE: api/CardDecks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCardDeck(int id)
        {
            var cardDeck = await _context.CardDecks.FindAsync(id);
            if (cardDeck == null)
            {
                return NotFound();
            }

            _context.CardDecks.Remove(cardDeck);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CardDeckExists(int id)
        {
            return _context.CardDecks.Any(e => e.DeckId == id);
        }
    }
}
