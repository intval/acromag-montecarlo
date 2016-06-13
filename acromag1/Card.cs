using System;

namespace acromag1
{
    public class Card
    {
        public int Id = -1;

        public int Barracks = 0;
        public int CostMana = 0;

        public int CostOre = 0;
        public int CostStacks = 0;

        public int Damage = 0;
        public bool DiscardOneAfter = false;
        public int Mana = 0;

        public int Mine = 0;
        public int Monastery = 0;
        public int OpBarracks = 0;
        public int OpMana = 0;

        public int OpMine = 0;
        public int OpMonastery = 0;

        public int OpOre = 0;
        public int OpStack = 0;
        public int OpTower = 0;
        public int OpWall = 0;

        public int Ore = 0;
        public bool PlayAgain = false;
        public int SelfDamage = 0;


        public Action<Game.World, Game.World> SpecialCase = (w,w2) => { };
        public int Stack = 0;

        public int Tower = 0;

        public int Wall = 0;

        public override string ToString()
        {
            return Id.ToString();
        }
    }
}