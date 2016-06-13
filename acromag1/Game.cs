using System;
using System.Collections.Generic;

namespace acromag1
{
    [Serializable]
    public class Game
    {
        private readonly int _winTower;
        private readonly int _winResource;

        public Dictionary<Player, World> GameState = new Dictionary<Player, World>(2);

        public Game(Player firstToPlay, int winTower = 50, int winResource = 150, 
            int startTower = 20, int startWall = 5, 
            int startMine = 2, int startMonastery = 2, int startBarracks = 2,
            int startOre = 5, int startMana = 5, int startStacks = 5)
        {
            _winTower = winTower;
            _winResource = winResource;

            GameState.Add(Player.Ai, new World
            {
                Tower = startTower,
                Wall = startWall,
                Ore = startOre,
                Mana = startMana,
                Stack = startStacks,
                Mine = startMine,
                Monastery = startMonastery,
                Barracks = startBarracks
            });

            GameState.Add(Player.Opponent, new World
            {
                Tower = startTower,
                Wall = startWall,
                Ore = startOre,
                Mana = startMana,
                Stack = startStacks,
                Mine = startMine,
                Monastery = startMonastery,
                Barracks = startBarracks
            });

            IncreaseResourcesForNextPlayer(GameState[firstToPlay]);
        }


        public Result HasWon(Player whoPlayed)
        {
            var myState = GameState[whoPlayed];
            var opState = GameState[whoPlayed == Player.Ai ? Player.Ai : Player.Opponent];

            if (opState.Tower < 1)
                return Result.Won;

            if (myState.Tower < 1)
                return Result.Lost;

            if(myState.Tower >= _winTower)
                return Result.Won;

            if(opState.Tower >= _winTower)
                return Result.Lost;


            if (myState.Ore >= _winResource && myState.Mana >= _winResource && myState.Stack >= _winResource)
                return Result.Won;
            
            if (opState.Ore > _winResource && opState.Mana > _winResource && opState.Stack > _winResource)
                return Result.Lost;

            return Result.NotOver;
        }

        public ActionResult ApplyAction(CardAction action, Player currentPlayer)
        {

            var opponent = currentPlayer != Player.Ai ? Player.Ai : Player.Opponent;

            
            if (action is PlayCardAction)
            {
                #region action
                var me = GameState[currentPlayer];
                var op = GameState[opponent];

                action.Card.SpecialCase(me, op);

                me.Ore = Math.Max(0, me.Ore - action.Card.CostOre);
                me.Mana = Math.Max(0, me.Mana - action.Card.CostMana);
                me.Stack = Math.Max(0, me.Stack - action.Card.CostStacks);

                me.Ore = Math.Max(0, me.Ore + action.Card.Ore);
                me.Mana = Math.Max(0, me.Mana + action.Card.Mana);
                me.Stack = Math.Max(0, me.Stack + action.Card.Stack);

                me.Barracks = Math.Max(0, me.Barracks + action.Card.Barracks);
                me.Monastery = Math.Max(0, me.Monastery + action.Card.Monastery);
                me.Mine = Math.Max(0, me.Mine + action.Card.Mine);
                me.Wall = Math.Max(0, me.Wall + action.Card.Wall);
                me.Tower += action.Card.Tower;


                op.Ore = Math.Max(0, op.Ore + action.Card.OpOre);
                op.Mana = Math.Max(0, op.Mana + action.Card.OpMana);
                op.Stack = Math.Max(0, op.Stack + action.Card.OpStack);

                op.Barracks = Math.Max(0, op.Barracks + action.Card.OpBarracks);
                op.Monastery = Math.Max(0, op.Monastery + action.Card.OpMonastery);
                op.Mine = Math.Max(0, op.Mine + action.Card.OpMine);
                op.Wall = Math.Max(0, op.Wall + action.Card.OpWall);
                op.Tower += action.Card.OpTower;

                op.Wall -= action.Card.Damage;
                if (op.Wall < 0)
                {
                    op.Tower += op.Wall;
                    op.Wall = 0;
                }

                me.Wall -= action.Card.SelfDamage;
                if (me.Wall < 0)
                {
                    me.Tower += me.Wall;
                    me.Wall = 0;
                }
                #endregion

                if(HasWon(currentPlayer) == Result.Won)
                    return ActionResult.GameWon;

                if (HasWon(currentPlayer) == Result.Lost)
                    return ActionResult.GameLost;

                if(action.Card.DiscardOneAfter)
                    return ActionResult.DropAndPlayAgain;

                if (action.Card.PlayAgain)
                    return ActionResult.PlayAgain;

            }


            IncreaseResourcesForNextPlayer(GameState[opponent]);

            return HasWon(opponent) == Result.Won ? ActionResult.GameLost : ActionResult.NextPlayer;
        }

        private static void IncreaseResourcesForNextPlayer(World w)
        {
            w.Mana += w.Monastery;
            w.Ore += w.Mine;
            w.Stack += w.Barracks;
        }

        public enum Result
        {
            Won,
            Lost,
            NotOver
        }

        public enum ActionResult
        {
            GameWon,
            GameLost,
            NextPlayer,
            PlayAgain,
            DropAndPlayAgain
        }

        public enum Player
        {
            Ai,
            Opponent
        }

        [Serializable]
        public class World
        {
            public int Mine ;
            public int Monastery ;
            public int Barracks ;

            public int Ore ;
            public int Mana ;
            public int Stack ;

            public int Wall ;
            public int Tower ;

            public override string ToString()
            {
                return $"T{Tower} W{Wall} {Ore}-{Mana}-{Stack} {Mine}-{Monastery}-{Barracks}";
            }
        }
    }
}
