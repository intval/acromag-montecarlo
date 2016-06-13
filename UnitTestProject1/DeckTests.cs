using System.Collections.Generic;
using System.Linq;
using acromag1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace UnitTestProject1
{
    [TestFixture]
    public class DeckTests
    {
        [Test]
        public void TestMethod1()
        {
            var card = new Card();
            var deck = new Deck(new[] {card});
            var fetched = deck.GetCards(1);
            var end = deck.EntireDeck;
            Assert.AreEqual(0, end.Count());
            Assert.AreSame(fetched.FirstOrDefault(), card);
        }

        [Test]
        public void TestMethod2()
        {
            var x = new Dictionary<int, int>();

            for (var i = 0; i < 3000; i++)
            {
                var card = new Card();
                var deck = new Deck(new[] {new Card(), new Card(), new Card(), new Card()});
                deck.PutCardBackInDeck(card);
                var foundIdx = deck.EntireDeck.ToList().FindIndex(c => c == card);

                if (!x.ContainsKey(foundIdx))
                    x[foundIdx] = 1;
                else
                    x[foundIdx] = x[foundIdx] + 1;
            }


            Assert.IsTrue(x.Keys.SequenceEqual(new[] {2, 3, 4}));
        }
    }
}