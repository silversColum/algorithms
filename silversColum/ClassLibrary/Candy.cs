using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Candy
    {
        string candyName;
        Color color;
        
        public Candy(string name) 
        {
            candyName = name;
        }
        public string GetCandyType()
        {
            return candyName;
        }
        public void SetCandyType(string name)
        {
            candyName = name;
        }
        public Color GetCandyColor()
        {
            if (candyName == "@")
            {
                return Color.Violet;
            }
            if (candyName == "*")
            {
                return Color.Aqua;
            }
            if (candyName == "\u25A0")
            {
               return Color.Yellow;
            }
            else 
            {
                return Color.White;
            }
        }
    }
}
