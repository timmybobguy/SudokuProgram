using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;

namespace SudokuUnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestRestartMethod()
        {
            // Arrange 

            Game theSudoku = new Game();
       
            int[] expected = { 7, 3, 5, 6, 1, 4, 8, 9, 2, 8, 4, 2, 9, 7, 3, 5, 6, 1, 9, 6, 1, 2, 8, 5, 3, 7, 4, 2, 8, 6, 3, 4, 9, 1, 5, 7, 4, 1, 3, 8, 5, 7, 9, 2, 6, 5, 7, 9, 1, 2, 6, 4, 3, 8, 1, 5, 7, 4, 9, 2, 6, 8, 3, 6, 9, 4, 7, 3, 8, 2, 1, 5, 3, 2, 8, 5, 6, 1, 7, 4, 9 };
            int[] test = { 2, 3, 5, 6, 3, 4, 8, 9, 2, 3, 4, 2, 2, 7, 3, 5, 6, 1, 9, 6, 1, 2, 8, 5, 3, 7, 4, 2, 8, 6, 3, 4, 9, 1, 5, 7, 4, 1, 3, 8, 5, 7, 9, 2, 6, 5, 7, 9, 1, 2, 6, 4, 3, 8, 1, 5, 7, 4, 9, 2, 6, 8, 3, 6, 9, 4, 7, 3, 8, 2, 1, 5, 3, 2, 8, 5, 6, 1, 7, 4, 9 };


            // Act

            theSudoku.numbersArray = test;
            theSudoku.originalNumbersArray = expected;

            theSudoku.Restart();

            // Assert

            Assert.AreEqual(expected, theSudoku.numbersArray, "The array is reset to the original");
        }

        [TestMethod]
        public void TestGetMaxValue()
        {
            // Arrange 

            Game theSudoku = new Game();

            int expected = 5;

            // Act

            theSudoku.SetMaxValue(5);

            // Assert

            Assert.AreEqual(expected, theSudoku.GetMaxValue(), "The max value is set properly");
        }

        [TestMethod]
        public void TestSetCellMethod()
        {
            // Arrange 

            Game theSudoku = new Game();

            int[] numbers = { 7, 3, 5, 6, 1, 4, 8, 9 };
            theSudoku.Set(numbers);

            int expected = 3;

            // Act

            theSudoku.SetCell(3, 0);

            // Assert

            Assert.AreEqual(expected, theSudoku.GetCell(0), "The square width is set properly");
        }

        [TestMethod]
        public void TestSetCellMethod2()
        {
            // Arrange 

            Game theSudoku = new Game();

            int[] numbers = { 7, 3, 5, 6, 1, 4, 8, 9 };
            theSudoku.Set(numbers);

            int expected = 5;

            // Act

            theSudoku.SetCell(5, 7);

            // Assert

            Assert.AreEqual(expected, theSudoku.GetCell(7), "The square width is set properly");
        }
    }
}
