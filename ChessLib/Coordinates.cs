using System;
namespace ChessLib
{
    public struct Coordinates
    {
        //fields
        public static int[,] coordinates = new int[8, 8];
        static int row, colomn, sum, diff;

        //static constructor is implemented to prevent class object creation 

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
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i == m && j == n)
                    { 
                        coordinates[i, j] = 1;
                        row = i;
                        colomn = j;
                        sum = i + j;
                        diff = i - j;
                    }
                }
            }
            return coordinates;
        }
    }
}

