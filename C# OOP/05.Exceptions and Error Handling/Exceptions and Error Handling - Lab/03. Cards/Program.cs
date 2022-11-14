using System;
using System.Collections.Generic;

namespace _03._Cards
{
    public class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();

            for (int i = 0; i < input.Length; i++)
            {
                var cardInfo = input[i].Split(" ", StringSplitOptions.RemoveEmptyEntries);
                var face = cardInfo[0];
                var suit = cardInfo[1];

                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                finally
                {
                    if (i == input.Length - 1)
                    {
                        Console.WriteLine(String.Join(" ", cards));
                    }
                }
            }
        }
    }

    public class Card
    {
        Dictionary<string, string> cardSuits = new Dictionary<string, string>
        {
            {"S", "\u2660" },
            {"H", "\u2665" },
            {"D", "\u2666" },
            {"C", "\u2663" }
        };

        Dictionary<string, string> cardFaces = new Dictionary<string, string>
        {
            {"2", "2" },
            {"3", "3" },
            {"4", "4" },
            {"5", "5" },
            {"6", "6" },
            {"7", "7" },
            {"8", "8" },
            {"9", "9" },
            {"10", "10" },
            {"J", "J" },
            {"Q", "Q" },
            {"K", "K" },
            {"A", "A" }
        };

        private string face;
        private string suit;

        public Card(string face, string suit)
        {
            this.Face = face;
            this.Suit = suit;
        }

        public string Face 
        {
            get 
            {
                return this.face;
            }
            set 
            {
                if (!cardFaces.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.face = value;
            } 
        }
        public string Suit 
        {
            get
            {
                return this.suit;
            }
            set
            {
                if (!cardSuits.ContainsKey(value))
                {
                    throw new ArgumentException("Invalid card!");
                }

                this.suit = value;
            }
        }

        public override string ToString()
        {
            return $"[{cardFaces[Face]}{cardSuits[Suit]}]";
        }
    }
}
