using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WarShuffle
{
    public class Shuffle
    {
        public static void FisherYates(Deck deck)
        {
            Random rand = new Random();

            // Write down the numbers from 1 through N (deck.Cards.Count).
            for (int i = deck.Cards.Count - 1; i > 0; i--)
            {
                // Pick a random number k between one and the number of unstruck numbers remaining (inclusive).
                int k = rand.Next(i + 1);

                // Counting from the low end, strike out the kth number not yet struck out, and write it down at the end of a separate list.
                Card temp = deck.Cards[i];
                deck.Cards[i] = deck.Cards[k];
                deck.Cards[k] = temp;

                //Repeat from step 2 until all the numbers have been struck out.
                //The sequence of numbers written down in step 3 is now a random permutation of the original numbers.
                // By iterating backwards and swapping each element with a random earlier (or the same) element, 
                // we ensure that each card has an equal probability of ending up in any position.
            }
        }
    }
}
