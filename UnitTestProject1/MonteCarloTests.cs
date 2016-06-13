using System;
using System.Collections.Generic;
using System.Diagnostics;
using acromag1;
using MonteCarlo;
using NUnit.Framework;

namespace UnitTestProject1
{
    [TestFixture]
    internal class MonteCarloTests
    {
        private Deck _deck;
        private List<Card> _myHand;
        private Game _game;
        private MonteCarloTree _mt;

        [SetUp]
        public void Setup()
        {
            _deck = new Deck(GameCards.Cards);
            _deck.Shuffle();
            _myHand = _deck.GetCards(6);
            _game = new Game(Game.Player.Ai);
            _mt = new MonteCarloTree(_myHand, _game);
        }

        [Test]
        public void TestMt()
        {
            var watch = Stopwatch.StartNew();

            var bestNext = _mt.GetBestNextPlay();
            watch.Stop();

            var g = _mt.PrintTree();
            System.IO.File.WriteAllText(@"C:\Users\sasha\Desktop\a.txt", g);
            Console.WriteLine(watch);
            Assert.True(true);
        }

        [Test]
        public void IsGameFinite()
        {
            var opHand = _deck.GetCards(6);
            var rewardForAi = _mt.PlayGameToEnd(_myHand, opHand, _game, _deck, Game.Player.Ai);
            Assert.True(true);
        }
    }
}
