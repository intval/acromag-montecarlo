using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using acromag1;

namespace MonteCarlo
{
    public class MonteCarloTree
    {
        public const int CardsPerHand = 6;
        private readonly Node _root;
        public static readonly Random Rand = new Random();
        private readonly Game _game;
        private static readonly object LockObj = new object();

        public MonteCarloTree(List<Card> initialCardsInHand, Game currentGame)
        {
            _root = new Node(null, initialCardsInHand, null);
            _game = currentGame;
        }

        public CardAction GetBestNextPlay()
        {
            if (!_root.OriginalCardsUpToHere.Any())
                throw new Exception("No cards in hand?");

            Run();

            return _root.Children.MaxBy(n => n.Reward/n.Visits).Action;
        }

        private void Run()
        {
            Parallel.For(0, 100000, i => SimulateGame());
        }

        private void SimulateGame()
        {
            // randomization
            var unseenCards = GameCards.Cards.Except(_root.OriginalCardsUpToHere);
            var deck = new Deck(unseenCards);
            deck.Shuffle();
            var opHand = deck.GetCards(CardsPerHand);
            var aiHand = _root.OriginalCardsUpToHere.ToList();
            var simulationGame = ObjectCopier.Clone(_game);

            var reward = 0;

            // selection
            var node = _root;
            var depth = 0;

            while (node.Children.Count > 0 && depth++ <= CardsPerHand + 1)
            {
                node = node.Children.ToArray()
                    .Where(n => n.Action is DropCardAction || CardAction.CanPlay(n.Action.Card, simulationGame.GameState[Game.Player.Ai]))
                    .MaxBy(k => k.Ucb);

                var myPlay = MakePlay(simulationGame, aiHand, Game.Player.Ai, deck);

                switch (myPlay)
                {
                    case Game.ActionResult.GameWon:
                        Backpropagation(node, 1);
                        return;
                    case Game.ActionResult.GameLost:
                        Backpropagation(node, -1);
                        return;
                }

                var opPlay = MakePlay(simulationGame, opHand, Game.Player.Opponent, deck);

                switch (opPlay)
                {
                    case Game.ActionResult.GameWon:
                        Backpropagation(node, -1);
                        return;

                    case Game.ActionResult.GameLost:
                        return;
                }
            }



            if (node.Children.Count == 0)
            {
                lock (LockObj)
                {
                    if (node.Children.Count == 0)
                    {
                        // create possible moves from this node
                        foreach (var action in PossiblePlaysFromState(aiHand, simulationGame, Game.Player.Ai))
                        {
                            var newNode = new Node(node, node.OriginalCardsUpToHere.Except(new[] { action.Card }).ToList(), action);
                            node.Children.Add(newNode);
                        }
                    }
                }
            }
            

            var possibleNodes = node.Children.ToArray()
                .Where(
                    n =>
                        n.Action is DropCardAction ||
                        CardAction.CanPlay(n.Action.Card, simulationGame.GameState[Game.Player.Ai])).ToArray();

            node = possibleNodes.ElementAt(Rand.Next(0, possibleNodes.Length));
            MakePlay(simulationGame, node.Action, aiHand, Game.Player.Ai, deck);


            reward = PlayGameToEnd(aiHand, opHand, simulationGame, deck, Game.Player.Opponent);


            Backpropagation(node, reward);
        }

        public int PlayGameToEnd(List<Card> aiHand, List<Card> opHand, Game simulationGame, Deck deck, Game.Player activePlayer)
        {
            var simulationLength = 250;
            var reward = 0;

            while (simulationLength-- > 0)
            {
                var currentHand = activePlayer == Game.Player.Ai ? aiHand : opHand;
                var playOutcome = MakePlay(simulationGame, currentHand, activePlayer, deck);

                if (playOutcome == Game.ActionResult.GameWon)
                {
                    reward = activePlayer == Game.Player.Ai ? 1 : -1;
                    break;
                }

                if (playOutcome == Game.ActionResult.GameLost)
                {
                    reward = activePlayer == Game.Player.Ai ? -1 : 0;
                    break;
                }


                activePlayer = activePlayer == Game.Player.Ai ? Game.Player.Opponent : Game.Player.Ai;
            }

            return reward;
        }

