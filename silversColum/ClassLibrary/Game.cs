using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class Game
    {
        Player player = new Player();
        Board gameBoard = new Board();
        int x1, y1, x2, y2 = 0;

        public Game() 
        { 
            
        
        }
        public void StartGame()
        {
            Console.WriteLine("Initial Board:");
            player.GetScore();
            gameBoard.DisplayBoard();
        }
        public void InitialSetUp()
        {
            Console.WriteLine("\nChecking for matches...");
            bool matchFound = gameBoard.CheckForMatches();

            DoMatches();
        }
        public void DoMatches()
        {
            bool matchFound = gameBoard.CheckForMatches();
            gameBoard.DisplayBoard();

            Console.WriteLine("\nChecking for matches again...");
            matchFound = gameBoard.CheckForMatches();
            Check();
            void Check()
            {
                
                if (matchFound)
                {
                    Console.WriteLine("Matches found! Removing them...");
                    player.IncreaseScore();
                    player.GetScore();
                    gameBoard.RemoveMatchedCandies();
                    Console.WriteLine("\nBoard after removing matches:");
                    gameBoard.DisplayBoard();
                    matchFound = gameBoard.CheckForMatches();
                    if (matchFound)
                    {
                        Check();
                    }
                    else {
                        SwapCandies();
                    }
                }
                else
                {
                    Console.WriteLine("No matches found.");
                    player.GetScore();
                    if (player.score == 0)
                    {
                        SwapCandies();
                    }
                    EndGame();
                }
            }
            
        }
        public void SwapCandies()
        {
            GetSwapCoordinates();
            Console.WriteLine($"\nSwapping candies at ({x1}, {y1}) and ({x2}, {y2})...");
            gameBoard.SwapCandies(x1, y2, x2, y2);
            DoMatches();
        }
        public void EndGame()
        {
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }


        // Method to get user input for swapping coordinates
        public void GetSwapCoordinates()
        {
            int x11, y11, x22, y22;

            while (true)
            {
                try
                {
                    // Prompt user for input
                    Console.WriteLine("\nEnter the coordinates of the first candy to swap (x1 y1): ");
                    string[] firstInput = Console.ReadLine()?.Split(' ');

                    Console.WriteLine("Enter the coordinates of the second candy to swap (x2 y2): ");
                    string[] secondInput = Console.ReadLine()?.Split(' ');

                    // Parse input values
                    x11 = int.Parse(firstInput[0]);
                    y11 = int.Parse(firstInput[1]);
                    x22 = int.Parse(secondInput[0]);
                    y22 = int.Parse(secondInput[1]);

                    // Validate the coordinates are within the board's bounds
                    if (IsValidCoordinate(x11, y11) && IsValidCoordinate(x22, y22))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates! Please enter values between 0 and 3 for both x and y.");
                    }
                }
                catch
                {
                    Console.WriteLine("Invalid input! Please enter numbers in the format: x y");
                }
            }

            x1 = x11;
            y1 = y11;
            x2 = x22;
            y2 = y22;
        }

        // Method to validate coordinates are within the board's bounds
        static bool IsValidCoordinate(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3;
        }

        public void RunGame()
        {
            StartGame();
            InitialSetUp();
        }



    }
}
