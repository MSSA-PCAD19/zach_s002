using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe
{
    // class access modifier public/internal
    internal class Game
    {
        // body of class Game
        // field, property, METHOD, event - collectively known as class member

        internal static char?[,] GetBoard() => new char?[3, 3];
        // static method has no dependency on any object state

        internal static void DisplayBoard(char?[,] board)
        {
            var hr = new string('-', 20);
            Console.WriteLine(hr);

            for (int row = 0; row < board.GetLength(0); row++)
            {
                Console.Write('|');
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    char? piece;
                    if (board[row, col] is not null)
                        piece = board[row, col];
                    else
                        piece = '_';

                    Console.Write($"  {piece}  |");

                }
                Console.WriteLine($"\n{hr}");
            }
        }

        internal static bool PlaceNextHand(char?[,] board, char nextHand)
        {
            bool piecePlaced = false;
            do
            {
                Console.WriteLine($"{nextHand} player, please place your next piece with row col e.g 0 1 for row 0 col 1");
                string input = Console.ReadLine();
                int row = int.Parse(input.Split(' ')[0]);
                int col = int.Parse(input.Split(' ')[1]);
                if (board[row, col] is null)
                {
                    board[row, col] = nextHand;
                    break;
                }
                else
                {
                    Console.WriteLine($"Position {row} {col} is already occupied by {board[row, col]}");
                    continue;
                    Console.WriteLine("You should not see this, because continue skips ahead to the next iteration");
                }
            } while (true);
            return BoardHasSpace(board) && DetermineOutcome(board) == "Continue";
        }

        internal static bool BoardHasSpace(char?[,] board)
        {
            //for (int row = 0; row < board.GetLength(0); row++)
            //{
            //    for (int col = 0; col < board.GetLength(1); col++)
            //    {
            //       if (board[row, col] == null)
            //        {
            //            return true;
            //        }


            //    }
            //}

            //alt

            foreach (char? item in board) // this will loop across ALL items in all dimensions
            {
                if (!item.HasValue)
                {
                    return true;
                }
            }
            return false;
        }

        internal static string DetermineOutcome(char?[,] board)
        {
            //check rows
            //check cols
            //check diag
            // - "O wins"
            // - "X wins"
            // - "Draw" when board is full and no win
            // - "Continue" when board is NOT full and no win
            string[] lines = new string[8];

            lines[0] = $"{board[0, 0]}{board[0, 1]}{board[0, 2]}"; //row 0
            lines[1] = $"{board[1, 0]}{board[1, 1]}{board[1, 2]}"; //row 1
            lines[2] = $"{board[2, 0]}{board[2, 1]}{board[2, 2]}"; //row 2

            //lines[3] = $"{board[0,0]}{board[1,0]}{board[2,0]}"; //col 0
            //lines[4] = $"{board[0,1]}{board[1,1]}{board[2,1]}"; //col 1
            //lines[5] = $"{board[0,2]}{board[1,2]}{board[2,2]}"; //col 2
            for (int i = 0; i < board.GetLength(1); i++)
            {
                lines[i + 3] = $"{board[0, i]}{board[1, i]}{board[2, i]}";
            }

            lines[6] = $"{board[0, 0]}{board[1, 1]}{board[2, 2]}"; //diag \
            lines[7] = $"{board[0, 2]}{board[1, 1]}{board[2, 0]}"; //diag /
            foreach (var item in lines)
            {
                if (item == "OOO")
                    return "O wins";

                if (item == "XXX")
                    return "X wins";
            }
            // no wins
            if (BoardHasSpace(board))
                return "Continue";
            else
                return "Draw";
        }
    }
}
