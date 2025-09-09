using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeckLibrary
{
    
    public class Deck
    {
        public static string[] DrawCards(ref string[] deck, int v)
        {
            //if (newDeck.Length < v) throw new ArgumentException($"there are only {newDeck.Length} cards left.");
            string[] result = deck[0..v];
            string[] newDeck = new string[deck.Length - v];
            Array.Copy(deck, v, newDeck, 0, v);
            deck = newDeck;
            return result;
            //return (newDeck[0..v]);
        }
        public static string[] ChooseRandom5(string[] cards)
        {
            Random rng = new Random();
            string[] random5 = new string[5];
            string[] noDuplicates = new string[5];
            for (int i = 0; i < 5;)
            {
                int randomNumber = rng.Next(0, 52);
                if (!noDuplicates.Contains(cards[randomNumber]))
                {
                    random5[i] = cards[randomNumber];
                    noDuplicates[i] = cards[randomNumber];
                    i++;
                }
                else
                {
                    continue;
                }
            }
            return random5;
        }

        public static string[] GetDeck()
        {
            return ["\U0001F0A1", "\U0001F0A2", "\U0001F0A3", "\U0001F0A4", "\U0001F0A5", "\U0001F0A6", "\U0001F0A7", "\U0001F0A8", "\U0001F0A9", "\U0001F0AA", "\U0001F0AB",
                    "\U0001F0AD","\U0001F0AE","\U0001F0B1", "\U0001F0B2", "\U0001F0B3", "\U0001F0B4", "\U0001F0B5", "\U0001F0B6", "\U0001F0B7", "\U0001F0B8", "\U0001F0B9", "\U0001F0BA", "\U0001F0BB",
                    "\U0001F0BD","\U0001F0BE","\U0001F0C1", "\U0001F0C2", "\U0001F0C3", "\U0001F0C4", "\U0001F0C5", "\U0001F0C6", "\U0001F0C7", "\U0001F0C8", "\U0001F0C9", "\U0001F0CA", "\U0001F0CB",
                    "\U0001F0CD","\U0001F0CE","\U0001F0D1", "\U0001F0D2", "\U0001F0D3", "\U0001F0D4", "\U0001F0D5", "\U0001F0D6", "\U0001F0D7", "\U0001F0D8", "\U0001F0D9", "\U0001F0DA", "\U0001F0DB",
                    "\U0001F0DD","\U0001F0DE"];
        }

        public static void Shuffle(string[] deckToShuffle)
        {
            // x number of pass, swap each card with another random card
            int numberOfPass = 3;
            Random rng = new();

            for (int i = 0; i < numberOfPass; i++)
            {
                for (int source = 0; source < deckToShuffle.Length; source++)
                {
                    int destination = rng.Next(52); //index to swap the current card with
                    //(deckToShuffle[source], deckToShuffle[destination]) = (deckToShuffle[destination], deckToShuffle[source]);
                    // tuple swap ^^^^
                    string temp = deckToShuffle[source];
                    deckToShuffle[source] = deckToShuffle[destination];
                    deckToShuffle[destination] = temp;
                }
            }
        }

        public static string[] ShuffleDeck(string[] cards)
        {
            Random rng = new Random();
            int n = cards.Length;
            for (int i = n - 1; i > 0; i--)
            {
                int j = rng.Next(i + 1);
                // Swap cards[i] and cards[j]
                string temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
            return cards;
        }


    }
}
