using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ClassLibrary
{
    public class Board
    {

        /* Declare an image array to be gameboard */
        public Candy[,] board;

        /* Declare variables and load in how many rows and columns */
        public int rows = 3;
        public int cols = 3;

        public Board() 
        {
            board = new Candy[rows, cols];
            InitializeBoard();
        } 


        public void InitializeBoard()
        {
            Random random = new Random();
            string[] candyTypes = { "@", "*", "\u25A0" };

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string candyType = candyTypes[random.Next(candyTypes.Length)];
                    board[row, col] = new Candy(candyType);

                }
            }
            
        }


        //public void TESTBoard()
        //{
        //    //Random random = new Random();
        //    string[] candyTypes = { "@", "*", "\u25A0" };

        //    board[0, 0] = new Candy("@");
        //    board[0, 1] = new Candy("\u25A0");
        //    board[0, 2] = new Candy("*");
        //    board[1, 0] = new Candy("*");
        //    board[1, 1] = new Candy("\u25A0");
        //    board[1, 2] = new Candy("\u25A0");
        //    board[2, 0] = new Candy("\u25A0");
        //    board[2, 1] = new Candy("\u25A0");
        //    board[2, 2] = new Candy("*");

        //}

        public void DisplayBoard()
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    switch (board[row, col].GetCandyType())
                    {
                        case "@":
                            Console.ForegroundColor = ConsoleColor.Magenta;
                            break;
                        case "*":
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            break;
                        case "\u25A0":
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }

                    Console.Write($"{board[row, col].GetCandyType()} ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public void SwapCandies(int x1, int y1, int x2, int y2)
        {
            Candy temp = board[x1, y1];
            board[x1, y1] = board[x2, y2];
            board[x2, y2] = temp;
        }
        public bool CheckForMatches()
        {
            bool matchFound = false;

            // Check for horizontal matches
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    if (board[row, col].GetCandyType() == board[row, col + 1].GetCandyType() && board[row, col].GetCandyType() == board[row, col + 2].GetCandyType())
                    {
                        Console.WriteLine($"Horizontal match found at ({row},{col})");
                        matchFound = true;
                    }
                }
            }
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows - 2; row++)
                {
                    if (board[row, col].GetCandyType() == board[row + 1, col].GetCandyType() && board[row, col].GetCandyType() == board[row + 2, col].GetCandyType())
                    {
                        Console.WriteLine($"Vertical match found at ({row},{col})");
                        matchFound = true;
                    }
                }
            }
            return matchFound;
        }
        public void RemoveMatchedCandies()
        {
            // Remove horizontal matches
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    if (board[row, col].GetCandyType() == board[row, col + 1].GetCandyType() && board[row, col].GetCandyType() == board[row, col + 2].GetCandyType())
                    {
                        board[row, col].SetCandyType("");
                        board[row, col + 1].SetCandyType("");
                        board[row, col + 2].SetCandyType("");
                    }
                }
            }

            // Remove vertical matches
            Random random = new Random();
            string[] candyTypes = { "@", "*", "\u25A0" };
            for (int col = 0; col < cols; col++)
            {
                for (int row = 0; row < rows - 2; row++)
                {
                    if (board[row, col].GetCandyType() == board[row + 1, col].GetCandyType() && board[row, col].GetCandyType() == board[row + 2, col].GetCandyType())
                    {
                        board[row, col].SetCandyType("");
                        string candyType = candyTypes[random.Next(candyTypes.Length)];
                        Candy candy2 = new Candy(candyType);
                        board[row + 1, col].SetCandyType(candy2.GetCandyType());
                        string candyType2 = candyTypes[random.Next(candyTypes.Length)];
                        Candy candy = new Candy(candyType2);
                        board[row + 2, col].SetCandyType(candy.GetCandyType());
                    }
                }
            }

            FillEmptySpaces();
        }
        public void FillEmptySpaces()
        {
            Random random = new Random();
            string[] candyTypes = { "@", "*", "\u25A0" };

            for (int col = 0; col < cols; col++)
            {
                for (int row = rows - 1; row >= 0; row--)
                {
                    if (board[row, col].GetCandyType() == "")
                    {
                        // Shift down candies
                        for (int shiftRow = row; shiftRow > 0; shiftRow--)
                        {
                            board[shiftRow, col] = board[shiftRow - 1, col];
                        }
                        // Fill the topmost empty space with a new candy
                        board[0, col] = new Candy(candyTypes[random.Next(candyTypes.Length)]);
                    }
                }
            }
        }

    }
}
