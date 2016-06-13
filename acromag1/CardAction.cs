namespace acromag1
{
    public abstract class CardAction
    {
        public Card Card;

        protected CardAction(Card card)
        {
            Card = card;
        }

        public static bool CanPlay(Card c, Game.World w)
        {
            return w.Stack >= c.CostStacks && w.Ore >= c.CostOre && w.Mana >= c.CostMana;
        }
    }

    public class PlayCardAction : CardAction
    {
        public PlayCardAction(Card c) : base(c)
        {
        }

        public override string ToString()
        {
            return "P" + Card.Id;
        }
    }

    public class DropCardAction : CardAction
    {
        public DropCardAction(Card c) : base(c)
        {
        }

        public override string ToString()
        {
            return "D" + Card.Id;
        }
    }
}