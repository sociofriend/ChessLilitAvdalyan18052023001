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

        public string coordsToString(int i, int j)
        {
            return string.Concat(i.ToString(), j.ToString());
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
                    if (coordinates[i, j] == 1)
                    {
                        figureNumber = coordsToNumber(i, j);
                        break;
                    }
                }
            }

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((coordinates[i, j] != 1) && (numbers.Contains(figureNumber - coordsToNumber(i, j))))
                        coordinates[i, j] = 2;
                }
            }
            return coordinates;
        }

        public string[] LegalStepsToArrey(int[,] coordinates)
        {
            coordinates = AddLegalSteps("n", coordinates);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 1)
                    {
                        figureNumber = coordsToNumber(i, j);
                        break;
                    }
                }
            }

            int count = 0;
            string[] steps = new string[8];
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (coordinates[i, j] == 2 && numbers.Contains(figureNumber - coordsToNumber(i, j)))
                    {
                        steps[count] = coordsToString(i, j);
                        count++;
                    }
                }
            }
            return steps;
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

        /// <summary>
        /// Shows whether the given figure may take the given step.
        /// </summary>
        /// <param name="initialCoordinates">Array of integers where figure coordinates is given i,j.
        /// Identifies the initial coordinates of the given figure.</param>
        /// <param name="destinationCoordinates">Array of integers where figure coordinates is given i,j.
        /// Identifies the destination coordinates of the given figure.</param>
        /// <returns>Boolean value.</returns>
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

        /// <summary>
        /// Counts steps mvoed for getting to destination coordinates.
        /// </summary>
        /// <param name="initialCoordinates"></param>
        /// <param name="destinationCoordinates"></param>
        /// <returns></returns>

        int countOfSteps = 0;
        public int FindMinStepsToDest(int[,] initialCoordinates, int[,] destinationCoordinates)
        {
            string[] initialSteps = LegalStepsToArrey(initialCoordinates);
            string[] destinationSteps = LegalStepsToArrey(destinationCoordinates);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (destinationCoordinates[i, j] == 1)
                    {
                        figureNumber = coordsToNumber(i, j);
                    }
                }
            }


            if (initialCoordinates == destinationCoordinates)
                return countOfSteps;

            foreach (string element in initialSteps)
            {
                if (element != null && element.Equals(figureNumber.ToString()))
                    return countOfSteps+1;
            }

            foreach (string element in initialSteps)
            {
                foreach (string elem in destinationSteps)
                {
                    if (element != null && elem != null && element.Equals(elem))
                        return countOfSteps+2;
                }
            }
            countOfSteps = 3;
            foreach (string el in initialSteps)
            {
                foreach (string e in destinationSteps)
                {
                    int i = Int32.Parse(el) % 10;
                    int j = Int32.Parse(el) - i;
                    return FindMinStepsToDest(Coordinates.CreateArray2D(i, j), destinationCoordinates);
                }
            }
            return countOfSteps;
        }
    }
}


