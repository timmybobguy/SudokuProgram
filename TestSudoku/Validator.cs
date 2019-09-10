using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    partial class Game
    { 
        public bool IsPuzzleValid()
        {
            for (int i = 0; i < gridLength; i++)
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

        private bool RowValid(int rowNumber)
        {
            int[] newArray = new int[gridLength];
            for (int i = 0; i < gridLength; i++)
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
        private bool ColumnValid(int columnNumber)
        {
            int[] newArray = new int[gridLength];
            for (int i = 0; i < gridLength; i++)
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

        private bool SquareValid(int squareNumber)
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
    }
}
