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

        public void Restart() => LoadSave(originalNumbersArray);

        public void LoadLastSave() => LoadSave(lastSaveNumbersArray);

        public void LoadSave(int [] arrayToLoad) => numbersArray = arrayToLoad;

    }
}
