using System;
using ChessLib;
namespace ChessProject
{
	public class Chess
	{
		public Chess()
		{
			Console.WriteLine("Chess Project running...");
		}

        /// <summary>
        /// Runs GetFigure(), GetCoordinates() and PrintBoard(string figure, int[] coordinates) methods.
        /// Prints the board with given figure on given coordinates' cell.
        /// </summary>
        public void RunChess()
        {
            //PrintBoard(GetFigure(), GetCoordinates());
            PrintBoardWithNewSteps();
            Console.BackgroundColor = ConsoleColor.White;
            Console.WriteLine();
            RunChess();
        }

        /// <summary>
        /// Gets user input for chess figure to print on the board.Type: string.
        /// </summary>
        /// <returns></returns>
        string GetFigure()
        {
            Console.WriteLine("Choose a figure: press R for rook, N " +
            "for knight, B for bishop, K for king and Q for queen.");

            string figure = Console.ReadLine().ToUpper();


            if (figure != null && Enum.TryParse<HotKeys>(figure, out HotKeys result))
            {
                return figure;
            }
            else
            {
                Console.WriteLine("WRONG INPUT: Please input a letter from the suggested options.");
                return GetFigure();
            }
        }

        /// <summary>
        /// Gets user input on coordinates for identifying on which chell to print the figure.
        /// </summary>
        /// <returns></returns>
        int[,] GetCoordinates()
        {
            //int[,] coordinates = new int[8, 8];
            Console.WriteLine("Input command, where first symbol is a letter " +
                "from ՛a՛ to ՛h՛ or 'A' to 'H' and second command is a number from ՛1՛ to ՛8՛ (ex.a8 or H1)");
            string input = Console.ReadLine().ToUpper();

            if ((input.Length == 2) && (input[0] >= 65 && input[0] <= 72) &&
                (input[1] >= 49 && input[1] <= 56))
                return ChessLib.Coordinates.CreateArray2D(((int)input[0] - 65),((int)input[1] - 49));
            else
            {
                Console.WriteLine("WRONG INPUT: Please input two-symbol command");
                return GetCoordinates();
            }
        }

        /// <summary>
        /// Prints the chess board with user inputs for figure and coordinates. For chess common features
        /// project uses ChessLib. Switch case is implemented to choose class from ChessLib.
        /// </summary>
        /// <param name="figure"></param>
        /// <param name="coordinates"></param>
        void PrintBoard(string figure, int[,] coordinates)
        {
            switch (figure)
            {
                case "K":
                    King king = new King();
                    king.BoardPrinterWithLegalSteps(figure, coordinates);
                    Console.WriteLine("Please enter initial then destination coordinates for King.".ToUpper());
                    Console.WriteLine();
                    Console.WriteLine(king.MoveTo(GetCoordinates(), GetCoordinates()));
                    break;
                case "R":
                    Rook rook = new Rook();
                    rook.BoardPrinterWithLegalSteps(figure, coordinates);
                    Console.WriteLine("Please enter initial then destination coordinates for ROOK.".ToUpper());
                    Console.WriteLine();
                    Console.WriteLine(rook.MoveTo(GetCoordinates(), GetCoordinates()));
                    break;
                case "N":
                    Knight knight = new Knight();
                    knight.BoardPrinterWithLegalSteps(figure, coordinates);
                    Console.WriteLine("Please enter initial then destination coordinates for Knight.".ToUpper());
                    Console.WriteLine();
                    Console.WriteLine(knight.MoveTo(GetCoordinates(), GetCoordinates()));
                    break;
                case "B":
                    Bishop bishop = new Bishop();
                    bishop.BoardPrinterWithLegalSteps(figure, coordinates);
                    Console.WriteLine("Please enter initial then destination coordinates for Bishop.".ToUpper());
                    Console.WriteLine();
                    Console.WriteLine(bishop.MoveTo(GetCoordinates(), GetCoordinates()));
                    break;
                case "Q":
                    Queen queen = new Queen();
                    queen.BoardPrinterWithLegalSteps(figure, coordinates);
                    Console.WriteLine("Please enter initial then destination coordinates for Queen.".ToUpper());
                    Console.WriteLine();
                    Console.WriteLine(queen.MoveTo(GetCoordinates(), GetCoordinates()));
                    break;
            }
        }
        /// <summary>
        /// Prints given initial and destionation coordinates of the given figure with legal steps.
        /// </summary>
        void PrintBoardWithNewSteps()
        {
            string figure1 = GetFigure();
            Console.WriteLine("\nPlease input the initial  coordinates: ");
            int[,] initialCoordinates = GetCoordinates();
            Console.WriteLine("\nNow please input the destination  coordinates: ");
            int[,] destinationCoordinates = GetCoordinates();

            switch(figure1)
            {
                case "K":
                    King king = new King();
                    king.BoardPrinterWithLegalSteps(figure1, initialCoordinates);
                    if (king.MoveTo(initialCoordinates, destinationCoordinates))
                    {
                        Console.WriteLine("Right input.");
                        king.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    else
                    {
                        Console.WriteLine("\nWRONG INPUT: Please input a legal step.");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\nNow please input the destination  coordinates: ");
                        destinationCoordinates = GetCoordinates();
                        king.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    break;
                case "R":
                    Rook rook = new Rook();
                    rook.BoardPrinterWithLegalSteps(figure1, initialCoordinates);
                    if (rook.MoveTo(initialCoordinates, destinationCoordinates))
                    {
                        Console.WriteLine("Right input.");
                        rook.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    else
                    {
                        Console.WriteLine("\nWRONG INPUT: Please input a legal step.");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\nNow please input the destination  coordinates: ");
                        destinationCoordinates = GetCoordinates();
                        rook.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    break;
                case "N":
                    Knight knight = new Knight();
                    knight.BoardPrinterWithLegalSteps(figure1, initialCoordinates);
                    if (knight.MoveTo(initialCoordinates, destinationCoordinates))
                    {
                        Console.WriteLine("Right input.");
                        knight.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    else
                    {
                        Console.WriteLine("\nWRONG INPUT: Please input a legal step.");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\nNow please input the destination  coordinates: ");
                        destinationCoordinates = GetCoordinates();
                        knight.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                        break;
                case "B":
                    Bishop bishop = new Bishop();
                    bishop.BoardPrinterWithLegalSteps(figure1, initialCoordinates);
                    if (bishop.MoveTo(initialCoordinates, destinationCoordinates))
                    {
                        Console.WriteLine("Right input.");
                        bishop.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    else
                    {
                        Console.WriteLine("\nWRONG INPUT: Please input a legal step.");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\nNow please input the destination  coordinates: ");
                        destinationCoordinates = GetCoordinates();
                        bishop.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                        break;
                case "Q":
                    Queen queen = new Queen();
                    queen.BoardPrinterWithLegalSteps(figure1, initialCoordinates);
                    if (queen.MoveTo(initialCoordinates, destinationCoordinates))
                    {
                        Console.WriteLine("Right input.");
                        queen.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                    else
                    {
                        Console.WriteLine("\nWRONG INPUT: Please input a legal step.");
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.WriteLine("\nNow please input the destination  coordinates: ");
                        destinationCoordinates = GetCoordinates();
                        queen.BoardPrinterWithLegalSteps(figure1, destinationCoordinates);
                    }
                        break;
            }
        }
    }
}

