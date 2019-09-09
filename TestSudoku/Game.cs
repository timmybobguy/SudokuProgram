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
        protected int gridWidth;
        protected int gridHeight;
        protected int max;
        public int[] numbersArray;

        public Game(int squareWidth, int squareHeight)
        {
            SetSquareHeight(squareWidth);
            SetSquareWidth(squareHeight);
            gridHeight = gridWidth = squareHeight * squareWidth;
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
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(gridWidth * gridHeight)) + columnIndex);

            return index;
        }

        public int GetByRow(int rowIndex, int columnIndex)
        {
            int index = Convert.ToInt32((rowIndex * Math.Sqrt(gridWidth * gridHeight)) + columnIndex);

            return index;
        }

        public int GetBySquare(int squareIndex, int positionIndex)
        {
            int index = 0;
            for (int i = 1; i <= squareIndex; i++)
            {
                bool isEndOfLine = i % (gridWidth / squareWidth) == 0;
                index += isEndOfLine ? (gridWidth * (squareHeight - 1)) + squareWidth : squareWidth;
            }
            for (int i = 1; i <= positionIndex; i++)
            {
                bool isEndOfLine = i % squareWidth == 0 && positionIndex != 0;
                index += isEndOfLine ? ((gridWidth - squareWidth) + 1) : 1;
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

        public bool RowValid(int rowNumber)
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

        public bool ColumnValid(int columnNumber)
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

        public bool SquareValid(int squareNumber)
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


        public bool isPuzzleValid()
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

        public int[] GetValidValues(int index)
        {
            int maxSize = squareHeight * squareWidth;
            int[] possibleValues = new int[maxSize];

            for (var i = 0; i < maxSize; i++)
            {
                possibleValues[i] = (i + 1);
            }
            int col = GetColumnByIndex(index);
            int row = GetRowByIndex(index);
            int square = GetSquareFromIndex(col, row);
            int amountRemoved = 0;
            for (var i = 0; i < gridHeight; i++)
            {
                if (numbersArray[GetByColumn(col, i)] != 0)
                {
                    if (possibleValues.Contains(numbersArray[GetByColumn(col, i)]))
                    {
                        possibleValues[numbersArray[GetByColumn(col, i)] - 1] = 0;
                        amountRemoved++;
                        continue;
                    }

                    if (possibleValues.Contains(numbersArray[GetByRow(row, i)]))
                    {
                        possibleValues[numbersArray[GetByRow(row, i)] - 1] = 0;
                        amountRemoved++;
                        continue;
                    }
                    if (possibleValues.Contains(numbersArray[GetBySquare(square, i)]))
                    {
                        possibleValues[numbersArray[GetBySquare(square, i)] - 1] = 0;
                        amountRemoved++;
                        continue;
                    }
                }
            }
            Array.Sort(possibleValues);
            Array.Reverse(possibleValues);
            int endLength = possibleValues.Length - amountRemoved;
            int[] returnedValues = new int[endLength];
            for (int i = 0; i < endLength; i++)
            {
                if (possibleValues[i] != 0)
                {
                    returnedValues[i] = possibleValues[i];
                }

            }
            Array.Sort(returnedValues);
            return returnedValues;
        }

        public int GetRowByIndex(int index)
        {
            return index / gridWidth;
        }

        public int GetColumnByIndex(int index)
        {
            return index % gridWidth;
        }

        public int GetSquareFromIndex(int col, int row)
        {
            int squareCol = (col) / squareWidth;
            int squareRow = (row) / squareHeight;
            int square = squareRow * squareWidth + squareCol;
            return square;
        }
    }
}
