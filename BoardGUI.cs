using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public static class BoardGUI
    {
        public static void DisplayBoard(Board board)
        {

            for (int i = 0; i < board.Tiles.GetLength(1); i++)
            {
                for (int j = 0; j < board.Tiles.GetLength(1); j++)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write($"| {board.Tiles[i, j].Value,2} |\t");
                }
                Console.ResetColor();
                Console.WriteLine("\n");
            }
        }
    }
}
