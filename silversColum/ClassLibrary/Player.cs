using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Player
    {
        public int score;
        public void IncreaseScore()
        {
            score ++;
        }
        public void GetScore()
        {
            Console.WriteLine($"Score: {score}");
        }
    }
}
