namespace _03._Number_Wars
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> firstDeck = new Queue<string>(Console.ReadLine()
                                 .Split());
            Queue<string> secondDeck = new Queue<string>(Console.ReadLine()
                                 .Split());

            int turnNumber = 0;

            string winStatus = string.Empty;
            bool gameOver = false;

            while (turnNumber < 1_000_000 && firstDeck.Count > 0 && secondDeck.Count > 0 && !gameOver)
            {
                string leftCard = firstDeck.Dequeue();
                string rightCard = secondDeck.Dequeue();
                int firstPower = GetNumberPower(leftCard);
                int secondPower = GetNumberPower(rightCard);

                if(firstPower > secondPower)
                {
                    firstDeck.Enqueue(leftCard);
                    firstDeck.Enqueue(rightCard);
                }
                else if(firstPower < secondPower)
                {
                    secondDeck.Enqueue(rightCard);
                    secondDeck.Enqueue(leftCard);
                }
                else
                {
                    List<string> cardsToAdd = new List<string>();
                                       
                    cardsToAdd.Add(leftCard);
                    cardsToAdd.Add(rightCard);
                    
                    while (!gameOver)
                    {
                        if(firstDeck.Count >= 3 && secondDeck.Count >= 3)
                        {
                            int firstPlayerPower = 0;
                            int secondPlayerPower = 0;

                            for (int turn = 0; turn < 3; turn++)
                            {
                                string newFirstDraw = firstDeck.Dequeue();
                                string newSecondDraw = secondDeck.Dequeue();
                                cardsToAdd.Add(newFirstDraw);
                                cardsToAdd.Add(newSecondDraw);

                                firstPlayerPower += GetCharPower(newFirstDraw);
                                secondPlayerPower += GetCharPower(newSecondDraw);
                            }
                            if(firstPlayerPower > secondPlayerPower)
                            {
                                AddCardsToWinner(cardsToAdd, firstDeck);
                                break;
                            }
                            else if(firstPlayerPower < secondPlayerPower)
                            {
                                AddCardsToWinner(cardsToAdd, secondDeck);
                                break;
                            }
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                }
                turnNumber++;
            }
            if (firstDeck.Count == secondDeck.Count)
            {
                winStatus = "Draw";
            }
            else if (firstDeck.Count >= 0 && secondDeck.Count >= 0)
            {
                int first = firstDeck.Count;
                int second = secondDeck.Count;
                winStatus = first > second ? "First player wins" : "Second player wins";
            }
            Console.WriteLine($"{winStatus} after {turnNumber} turns");
        }

        private static void AddCardsToWinner(List<string> cardsToAdd, Queue<string> deck)
        {
            foreach (var card in cardsToAdd.OrderByDescending(x => GetNumberPower(x)).ThenByDescending(x => GetCharPower(x)))
            {
                deck.Enqueue(card);
            }
        }

        private static int GetCharPower(string newDraw)
        {
            return newDraw[newDraw.Length - 1] - 96;
        }

        private static int GetNumberPower(string card)
        {
           return int.Parse(card.Substring(0, card.Length - 1));
        }
    }
}
