using System;

namespace acromag1
{
    public class GameCards
    {
        private static readonly Card BigVeinCard = new Card { Id = 4, CostOre = 4 };
        private static readonly Card StealTechnologyCard = new Card {Id = 7, CostOre = 4 };
        private static readonly Card FoundationCard = new Card { Id = 11, CostOre = 3 };
        private static readonly Card SubsoilWatersCard = new Card { Id = 30, CostOre = 6 };
        private static readonly Card BarracksCard = new Card { Id = 31, CostOre = 10, Stack = 6, Wall = 6 };
        private static readonly Card ShiftCard = new Card { Id = 33, CostOre = 17 };
        private static readonly Card ParityCard = new Card { Id = 46, CostMana = 7 };
        private static readonly Card JewelleryCard = new Card { Id = 62 };
        private static readonly Card LightningCard = new Card { Id = 65, CostMana = 11 };
        private static readonly Card BeetleCard = new Card { Id = 84, CostStacks = 8 };
        private static readonly Card CausticCloudCard = new Card { Id = 86, CostStacks = 11 };
        private static readonly Card UnicornCard = new Card { Id = 87, CostStacks = 9 };
        private static readonly Card ElvenArchersCard = new Card { Id = 88, CostStacks = 10 };
        private static readonly Card ThiefCard = new Card { Id = 91, CostStacks = 12, OpMana = -10, OpOre = -5 };
        private static readonly Card SpearmanCard = new Card { Id = 95, CostStacks = 2 };

