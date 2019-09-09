using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Validator : Game
    {
        private int gridLength;
        public Validator(int squareWidth, int squareHeight) : base(squareWidth, squareHeight)
        {
            gridLength = squareWidth * squareHeight;
        }

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