        private static void Backpropagation(Node node, int reward)
        {
            do
            {
                Interlocked.Add(ref node.Reward, reward);
                Interlocked.Increment(ref node.Visits);
                node = node.Parent;
            } while (node.Parent != null);
        }

        private Game.ActionResult MakePlay(Game game, List<Card> hand, Game.Player playerMakingTheMove, Deck deck)
        {
            var action = ChooseRandomAction(hand, game, playerMakingTheMove);
            return MakePlay(game, action, hand, playerMakingTheMove, deck);
        }

        private Game.ActionResult MakePlay(Game game, CardAction action, List<Card> hand, Game.Player playerMakingTheMove, Deck deck)
        {

            var actionResult = game.ApplyAction(action, playerMakingTheMove);
            UpdateHand(action.Card, hand, deck);

            if (actionResult == Game.ActionResult.PlayAgain)
                return MakePlay(game, hand, playerMakingTheMove, deck);

            if (actionResult == Game.ActionResult.DropAndPlayAgain)
            {
                // todo: drop non random card
                var randomCard = hand.ElementAt(Rand.Next(0, hand.Count));
                game.ApplyAction(new DropCardAction(randomCard), playerMakingTheMove);
                UpdateHand(randomCard, hand, deck);
                return MakePlay(game, hand, playerMakingTheMove, deck);
            }

            return actionResult;
        }

        private void UpdateHand(Card thrownCard, List<Card> hand, Deck deck)
        {
            deck.PutCardBackInDeck(thrownCard);
            hand.Remove(thrownCard);
            hand.AddRange(deck.GetCards(1));
        }

        private List<CardAction> PossiblePlaysFromState(List<Card> hand, Game state, Game.Player activePlayer)
        {
            var actions = new List<CardAction>();
            actions.AddRange(hand.Select(c => new DropCardAction(c)));

            var playableCards = hand
                .Where(c => CardAction.CanPlay(c, state.GameState[activePlayer]))
                .Select(c => new PlayCardAction(c));

            actions.AddRange(playableCards);

            return actions;
        }

        private CardAction ChooseRandomAction(List<Card> hand, Game state, Game.Player activePlayer)
        {
            var actions = PossiblePlaysFromState(hand, state, activePlayer);
            // todo, choose the card the definitely leads to victory, or twice luckier to play then drop
            return actions.ElementAt(Rand.Next(0, actions.Count));
        }

        public string PrintTree()
        {
            var sb = new StringBuilder("graph Boo {\r\n");
            PrintTree(_root, sb);
            sb.AppendLine("}");
            return sb.ToString();
        }

        private static void PrintTree(Node n, StringBuilder sb)
        {
            sb.AppendLine(n.Id + " [label=\""+n+"\"]");
            foreach (var child in n.Children)
            {
                sb.AppendLine(n.Id + " -- " + child.Id);
                PrintTree(child, sb);
            }
        }

    }

    public class Node
    {
        public int Reward;
        public int Visits = 1;
        public Node Parent;
        public CardAction Action;
        public List<Card> OriginalCardsUpToHere;
        public readonly List<Node> Children = new List<Node>();
        public string Id;
        public static readonly Random Rand = new Random();

        public Node(Node parentNode, List<Card> originalCards, CardAction actionOfNode)
        {
            Parent = parentNode;
            OriginalCardsUpToHere = originalCards;
            Action = actionOfNode;
            Id = Rand.Next(99999, int.MaxValue).ToString();
        }

        public double Ucb => (double)Reward/Visits + 0.9*Math.Sqrt(Math.Log(Parent.Visits) / Visits);

        public override string ToString()
        {
            return Reward + "/" + Visits + " [" + string.Join(", ",  OriginalCardsUpToHere.Select(c => c.Id)) + "] --> " + Action;
        }
    }
}
