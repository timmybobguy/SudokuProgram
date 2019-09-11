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
            string result = string.Empty;
            int[] possibleValues = new int[gridWidth];
            for (var i = 0; i < gridWidth; i++)
            {
                possibleValues[i] = (i + 1);
            }
            int col = GetColumnByIndex(index);
            int row = GetRowByIndex(index);
            int square = GetSquareFromIndex(index);
            for (var i = 0; i < gridHeight; i++)
            {
                int colVal = numbersArray[GetByColumn(col, i)];
                if(colVal != 0)
                {
                    if (possibleValues.Contains(colVal))
                    {
                        possibleValues[colVal - 1] = 0;
                    }
                }
                int rowVal = numbersArray[GetByRow(row, i)];
                if(rowVal != 0)
                {
                    if (possibleValues.Contains(rowVal))
                    {
                        possibleValues[rowVal - 1] = 0;
                    }
                }
                int squareVal = numbersArray[GetBySquare(square, i)];
                if(squareVal != 0)
                {
                    if (possibleValues.Contains(squareVal))
                    {
                        possibleValues[squareVal - 1] = 0;
                    }
                }
            }
            foreach (int val in possibleValues)
            {
                if (val != 0)
                {
                    result += val.ToString() + ",";
                }
            }
            int[] validValues = Array.ConvertAll(result.TrimEnd(',').Split(','), int.Parse);
            Array.Sort(validValues);
            return validValues;
        }

        private bool RowValid(int rowNumber)
        {
            int[] newArray = new int[gridLength];
            for (int i = 1; i < gridWidth; i++)
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
            for (int i = 1; i < gridHeight; i++)
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

        private bool CellValid(int index)
        {
            if (SquareValid(GetSquareFromIndex(index)) && (RowValid(GetRowByIndex(index))) && (ColumnValid(GetColumnByIndex(index))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
