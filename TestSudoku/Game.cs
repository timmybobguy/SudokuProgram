using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    partial class Game : IGame
    {
        protected int squareWidth;
        protected int squareHeight;
        protected int gridWidth;
        protected int gridHeight;
        protected int gridLength;
        protected int max;
        protected int numberOfSquares;
        public int[] numbersArray;
        public int[] originalNumbersArray;
        public int[] lastSaveNumbersArray;

        public Game(int squareWidth, int squareHeight)
        {
            SetSquareHeight(squareWidth);
            SetSquareWidth(squareHeight);
            gridHeight = gridWidth = squareHeight * squareWidth;
            gridLength = gridHeight * gridWidth;
            numberOfSquares = gridHeight;
            numbersArray = new int[gridLength];
            originalNumbersArray = new int[gridLength];
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

        public void Restart() => loadSave(originalNumbersArray);

        public void loadLastSave() => loadSave(lastSaveNumbersArray);

        public void loadSave(int [] arrayToLoad) => numbersArray = arrayToLoad;

    }
}
