using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public static class Game
    {
        public static void Run()
        {
            Console.WriteLine("Welcome to puzzle time. Can we get your name?");

            Player player = new(Console.ReadLine() ?? "Player");

            var (height, width) = BoardUtils.AskBoardSize(player);

            Board board = new(height, width);
            board.SetTiles();
            do
            {
                board.ShuffleTiles();
            } while (BoardUtils.IsSolvable(board.Tiles));

            int choice;
            do
            {
                Console.Clear();
                BoardGUI.DisplayBoard(board);
                var availableMoves = Move.ShowValidMoves(board.Tiles);


                for (int i = 0; i < availableMoves.Count; i++)
                {
                    Console.WriteLine($"{i}: {availableMoves[i].Value} {availableMoves[i].Direction}");
                }

                do
                {
                    Console.WriteLine("What would you like to do next?");
                    choice = Move.ValidMoveChoice(availableMoves.Count, Console.ReadLine() ?? "null");
                    if (choice != -1)
                    {
                        Console.WriteLine($"Moved {availableMoves[choice].Value} {availableMoves[choice].Direction}");
                    }
                    else
                    {
                        Console.WriteLine($"Not a valid choice!");
                    }
                } while (choice == -1);

                int col = availableMoves[choice].Col;
                int row = availableMoves[choice].Row;

                Move.MoveTile(board.Tiles[col, row], board.GetZeroTile(col, row, availableMoves[choice].Direction));
            } while (!Game.CheckIfWon(board));

            Console.WriteLine("You won!");
        }

        public static bool CheckIfWon(Board board)
        {
            Board winningBoard = Board.WinningBoard(board.Height, board.Width);
            for(int i = 0; i < board.Height; i++)
            {
                for(int j = 0; j < board.Width; j++)
                {
                    if (board.Tiles[i, j].Value != winningBoard.Tiles[i, j].Value)
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }

    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }
}
