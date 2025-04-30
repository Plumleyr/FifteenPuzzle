using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FifteenPuzzle.Game;

namespace FifteenPuzzle
{
    internal static class Move
    {
        public static int ValidMoveChoice(int moveLength, string choice)
        {
            if(int.TryParse(choice, out _))
            {
                int convertedChoice = Convert.ToInt32(choice);
                if (convertedChoice > -1 && convertedChoice < moveLength)
                {
                    return convertedChoice;
                }
            }
            return -1;
        }
        static public void MoveTile(Tile tile1, Tile tile2)
        {
           (tile1.Value, tile2.Value) = (tile2.Value, tile1.Value);
        }

        // returns a list of tuples that contains the positional ints of the tile value in the 2d array(item1 and item2), the tile value (item3), and the direction of movement that the tile can perform
        public static List<ValidMove> ShowValidMoves(Tile[,] tilesArray)
        {
            int tileArraySize = tilesArray.GetLength(0);
            int ifMaxSize = tileArraySize - 1;

            List<ValidMove> list = [];
            for (int i = 0; i < tileArraySize; i++)
            {
                for (int j = 0; j < tileArraySize; j++)
                {
                    // if the 0 / blank value is above, below, right or left of the tile and adds the information to the list.
                    if (i != 0 && tilesArray[i - 1, j].Value == 0)
                        list.Add(new ValidMove(i, j, tilesArray[i, j].Value, Direction.Up)); //adds value if 0 above it

                    else if (i != ifMaxSize && tilesArray[i + 1, j].Value == 0)
                        list.Add(new ValidMove(i, j, tilesArray[i, j].Value, Direction.Down)); //adds value if 0 below it

                    else if (j != 0 && tilesArray[i, j - 1].Value == 0)
                        list.Add(new ValidMove(i, j, tilesArray[i, j].Value, Direction.Left)); //adds value if 0 to the left

                    else if (j != ifMaxSize && tilesArray[i, j + 1].Value == 0)
                        list.Add(new ValidMove(i, j, tilesArray[i, j].Value, Direction.Right)); //adds value if 0 to the right
                }
            }

            return list;
        }
    }
}
