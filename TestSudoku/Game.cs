using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Game : IGame, ISet, IGet, ISerialize
    {
        protected int squareWidth;
        protected int squareHeight;
        protected int max;
        public int[] numbersArray;

        public Game(int squareWidth, int squareHeight)
        {
            SetSquareHeight(squareWidth);
            SetSquareWidth(squareHeight);
            numbersArray = new int[(squareWidth * squareWidth) * (squareHeight * squareHeight)];
            ShowIndexes();
        }

        public void ShowIndexes()
        {
            for (int i = 0; i < ((squareWidth * squareWidth) * (squareHeight * squareHeight)); i++)
            {
                numbersArray[i] = i;
            }
        }

        public void SetMaxValue(int maximum)
        {
            max = maximum;
        }

        public int GetMaxValue()
        {
            return max;
        }

        public int[] ToArray()
        {
            return numbersArray;
        }

        public void Set(int[] cellValues)
        {
            numbersArray = cellValues;
        }

        public void SetSquareWidth(int theSquareWidth)
        {
            squareWidth = theSquareWidth;
        }

        public void SetSquareHeight(int theSquareHeight)
        {
            squareHeight = theSquareHeight;
        }

        public void Restart()
        {

        }

        public int GetByColumn(int columnIndex, int rowIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(numbersArray.Length)) + columnIndex);

            return index;
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(numbersArray.Length)) + columnIndex);

            return index;
        }

        public int GetBySquare(int squareIndex, int positionIndex)
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

        public void SetByColumn(int value, int columnIndex, int rowIndex)
        {
            numbersArray[GetByColumn(columnIndex, rowIndex)] = value;
        }

        public void SetByRow(int value, int rowIndex, int columnIndex)
        {
            numbersArray[GetByRow(rowIndex, columnIndex)] = value;
        }

        public void SetBySquare(int value, int squareIndex, int positionIndex)
        {
            numbersArray[GetBySquare(squareIndex, positionIndex)] = value;
        }

        public void FromCSV(string csv)
        {
            int[] arrayOfNumbers = new int[numbersArray.Length];
            string stringNumbers = System.IO.File.ReadAllText(@"..\..\..\..\Export\" + csv + ".csv");
            string[] arrayOfStrings = stringNumbers.Split(',');
            for (int i = 0; i < arrayOfStrings.Length; i++)
            {
                bool success = Int32.TryParse(arrayOfStrings[i].ToString(), out int number);
                if (success)
                {
                    Console.WriteLine("square " + i + "set to: " + number);
                    numbersArray[i] = number;
                }
                else
                {
                    Console.WriteLine("Error setting square " + i + "set to: " + 0);
                    Console.WriteLine(arrayOfStrings[i].ToString());
                    numbersArray[i] = 0;
                }

            }
        }

        public string ToCSV()
        {
            string[] stringArray = new string[numbersArray.Length];
            for (int i = 0; i < numbersArray.Length; i++)
            {
                stringArray[i] = numbersArray[i].ToString();
            }

            System.IO.File.WriteAllLines(@"..\..\..\..\Export\Numbers.csv", stringArray);
            return String.Join(",", stringArray);

        }

        public void SetCell(int value, int gridIndex)
        {
            numbersArray[gridIndex] = value;
        }

        public int GetCell(int gridIndex)
        {
            return numbersArray[gridIndex];
        }

        public string ToPrettyString(IView view)
        {
            string line = view.MakeLine(squareWidth) + "\n";
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (i % squareWidth == 0)
                {
                    line += "|";
                }
                if (i % ((squareWidth * squareWidth) * squareHeight) == 0 && i != 0)
                {
                    line += "\n" + view.MakeLine(squareWidth);
                }
                bool endOfLine = i % (squareWidth * squareWidth) == 0 && i != 0;
                line += endOfLine ? "\n|" + view.MakeSquare(numbersArray[i]) : view.MakeSquare(numbersArray[i]);
            }
            return line + "|\n" + view.MakeLine(squareWidth);
        }
    }
}
