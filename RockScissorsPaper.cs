using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MyNamespace.RockScissorsPaperGame
{

    public class InvalidRockScissorsPaperItemException : Exception
    {
        public override string Message => "Invalid RockScissorsPaperEnum";
        public InvalidRockScissorsPaperItemException(string item)
        {
            Console.WriteLine("Not found \"" + item + "\" in RockScissorsPaperEnum");
        }
        public InvalidRockScissorsPaperItemException()
        {

        }
    }

    public enum RockScissorsPaperEnum
    {
        ROCK,
        SCISSORS,
        PAPER
    }
    struct RockScissorsPaper
    {
        public override string ToString()
        {
            return Item.ToString();
        }
        
        public static RockScissorsPaperEnum getEnum(string itemName)
        {
            itemName = itemName.ToUpper();
            foreach (var a in Enum.GetValues(typeof(RockScissorsPaperEnum)))
            {
                if (a.ToString().ToUpper() == itemName) return (RockScissorsPaperEnum)a;
            }
            throw new InvalidRockScissorsPaperItemException();
        }

        public RockScissorsPaper(string ItemName, string WinVsWho)
        {
            this.Item = getEnum(ItemName);
            this.WinVsWho = getEnum(WinVsWho);
        }

        public RockScissorsPaper(RockScissorsPaperEnum ItemName, RockScissorsPaperEnum WinVsWho)
        {
            this.Item = ItemName;
            this.WinVsWho = WinVsWho;
        }

        public readonly RockScissorsPaperEnum Item;
        public readonly RockScissorsPaperEnum WinVsWho;
    }
}
/*
 //In the main
static void Main(string[] args)
        {
            List<RockScissorsPaper> Items = new List<RockScissorsPaper>() {
            new RockScissorsPaper(RockScissorsPaperEnum.SCISSORS, RockScissorsPaperEnum.PAPER),
            new RockScissorsPaper(RockScissorsPaperEnum.PAPER, RockScissorsPaperEnum.ROCK),
            new RockScissorsPaper(RockScissorsPaperEnum.ROCK, RockScissorsPaperEnum.PAPER)
        };


            #region code
            var rand = new Random(DateTime.Now.Second);
            while (true)
            {
                Console.Write("Player  -> ");
                RockScissorsPaperEnum playerChoose;
                try
                {
                     playerChoose = RockScissorsPaper.getEnum(Console.ReadLine());
                }
                catch (InvalidRockScissorsPaperItemException)
                {
                    Console.WriteLine("Incorrect item. Choose rock scissors or paper!");
                    continue;
                }
                Console.Write("Computer-> ");
                var computerChoose = (RockScissorsPaperEnum)rand.Next(3);
 
                Console.WriteLine(computerChoose.ToString().ToLower());


                if (playerChoose != computerChoose)
                {
                    foreach (var a in Items)
                    {
                        if (a.Item == playerChoose && a.WinVsWho == computerChoose)
                        {
                            Console.WriteLine("Player wins!\n");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Computer wins!\n");
                                break;
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("Draw!");
                }
            }
            #endregion
        }
 */