        public static Card[] Cards =
        {
            new Card {Id = 0, Ore = -8, OpOre = -8},
            new Card {Id = 1, Ore = 2, Mana = 2, PlayAgain = true},
            new Card {Id = 2, Wall = 1, CostOre = 1, PlayAgain = true},
            new Card {Id = 3, Mine = 1, CostOre = 3},
            BigVeinCard,
            new Card {Id = 5, CostOre = 7, Mine = 1, Wall = 4},
            new Card {Id = 6, CostOre = 2, Wall = 5, Mana = -6},
            StealTechnologyCard,
            new Card {Id = 8, CostOre = 2, Wall = 3},
            new Card {Id = 9, CostOre = 3, Wall = 4},
            new Card {Id = 10, CostOre = 2, Mine = 1, OpMine = 1, Mana = 4},
            FoundationCard,
            new Card {Id = 12, CostOre = 7, Wall = -5, OpWall = -5},
            new Card {Id = 13, CostOre = 8, Monastery = 1, PlayAgain = true},
            new Card {Id = 14, Mine = -1, OpMine = -1},
            new Card {Id=15, CostOre = 5, Wall = 6},
            new Card {Id=16, CostOre = 4, OpMine = -1},
            new Card {Id=17, CostOre = 6, Mine = 2},
            new Card {Id=18, Mine = -1, Wall = 10, Mana = 5},
            new Card {Id=19, CostOre = 8, Wall = 8},
            new Card {Id=20, CostOre = 9, Wall = 5, Barracks = 1},
            new Card {Id=21,CostOre = 9, Mana = 7, Wall = 7},
            new Card {Id=22,CostOre = 11, Wall = 6, Tower = 3},
            new Card {Id=23,CostOre = 12, Wall = 13},
            new Card {Id=24,CostOre = 15, Wall = 8, Tower = 5},
            new Card {Id=25,CostOre = 16, Wall = 15},
            new Card {Id=26,CostOre = 18, Damage = 10, Wall = 6},
            new Card {Id=27,CostOre = 24, Wall = 20, Tower = 8},
            new Card {Id=28,CostOre = 7, Stack = -5, Wall = 9},
            new Card {Id=29,CostOre = 1, Wall = 1, Tower = 1, Stack = 2},
            SubsoilWatersCard,
            BarracksCard,
            new Card {Id=32,CostOre = 14, Wall = 7, Damage = 6},
            ShiftCard,
            new Card {Id=34,CostMana = 1, Tower = 1, PlayAgain = true},
            new Card {Id=35,CostMana = 2, OpTower = -1, PlayAgain = true},
            new Card {Id=36,CostMana = 2, Tower = 3},
            new Card {Id=37,CostMana = 3, Monastery = 1},
            new Card {Id=38,CostMana = 5, Tower = 8},
            new Card {Id=39,CostMana = 4, Tower = 2, OpTower = -2},
            new Card {Id=40,CostMana = 6, Monastery = 1, Tower = 3, OpTower = 1},
            new Card {Id=41,CostMana = 2, OpTower = -3},
            new Card {Id=42,CostMana = 3, Tower = 5},
            new Card {Id=43,CostMana = 4, OpTower = -5},
            new Card {Id=44,CostMana = 3, Tower = -5, Monastery = 2},
            new Card {Id=45,CostMana = 7, Monastery = 1, Tower = 3, Wall = 3},
            ParityCard,
            new Card {Id=47,CostMana = 6, Tower = 8},
            new Card {Id=48,CostMana = 9, Tower = 5, Monastery = 1},
            new Card {Id=49,CostMana = 8, Monastery = -1, OpTower = -9},
            new Card {Id=50,CostMana = 7, Tower = 5, OpOre = -6},
            new Card {Id=51,CostMana = 10, Tower = 11},
            new Card {Id=52,CostMana = 5, Tower = -7, OpTower = -7, Monastery = -1, OpMonastery = -1},
            new Card {Id=53,CostMana = 13, Tower = 6, OpTower = -4},
            new Card {Id=54,CostMana = 4, Tower = 7, Ore = -10},
            new Card {Id=55,CostMana = 12, Tower = 8, Wall = 3},
            new Card {Id=56,CostMana = 14, Tower = 8, Barracks = 1},
            new Card {Id=57,CostMana = 16, Tower = 15},
            new Card {Id=58,CostMana = 15, Tower = 10, Wall = 5, Stack = 5},
            new Card {Id=59,CostMana = 17, Tower = 12, Damage = 6},
            new Card {Id=60,CostMana = 21, Tower = 20},
            new Card {Id=61,CostMana = 8, Tower = 11, Wall = -6},
            JewelleryCard,
            new Card {Id=63,Tower = 1, OpTower = 1, Mana = 3},
            new Card {Id=64,CostMana = 5, Tower = 4, Stack = -3, OpTower = -2},
            LightningCard,
            new Card {Id=66,CostMana = 18, Tower = 13, Stack = 6, Ore = 6},
            new Card {Id=67,Stack = -6, OpStack = -6},
            new Card {Id=68,CostStacks = 1, Damage = 2, PlayAgain = true},
            new Card {Id=69,CostStacks = 1, Damage = 4, Mana = -3},
            new Card {Id=70,CostStacks = 3, Barracks = 1},
            new Card {Id=71,CostStacks = 3, Damage = 6, SelfDamage = 3},
            new Card {Id=72,CostStacks = 4, OpTower = -3, SelfDamage = 1},
            new Card {Id=73,CostStacks = 6, OpTower = -2, PlayAgain = true},
            new Card {Id=74,CostStacks = 3, Damage = 5},
            new Card {Id=75,CostStacks = 5, Damage = 4, Wall = 3},
            new Card {Id=76,CostStacks = 6, OpTower = -4},
            new Card {Id=77,CostStacks = 7, Barracks = 2},
            new Card {Id=78,CostStacks = 8, Damage = 2, Wall = 4, Tower = 2},
            new Card {Id=79,Barracks = 1, OpBarracks = 1, Stack = 3},
            new Card {Id=80,CostStacks = 5, Damage = 6},
            new Card {Id=81,CostStacks = 6, Damage = 7},
            new Card {Id=82,CostStacks = 6, Damage = 6, OpStack = -3},
            new Card
            {Id=83,
                CostStacks = 5,
                Damage = 6,
                Ore = -5,
                OpOre = -5,
                Mana = -5,
                OpMana = -5,
                Stack = -5,
                OpStack = -5
            },
            BeetleCard,
            new Card {Id=85,CostStacks = 9, Damage = 9},
            CausticCloudCard,
            UnicornCard,
            ElvenArchersCard,
            new Card {Id=89,CostStacks = 14, OpTower = -5, OpStack = -8},
            new Card {Id=90,CostStacks = 11, Damage = 8, OpMine = -1},
            ThiefCard,
            new Card {Id=92,CostStacks = 15, Damage = 10, Wall = 4},
            new Card {Id=93,CostStacks = 17, Damage = 10, OpStack = -5, OpBarracks = -1},
            new Card {Id=94,CostStacks = 25, Damage = 20, OpMana = -10, OpBarracks = -1},
            SpearmanCard,
            new Card {Id=96,CostStacks = 2, Damage = 3, Mana = 1},
            new Card {Id=97,CostStacks = 4, Damage = 8, Tower = -3},
            new Card {Id=98,CostStacks = 13, Damage = 13, Mana = -3},
            new Card {Id=99,CostStacks = 18, OpTower = -12},
            new Card {Id=100,CostMana = 2, PlayAgain = true, DiscardOneAfter = true},
            new Card {Id=101,CostMana = 2, PlayAgain = true, DiscardOneAfter = true}
        };


