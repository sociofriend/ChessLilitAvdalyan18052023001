using System;
namespace ChessLib
{
	public class Bishop
	{
		public Bishop()
		{

		}

        /// <summary>
        /// Prints the board with 10x10 size with given figure on given coordinates i,j 
        /// and legal steps of the figure from the given coordinates.
        /// </summary>
        /// <param name="figure">String type variable.</param>
        /// <param name="coordinates">Array of integers with i,j coordinates of the figure on the board.</param>
        public static void BoardPrinterWithLegalSteps(string figure, int[,] coordinates)
        {
            int figureCoordinatesSum = 0;
            int figureCoordinatesDiff = 0;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 1)
                    {
                        figureCoordinatesSum = i + j;
                        figureCoordinatesDiff = i - j;
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

