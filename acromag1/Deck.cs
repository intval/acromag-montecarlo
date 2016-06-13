using System;
using System.Collections.Generic;
using System.Linq;

namespace acromag1
{
    public class Deck
    {
        readonly List<Card> _activeDeck;
        private readonly Random _rnd = new Random();

        public Deck(IEnumerable<Card> cards)
        {
            _activeDeck = cards.ToList();
            //_rnd.Shuffle(_activeDeck);
        }

        
        public IEnumerable<Card> EntireDeck => _activeDeck;

        public List<Card> GetCards(int amount)
        {
            if (amount == 0)
                return new List<Card>();

            var result = _activeDeck.GetRange(0, amount);
            _activeDeck.RemoveRange(0, amount);
            return result;
        }

        public void Shuffle()
        {
            _rnd.Shuffle(_activeDeck);
        }

        public void ShuffleTopHalf()
        {
            var size = _activeDeck.Count/2;
            var firstHalf = _activeDeck.GetRange(0, size);
            _rnd.Shuffle(firstHalf);
            _activeDeck.RemoveRange(0, size);
            _activeDeck.InsertRange(0, firstHalf);
        }

        public void PutCardBackInDeck(Card card)
        {
            var idx = _rnd.Next(_activeDeck.Count / 2, _activeDeck.Count + 1);
            _activeDeck.Insert(idx, card);
        }

        
    }
}