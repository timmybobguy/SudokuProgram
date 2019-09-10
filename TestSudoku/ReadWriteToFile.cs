using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Sudoku
{
    partial class Game : ISerialize
    {
        public void FromCSV(string csv)
        {
            string csvText = System.IO.File.ReadAllText(@"..\..\..\..\Export\" + csv + ".csv");
            Dictionary<int, int> numbers = ToNumberList(csvText);
            for( int i = 0; i< numbers.Count; i++ )
            {
                SetCell(numbers[i], i);
            }
        }

        public Dictionary<int, int> ToNumberList(string csvString)
        {
            var numbers = new Dictionary<int, int>();
            string[] arrayOfStrings = Regex.Replace(csvString, @"\t|\r\n", ",").Split(',');
            for (int i = 0; i < numbersArray.Length; i++)
            {
                numbers.Add(i,Int32.Parse(arrayOfStrings[i]));
            }
            return numbers;
        }

        public string ToCSV()
        {
            string csvString = ToCSVString();
            System.IO.File.WriteAllText(@"..\..\..\..\Export\Numbers.csv", csvString);
            return csvString;
        }

        public string ToCSVString()
        {
            string result = string.Empty;
            for (int i = 0; i < numbersArray.Length; i++)
            {
                string number = numbersArray[i].ToString();
                bool endOfLine = i % Math.Sqrt(numbersArray.Length) == 0 && i != 0;
                bool isLastNumber = i == numbersArray.Length;
                result += isLastNumber ? number : endOfLine ? "\n" + number + "," : number + ",";
            }
            return result;
        }

        public int GetCell(int gridIndex) => numbersArray[gridIndex];

        public void SetCell(int value, int gridIndex) => numbersArray[gridIndex] = value;
 
        public string ToPrettyString()
        {
            string line = MakeLine(squareWidth) + "\n";
            for (int i = 0; i < numbersArray.Length; i++)
            {
                if (i % squareWidth == 0)
                {
                    line += "|";
                }
                if (i % ((squareWidth * squareWidth) * squareHeight) == 0 && i != 0)
                {
                    line += "\n" + MakeLine(squareWidth);
                }
                bool endOfLine = i % (squareWidth * squareWidth) == 0 && i != 0;
                line += endOfLine ? "\n|" + MakeSquare(numbersArray[i]) : MakeSquare(numbersArray[i]);
            }
            return line + "|\n" + MakeLine(squareWidth);
        }


        public string MakeSquare(int number)
        {
            string result = number.ToString();
            if (number.ToString().Length == 1)
            {
                result = " " + number + "  ";
            }
            if (number.ToString().Length == 2)
            {
                result = " " + number + " ";
            }
            return result;
        }

        public string MakeLine(int n)
        {
            int i = 0;
            string result = "";
            do
            {
                result += "-";
                i++;
            } while (i <= ((n * n) * 4) + n);
            return result;
        }

    }
}
