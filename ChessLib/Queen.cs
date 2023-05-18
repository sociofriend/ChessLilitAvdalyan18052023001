using System;
namespace ChessLib
{
    public class Queen
    {
        public Queen()
        {

        }

        /// <summary>
        /// Prints the figure of Queen on the board with the given coordinates, and available legal steps.
        /// </summary>
        /// <param name="figure">String type variable.</param>
        /// <param name="coordinates">Array of integers with i,j coordinates of the figure on the board.</param>
        public static void BoardPrinterWithLegalSteps(string figure, int[,] coordinates)
        {
            //variables
            int figureCoordinatesSum = 0;
            int figureCoordinatesDiff = 0;
            int row = 0;
            int coloumn = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 1)
                    {
                        figureCoordinatesSum = i + j;
                        figureCoordinatesDiff = i - j;
                        row = i;
                        coloumn = j;
                        break;
                    }
                }
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("  A B C D E F G H  ");
            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1));
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 1)
                        ChessLib.Chess.BackgroundSetter((figure + " "), i, j);
                    else if ((coordinates[i, j] != 1) && (i + j == figureCoordinatesSum))
                        ChessLib.Chess.BackgroundSetter("**", i, j);
                    else if ((coordinates[i, j] != 1) && (i - j == figureCoordinatesDiff))
                        ChessLib.Chess.BackgroundSetter("**", i, j);
                    else if ((coordinates[i, j] != 1) && ((i == row) || (j == coloumn)))
                        ChessLib.Chess.BackgroundSetter("**", i, j);
                    else
                        ChessLib.Chess.BackgroundSetter("  ", i, j);
                }

                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(i + 1);
            }
            Console.WriteLine("  A B C D E F G H  ");
        }
    }
}

