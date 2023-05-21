using System;
namespace ChessLib
{
    public class Knight
    {

        int[,] coordinates = new int[8, 8];
        int figureNumber = 0;
        int[] numbers = { -8, -12, -19, -21, 8, 12, 19, 21 };


        /// <summary>
        /// Creates a two-symbol integer from 1 one-symbol integers.
        /// </summary>
        /// <param name="i">Integer type variable.</param>
        /// <param name="j">Integer type variable.</param>
        /// <returns>Integer.</returns>
        public int coordsToNumber(int i, int j)
        {
            return int.Parse(string.Concat(i.ToString(), j.ToString()));
        }

        /// <summary>
        ///Recieves two-dimensional array of integers identifying the place of the
        ///figure, assignes the value of 2 to coordinates matching the legal steps' requirements.
        /// </summary>
        /// <param name="figure">String type variable.</param>
        /// <param name="coordinates">Two-dimensional array of integers.</param>
        /// <returns></returns>
        public int[,] AddLegalSteps(string figure, int[,] coordinates)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((coordinates[i, j] != 1) && (numbers.Contains(figureNumber - coordsToNumber(i,j))))
                        coordinates[i, j] = 2;
                }
            }
            return coordinates;
        }


        /// <summary>
        /// Prints the figure of Knigh on the board with the given coordinates, and available legal steps.
        /// </summary>
        /// <param name="figure">String type variable.</param>
        /// <param name="coordinates">Array of integers with i,j coordinates of the figure on the board.</param>
        public void BoardPrinterWithLegalSteps(string figure, int[,] coordinates)
        {
            this.coordinates = coordinates;

            //assign sum and dif variables of the class.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 1)
                    {
                        figureNumber = coordsToNumber(i, j);
                    }
                }

            }

            //make reference to the AddLegalSteps return type local membber from the coordinatesFigureSteps variable.
            int[,] coordinatesFigureSteps = AddLegalSteps(figure, coordinates);

            //print the board
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine("  A B C D E F G H  ");

            for (int i = 0; i < 8; i++)
            {
                Console.Write(" " + (i + 1));
                for (int j = 0; j < 8; j++)
                {
                    if (coordinatesFigureSteps[i, j] == 1)
                        ChessLib.Chess.BackgroundSetter((figure + " "), i, j);

                    else if (coordinatesFigureSteps[i, j] == 2)
                        ChessLib.Chess.BackgroundSetter("**", i, j);

                    else
                        ChessLib.Chess.BackgroundSetter("  ", i, j);
                }

                Console.BackgroundColor = ConsoleColor.White;
                Console.WriteLine(i + 1);
            }
        }

        public bool MoveTo(int[,] initialCoordinates, int[,] destinationCoordinates)
            {
            AddLegalSteps("n", initialCoordinates);

            int destRow = 0;
            int destColomn = 0;

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (destinationCoordinates[i, j] == 1)
                    {
                        destRow = i;
                        destColomn = j;
                        break;
                    }
                }
            }

            if (initialCoordinates[destRow, destColomn] == 2)
            {
                Console.BackgroundColor = ConsoleColor.Green;
                return true;
            }
            Console.BackgroundColor = ConsoleColor.Red;
            return false;
        }
    }
}

