namespace ChessLib;
public class Chess
{
    /// <summary>
    /// Sets background colorwith given coordinates i, j set in two-dimensional array
    /// </summary>
    /// <param name="cellValue"></param>
    /// <param name="i">int type variable.</param>
    /// <param name="j">int type variable.</param>
    public static void BackgroundSetter(string cellValue, int i, int j)
    {
        if ((i + j) % 2 == 0)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.Write(cellValue);
        }
        else
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Write(cellValue);
        }
    }


    /// <summary>
    /// Prints the board with 10x10 size, given figure on given coordinates i,j.
    /// </summary>
    /// <param name="figure">String type variable.</param>
    /// <param name="coordinates">Array of integers with i,j coordinates of the figure on the board.</param>
    public static void BoardPrinterWithFigure(string figure, int[,] coordinates)
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.WriteLine("  A B C D E F G H  ");
        for (int i = 0; i < 8; i++)
        {
            Console.Write(" " + (i + 1));
            for (int j = 0; j < 8; j++)
            {
                if (coordinates[i, j] == 0)
                    BackgroundSetter("  ", i, j);

                else
                    BackgroundSetter((figure + " "), i, j);
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine(i + 1);
        }
        Console.WriteLine("  A B C D E F G H  ");
    }
}

