using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public static class BoardUtils
    {
        public static (int width, int height) AskBoardSize(Player player)
        {
            while (true)
            {
                Console.WriteLine($"What size board would you like, {player.Name}?");
                Console.WriteLine("0: 3x3\n1: 4x4\n2: 5x5");
                Console.Write("Enter your choice (0-2): ");

                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "0":
                        return (3, 3);
                    case "1":
                        return (4, 4);
                    case "2":
                        return (5, 5);
                    default:
                        Console.WriteLine("Invalid choice. Please enter 1, 2, or 3.");
                        break;
                }
            }
        }

        public static bool IsSolvable(Tile[,] tiles)
        {
            int size = tiles.GetLength(0);
            List<int> flattened = [];

            int blankRowFromBottom = 0;

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    int val = tiles[i, j].Value;
                    if (val == 0)
                        blankRowFromBottom = size - i; // row from bottom (1-based)
                    else
                        flattened.Add(val);
                }
            }

            int inversions = 0;
            for (int i = 0; i < flattened.Count; i++)
            {
                for (int j = i + 1; j < flattened.Count; j++)
                {
                    if (flattened[i] > flattened[j])
                        inversions++;
                }
            }

            if (size % 2 == 1)
            {
                // odd grid: solvable if inversions even
                return inversions % 2 == 0;
            }
            else
            {
                // even grid: blank row from bottom + inversions must be odd
                return (blankRowFromBottom % 2 == 0) == (inversions % 2 == 1);
            }
        }
    }
}
