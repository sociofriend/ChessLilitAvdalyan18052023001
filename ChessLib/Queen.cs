using System;
namespace ChessLib
{
    public class Queen
    {
        static int sum = 0;
        static int dif = 0;
        static int[,] coordinates = new int[8, 8];

        /// <summary>
        ///Recieves two-dimensional array of integers identifying the place of the
        ///figure, assignes the value of 2 to coordinates matching the legal steps' requirements.
        /// </summary>
        /// <param name="figure">String type variable.</param>
        /// <param name="coordinates">Two-dimensional array of integers.</param>
        /// <returns></returns>
        public static int[,] AddLegalSteps(string figure, int[,] coordinates)
        {
            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    if ((coordinates[i, j] != 1) && ((i + j) == sum || (i - j == dif)))
                        coordinates[i, j] = 2;
                }
            }
            return coordinates;
        }


        /// <summary>
        /// Prints the figure of Queen on the board with the given coordinates, and available legal steps.
        /// </summary>
        /// <param name="figure">String type variable.</param>
        /// <param name="coordinates">Array of integers with i,j coordinates of the figure on the board.</param>
        public static void BoardPrinterWithLegalSteps(string figure, int[,] coordinates)
        {
            Queen.coordinates = coordinates;

            //assign sum and dif variables of the class.
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 1)
                    {
                        sum = i + j;
                        dif = i - j;
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
            Console.WriteLine("  A B C D E F G H  ");
        }


        /// <summary>
        /// Shows whether the given figure may take the given step.
        /// </summary>
        /// <param name=""></param>
        /// <param name=""></param>
        /// <returns></returns>
        public static bool MoveTo(int[,] initialCoordinates, int[,] destinationCoordinates)
        {
            AddLegalSteps("q", initialCoordinates);

            int destRow = 0;
            int destColomn = 0;

            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    if (destinationCoordinates[i,j] == 1)
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

