using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestSudoku
{
    class Program
    {
        static int squareHeight = 3;
        static int squareWidth = 2;
        static int gridWidth = squareWidth * squareWidth;
        static int gridHeight = squareHeight * squareHeight;
        static int[] numbersArray = { 2, 1, 5, 4, 3, 6, 3, 4, 2, 6, 5, 1, 5, 6, 1, 3, 2, 4, 6, 3, 4, 5, 1, 2, 4, 2, 3, 1, 6, 5, 1, 5, 6, 2, 4, 3 };
        static void Main(string[] args)
        {
            int row = 0;
            int column = 8;
            int squareIndex = 2;
            int squareOffset = 2;
            Console.WriteLine(DrawGrid());
            Console.WriteLine(GetByColumn(column, row));
            Console.WriteLine(GetByRow(row, column));
            Console.WriteLine(GetBySquare(squareIndex, squareOffset));

            Console.WriteLine(RowValid(0));
            Console.WriteLine(RowValid(1));
            Console.WriteLine(RowValid(2));
            Console.WriteLine(RowValid(3));

            Console.WriteLine(ColumnValid(0));
            Console.WriteLine(ColumnValid(1));
            Console.WriteLine(ColumnValid(2));
            Console.WriteLine(ColumnValid(3));

            Console.WriteLine(SquareValid(0));
            Console.WriteLine(SquareValid(1));
            Console.WriteLine(SquareValid(2));
            Console.WriteLine(SquareValid(3));

            Console.WriteLine("puzzle is " + isPuzzleValid());
            Console.ReadKey();
        }
        static string DrawGrid()
        {
            string line = String.Empty;
            for (int i = 0; i < gridWidth * gridHeight; i++)
            {
                bool endOfLine = i % gridWidth == 0 && i != 0;
                line += endOfLine ? "\n" + numbersArray[i] : numbersArray[i].ToString();
            }
            return line;
        }

        static int GetByColumn(int columnIndex, int rowIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(gridWidth * gridHeight)) + columnIndex);

            return index;
        }

        static int GetByRow(int rowIndex, int columnIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(gridWidth * gridHeight)) + columnIndex);

            return index;
        }

        static int GetBySquare(int squareIndex, int positionIndex)
        {
            int index = 0;
            for (int i = 1; i <= squareIndex; i++)
            {
                bool isEndOfLine = i % squareWidth == 0 && positionIndex != 0;
                index += (i % squareWidth == 0) ? ((squareWidth * squareWidth) * (squareHeight - 1)) + squareWidth : squareWidth;
            }
            for (int i = 1; i <= positionIndex; i++)
            {
                bool isEndOfLine = i % squareWidth == 0 && positionIndex != 0;
                index += isEndOfLine ? (((squareWidth * squareWidth) - squareWidth) + 1) : 1;
            }
            return index;
        }

        static void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            numbersArray[GetByColumn(columnIndex, rowIndex)] = value;
        }

        static void SetByRow(int value, int rowIndex, int columnIndex)
        {
            numbersArray[GetByRow(rowIndex, columnIndex)] = value;
        }

        static void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            numbersArray[GetBySquare(squareIndex, positionIndex)] = value;
        }

        static bool RowValid(int rowNumber)
        {
            int[] newArray = new int[gridWidth];
            for (int i = 0; i < gridWidth; i++)
            {
                int number = numbersArray[GetByRow(rowNumber, i)];
                if (number == 0 || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }
        static bool ColumnValid(int columnNumber)
        {
            int[] newArray = new int[gridHeight];
            for (int i = 0; i < gridHeight; i++)
            {
                int number = numbersArray[GetByColumn(columnNumber, i)];
                if (number == 0 || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }

        static bool SquareValid(int squareNumber)
        {
            int Boxes = squareWidth * squareHeight;
            int[] newArray = new int[Boxes];
            for (int i = 0; i < Boxes; i++)
            {
                int number = numbersArray[GetBySquare(squareNumber, i)];
                if (number == 0 || newArray.Contains(number))
                {
                    return false;
                }
                newArray[i] = number;

            }
            return true;
        }


        static bool isPuzzleValid()
        {
            for (int i = 0; i < gridHeight; i++)
            {
                if (!ColumnValid(i))
                {
                    return false;
                }
                if (!RowValid(i))
                {
                    return false;
                }
                if (!SquareValid(i))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
