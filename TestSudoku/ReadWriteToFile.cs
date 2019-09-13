﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;
using System.Runtime.Serialization.Json;

namespace Sudoku
{
    partial class Game : ISerialize
    {
        public void FromCSV(string csv, bool loadSave)
        {
            string csvText = System.IO.File.ReadAllText(@"..\..\..\Export\" + csv + ".csv");
            Dictionary<string, string> csvParts = SplitInput(csvText);
            string OriginalSudoku = csvParts["OriginalSudoku"];
            string EditedSudoku = csvParts.ContainsKey("EditedSudoku") ? csvParts["EditedSudoku"]: null;
            string Settings = csvParts["Settings"];
            GameSettings csvSettings = ReadJsonSettings(Settings);
            SetSettings(csvSettings);
            LoadNumbersArray(OriginalSudoku, loadSave?EditedSudoku:OriginalSudoku);
        }

        public void LoadNumbersArray(string sudoku, string editedSudoku)
        {
            int[] numbers = ToNumberList(sudoku);
            int[] EditedNumbers = ToNumberList(editedSudoku);
            originalNumbersArray = numbers;
            lastSaveNumbersArray = EditedNumbers;
            for (int i = 0; i < numbers.Length; i++)
            {
                SetCell(EditedNumbers[i], i);
            }
        }

        public GameSettings ReadJsonSettings(string settings)
        {
            var deserializedUser = new GameSettings();
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(settings));
            var ser = new DataContractJsonSerializer(deserializedUser.GetType());
            deserializedUser = ser.ReadObject(ms) as GameSettings;
            ms.Close();
            return deserializedUser;
        }

        public void SetSettings(GameSettings s)
        {
            SetSquareWidth(s.SquareWidth);
            SetSquareHeight(s.SquareHeight);
            highScore = s.Highscore;
            targetTime = s.TargetTime;
            hintsUsed = s.HintsUsed;
            timeTaken = s.TimeSpent;
            baseScore = s.BaseScore;
            gridHeight = gridWidth = squareWidth * squareHeight;
            gridLength = gridHeight * gridWidth;
            numberOfSquares = gridHeight;
            numbersArray = new int[gridLength];
            originalNumbersArray = new int[gridLength];
            lastSaveNumbersArray = new int[gridLength];
        }

        public Dictionary<string, string> SplitInput(string input)
        {
            var parts = new Dictionary<string, string>();
            string[] inputParts = input.Split('*');
            parts.Add("Settings", inputParts[0]);
            parts.Add("OriginalSudoku", inputParts[1]);
            if (inputParts.Length>2)
            {
                parts.Add("EditedSudoku", inputParts[2]);
            }
            return parts;
        }

        public int[] ToNumberList(string csvString)
        {
            string[] arrayOfStrings = Regex.Replace(csvString.TrimEnd('\r', '\n'), @"\t|\r\n", ",").Split(',');
            return Array.ConvertAll(arrayOfStrings, int.Parse);
        }

        public string ToCSV()
        {
            string csvString = ToCSVString();
            File.WriteAllText(@"..\..\..\Export\Export.csv", csvString);
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
                if (i % squareHeight == 0)
                {
                    line += "|";
                }
                if (i % ((squareWidth * squareWidth) * squareHeight) == 0 && i != 0)
                {
                    line += "\n" + MakeLine(squareWidth);
                }
                bool endOfLine = i % (squareWidth * squareHeight) == 0 && i != 0;
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
            string result = " ";
            do
            {
                result += "-";
                i++;
            } while (i <= n * numberOfSquares+ (numberOfSquares+1));
            return result;
        }
        /*
        public string s(string x)
        {
            Func<string, string, string> q = (m, n) => m + n + m + n + m;
            var a = "╔" + q(q("=", "╤"), "╦") + "╗";
            for (var i = 0; i < gridHeight;) //once per row
            {
                //parse that row to an int, then spit out a formatted string
                a += int.Parse(x.Substring(i * gridWidth, gridHeight)).ToString("\n║" + q(q(" 0 ", "│"), "║") + "║\n")
                  // as well as a trailing row for the box
                  + (i++ < (numberOfSquares-1) ? (i % gridWidth-1 > 0 ? "╟" + q(q("-", "┼"), "╫") + "╢" : "╠" + q(q("=", "╪"), "╬") + "╣") : "╚" + q(q("=", "╧"), "╩") + "╝");
            }
            //expand placeholder characters before returning
            return a.Replace("=", "═══").Replace("-", "───").Replace("0", " ");
        }*/
    }
}