        static GameCards()
        {
            BigVeinCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                BigVeinCard.Mine = currentPlayersWorld.Mine < opWorld.Mine ? 2 : 1;
            };

            StealTechnologyCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                if (currentPlayersWorld.Mine < opWorld.Mine)
                    StealTechnologyCard.Mine = opWorld.Mine - currentPlayersWorld.Mine;
                else
                {
                    StealTechnologyCard.Mine = 0;
                }
            };

            FoundationCard.SpecialCase = (currentPlayersWorld, opWorld) => { FoundationCard.Wall = currentPlayersWorld.Wall == 0 ? 6 : 3; };

            SubsoilWatersCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                if (currentPlayersWorld.Wall < opWorld.Wall)
                {
                    SubsoilWatersCard.Barracks = -1;
                    SubsoilWatersCard.Tower = -2;
                }
                else if (currentPlayersWorld.Wall > opWorld.Wall)
                {
                    SubsoilWatersCard.OpBarracks = -1;
                    SubsoilWatersCard.OpTower = -2;
                }
                else
                {
                    SubsoilWatersCard.OpBarracks = 0;
                    SubsoilWatersCard.OpTower = 0;
                }
            };

            BarracksCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                BarracksCard.Barracks = currentPlayersWorld.Barracks < opWorld.Barracks ? 1 : 0;
            };

            ShiftCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                ShiftCard.Wall = opWorld.Wall - currentPlayersWorld.Wall;
                ShiftCard.OpWall = currentPlayersWorld.Wall - opWorld.Wall;
            };

            ParityCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                var maxMonastery = Math.Max(currentPlayersWorld.Monastery, opWorld.Monastery);
                ParityCard.Monastery = maxMonastery - currentPlayersWorld.Monastery;
                ParityCard.OpMonastery = maxMonastery - opWorld.Monastery;
            };

            JewelleryCard.SpecialCase = (currentPlayersWorld, opWorld) => { JewelleryCard.Tower = currentPlayersWorld.Tower < opWorld.Tower ? 2 : 1; };

            LightningCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                if (currentPlayersWorld.Tower > opWorld.Wall)
                {
                    LightningCard.OpTower = -8;
                    LightningCard.SelfDamage = 0;
                }
                else
                {
                    LightningCard.Damage = 8;
                    LightningCard.SelfDamage = 8;
                }
            };

            BeetleCard.SpecialCase = (currentPlayersWorld, opWorld) => { BeetleCard.Damage = opWorld.Wall == 0 ? 10 : 6; };

            CausticCloudCard.SpecialCase = (currentPlayersWorld, opWorld) => { CausticCloudCard.Damage = opWorld.Wall > 10 ? 10 : 7; };

            UnicornCard.SpecialCase = (currentPlayersWorld, opWorld) => { UnicornCard.Damage = currentPlayersWorld.Monastery > opWorld.Monastery ? 12 : 8; };

            ElvenArchersCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                if (currentPlayersWorld.Wall > opWorld.Wall)
                {
                    ElvenArchersCard.OpTower = -6;
                    ElvenArchersCard.Damage = 0;
                }
                else
                {
                    ElvenArchersCard.Damage = 6;
                    ElvenArchersCard.OpTower = 0;
                }
            };

            ThiefCard.SpecialCase = (currentPlayersWorld, opWorld) =>
            {
                ThiefCard.Mana = Math.Min(10, opWorld.Mana) / 2;
                ThiefCard.Ore = Math.Min(5, opWorld.Ore) / 2;
            };

            SpearmanCard.SpecialCase = (currentPlayersWorld, opWorld) => { SpearmanCard.Damage = currentPlayersWorld.Wall > opWorld.Wall ? 3 : 2; };
        }
    }
}