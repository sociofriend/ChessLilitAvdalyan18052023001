using System;
namespace ChessLib
{
    public struct Coordinates
    {
        public Coordinates()
        {

        }

        /// <summary>
        /// Creates two-dimensional array of integers with user coordinates for figure.
        /// </summary>
        /// <param name="row">Integer type variable identifying
        /// user input coordinate for row number.</param>
        /// <param name="colomn">Integer type variable identifying
        /// user input coordinate for colomn number.</param>
        /// <returns>Returns two-dimensional array of integers.</returns>
        public static int[,] CreateArray2D(int m, int n)
        {
            int[,] coordinates = new int[8, 8];

            for (int i = 0; i < 8; i++)
                {
                    for (int j = 0; j < 8; j++)
                    {
                        if (i == n && j == m)
                        {
                            coordinates[i, j] = 1;
                        }
                    }
                }
            return coordinates;
        }
    }
}

