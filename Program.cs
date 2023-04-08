using System;

namespace AsyncPoker
{
    class Poker
    {
        public string? cards { get; set; } = "";

        static IEnumerable<string> Suits()
        {
            yield return "clubs";
            yield return "diamons";
            yield return "hearts";
            yield return "spades";
        }
        static IEnumerable<string> Ranks()
        {
            yield return "two";
            yield return "three";
            yield return "four";
            yield return "five";
            yield return "six";
            yield return "seven";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "eight";
            yield return "nine";
            yield return "ten";
            yield return "jack";
            yield return "queen";
            yield return "king";
            yield return "ace";
        }

        public static List<Poker> cardList { get; set; } = new List<Poker>();
        public static List<Poker> userCardList { get; set; } = new List<Poker>();
        public static List<Poker> sysCardList { get; set; } = new List<Poker>();
        public static Random random { get; set; } = new Random();
        static Dictionary<string, int> numbermap = new Dictionary<string, int>()
        {
            {"two",2},
            {"three",3},
            {"four",4},
            {"five",5},
            {"six",6},
            {"seven",7},
            {"eight",8},
            {"nine",9},
            {"ten",10},
            {"jack",11},
            {"queen",12},
            {"king",13},
            {"ace",14},
        };

        static Dictionary<string, int> Suitsmap = new Dictionary<string, int>()
        {
            {"clubs",1},
            {"diamons",2},
            {"hearts",3},
            {"spades",4},
        };

        private static void Main(string[] args)
        {
            var allcards = from s in Suits()
                           from r in Ranks()
                           select new { Suit = s, Rank = r };

            foreach (var card in allcards)
            {
                cardList.Add(new Poker
                {
                    cards = card.ToString()
                });

            }
            cardList.ForEach(p => Console.WriteLine(p.cards));

            startingGame();
        }

        static void startingGame()
        {
            for (var i = 1; i < 6; i++)
            {
                int randomNumber = random.Next(0, cardList.Count - 1);
                userCardList.Add(new Poker
                {
                    cards = cardList.ElementAt(randomNumber).cards
                });
                cardList.RemoveAt(randomNumber);
            }

            for (var i = 1; i < 6; i++)
            {
                int randomNumber = random.Next(0, cardList.Count - 1);
                sysCardList.Add(new Poker
                {
                    cards = cardList.ElementAt(randomNumber).cards
                });
                cardList.RemoveAt(randomNumber);
            }

            Console.WriteLine("_________");

            for (var i = 1; i < 6; i++)
            {
                userCardList.ForEach(p => Console.WriteLine($"Your Cards:" + p.cards));
                Console.WriteLine("_________");
                Console.WriteLine("Choose the game 1:go bigger 2:go smaller !! enter the number please");
                string gameType = Console.ReadLine();
                Console.WriteLine("_________");
                Console.WriteLine($"You go first, pick one card 1-{userCardList.Count}");
                string? userInput = Console.ReadLine();
                Console.WriteLine($"Card:" + userCardList.ElementAt(int.Parse(userInput) - 1).cards);

                compareCards(gameType, int.Parse(userInput) - 1);

            }

            Console.WriteLine("Total cards:" + cardList);

            if (cardList.Count > 11)
            {
                Console.WriteLine("another run or not 1:play 2:exit");
                string continuePlay = Console.ReadLine();
                playAgain(continuePlay);
            }
        }

        private static void compareCards(string gameType, int userInput)
        {
            int randomNumber = random.Next(0, sysCardList.Count - 1);
            string[] separators = { "Suit =", ", Rank =", "}" };
            string[] userCard = userCardList[userInput].cards.Split(separators, StringSplitOptions.RemoveEmptyEntries);
            string[] systemCard = sysCardList[randomNumber].cards.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            switch (gameType)
            {
                case "1":
                    if (numbermap[userCard[2].ToString().Trim()] > numbermap[systemCard[2].ToString().Trim()])
                    {
                        Console.WriteLine("____________");

                        Console.WriteLine("You Card:" + userCardList[userInput].cards);
                        Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                        Console.WriteLine("Winer Winer Chicken dinner!!");
                        Console.WriteLine("____________");
                    }
                    else if (numbermap[userCard[2].ToString().Trim()] < numbermap[systemCard[2].ToString().Trim()])
                    {
                        Console.WriteLine("____________");

                        Console.WriteLine("You Card:" + userCardList[userInput].cards);
                        Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                        Console.WriteLine("haha!!! Bad Luck try again");
                        Console.WriteLine("____________");
                    }
                    else
                    {
                        if (Suitsmap[userCard[1].ToString().Trim()] > Suitsmap[systemCard[1].ToString().Trim()])
                        {
                            Console.WriteLine("____________");

                            Console.WriteLine("You Card:" + userCardList[userInput].cards);
                            Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                            Console.WriteLine("Winer Winer Chicken dinner!!");
                            Console.WriteLine("____________");
                        }
                        else
                        {
                            Console.WriteLine("____________");

                            Console.WriteLine("You Card:" + userCardList[userInput].cards);
                            Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                            Console.WriteLine("haha!!! Bad Luck try again");
                            Console.WriteLine("____________");
                        }
                    }
                    break;

                case "2":
                    if (numbermap[userCard[2].ToString().Trim()] < numbermap[systemCard[2].ToString().Trim()])
                    {
                        Console.WriteLine("____________");

                        Console.WriteLine("You Card:" + userCardList[userInput].cards);
                        Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                        Console.WriteLine("Winer Winer Chicken dinner!!");
                        Console.WriteLine("____________");
                    }
                    else if (numbermap[userCard[2].ToString().Trim()] > numbermap[systemCard[2].ToString().Trim()])
                    {
                        Console.WriteLine("____________");

                        Console.WriteLine("You Card:" + userCardList[userInput].cards);
                        Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                        Console.WriteLine("haha!!! Bad Luck try again");
                        Console.WriteLine("____________");
                    }
                    else
                    {
                        if (Suitsmap[userCard[1].ToString().Trim()] < Suitsmap[systemCard[1].ToString().Trim()])
                        {
                            Console.WriteLine("____________");

                            Console.WriteLine("You Card:" + userCardList[userInput].cards);
                            Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                            Console.WriteLine("Winer Winer Chicken dinner!!");
                            Console.WriteLine("____________");
                        }
                        else
                        {
                            Console.WriteLine("____________");

                            Console.WriteLine("You Card:" + userCardList[userInput].cards);
                            Console.WriteLine("System Card:" + sysCardList[randomNumber].cards);
                            Console.WriteLine("haha!!! Bad Luck try again");
                            Console.WriteLine("____________");
                        }
                    }
                    break;
            }
            userCardList.RemoveAt(userInput);
            sysCardList.RemoveAt(randomNumber);
        }

        static void playAgain(string continuePlay)
        {
            switch (continuePlay)
            {
                case "1":
                    startingGame();
                    break;

                case "2":
                    break;
            }
        }
    }
}
