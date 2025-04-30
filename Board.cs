using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FifteenPuzzle
{
    public class Board(int height, int width)
    {
        public int Height { get; init; } = height;
        public int Width { get; init; } = width;

        public Tile[,] Tiles = new Tile [width , height]; 

        public void SetTiles()
        {
           for(int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Tiles[i, j] = new Tile((i * Height) + j);
                }
            }
        }

        public void SetWinningTiles()
        {
            {
                for (int i = 0; i < Height; i++)
                {
                    for (int j = 0; j < Width; j++)
                    {
                        if(i == Height - 1 && j == Width - 1)
                            Tiles[i, j] = new Tile(0);

                        else
                            Tiles[i, j] = new Tile((i * Height) + (j + 1));
                    }
                }
            }
        }

        public void ShuffleTiles()
        {
            int total = Height * Width;

            for(int i = total - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(0, i + 1);

                int iRow = i / Height;
                int iCol = i % Height;
                int jRow = j / Height;
                int jCol = j % Height;

                (this.Tiles[iRow, iCol], this.Tiles[jRow, jCol]) = (this.Tiles[jRow, jCol], this.Tiles[iRow, iCol]);
            }
        }

        public Tile GetZeroTile(int y, int x, Direction direction)
        {
            return direction switch
            {
                Direction.Up => this.Tiles[y - 1, x],
                Direction.Down => this.Tiles[y + 1, x],
                Direction.Left => this.Tiles[y, x - 1],
                Direction.Right => this.Tiles[y, x + 1],
                _ => this.Tiles[y, x],
            };
        }

        public static Board WinningBoard(int height, int width)
        {
            Board winningBoard = new Board(height, width);
            winningBoard.SetWinningTiles();
            return winningBoard;
        }
    }
}
