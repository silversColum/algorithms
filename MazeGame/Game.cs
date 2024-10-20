using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace MazeGame
{
     public class Game
    {
        private World myWorld;
        private Player player;

        public void Start()
        {
            // WriteLine("Game is Starting");

            //SetCursorPosition(4, 2);
            //Write("X");

            string[,] grid =
            {
                { "\u250C", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2510" }, 
                { "\u2502", " ", " ", " ", "\u2502", " ", " ", " ", " ", "\u2502" }, 
                { "\u2502", " ", "\u2502", " ", "\u2502", " ", "\u2502", "\u2502", " ", "\u2502" },
                { "\u2502", " ", "\u2502", " ", " ", " ", " ", "\u2502", " ", "\u2502" },
                { "\u2502", " ", "\u2502", "\u2500", "\u2500", "\u2500", " ", "\u2502", " ", "\u2502" },
                { "\u2502", " ", " ", " ", " ", "\u2502", " ", " ", " ", "\u2502" },
                { "\u2502", "\u2500 ", "\u2500 ", "\u2500", " ", "\u2502", "\u2500", "\u2500", "X", "\u2502" },
                { "\u2502", " ", " ", "\u2502", " ", " ", " ", "\u2502", " ", "\u2502" },
                { "\u2502", "\u2500", " ", "\u2502", "\u2500", "\u2500", " ", "\u2502", " ", "\u2502" },
                { "\u2514", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2500", "\u2518" } 
            };

            myWorld = new World(grid);
            //myWorld.Draw();

            player = new Player(1, 1);
            //player.Draw();

            //WriteLine("press any key to exit...");
            // ReadKey();
            GameLoop();
        }

        private void DrawFrame()
        {
            Clear();
            myWorld.Draw();
            player.Draw();
        }
        private void PlayerInput()
        {
            //read input 
            //move x and y 
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            ConsoleKey key = keyInfo.Key;
            switch (key)
            {
                case ConsoleKey.UpArrow:
                    if (myWorld.IsWalkable(player.X, player.Y-1))
                    {
                        player.Y -=1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (myWorld.IsWalkable(player.X, player.Y+1))
                    {
                        player.Y +=1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (myWorld.IsWalkable(player.X-1, player.Y))
                    {
                        player.X -=1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (myWorld.IsWalkable(player.X+1, player.Y))
                    {
                        player.X +=1;
                    }
                    break;
            }
        }
        private void intro()
        {
            WriteLine("welcome to maze!");
            WriteLine("\nInstructions");
            WriteLine("> use arrow keys to move");
            Write("> reach the goal, it looks like this: ");
            ForegroundColor = ConsoleColor.Green;
            WriteLine("X");
            ForegroundColor = ConsoleColor.White;
            WriteLine("> press any key 2 start");
            ReadKey();
        }
        private void outro()
        {
            Clear();
            WriteLine("you did it!");
            WriteLine("thanks 4 playning");
            WriteLine("press any key to exit");
            ReadKey();
        }
        private void GameLoop()
        {
            intro();
            while (true)
            {
                //draw evrything 
                DrawFrame();

                //check for player inpu from keyboard 
                PlayerInput();
                //has player reached exit? end game 
                string thing = myWorld.getThing(player.X, player.Y);
                if (thing == "X" || (player.X == 6 && player.Y == 8))
                {
                    break;
                }
                //give console chance to rennnder  
                //https://www.youtube.com/watch?v=T0MpWTbwseg&list=PL-LDQE9x9hLwldZPPGwqXixr-_DfINfxk&index=2 
                System.Threading.Thread.Sleep(30);
                //break;
            }
            outro();
        }
    }
}
