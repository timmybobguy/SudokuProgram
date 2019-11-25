using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class Form : System.Windows.Forms.Form
    {
        protected Game game;
        private int lastHintIndex;
        private Panel sudokuPanel;
        private Control beingWiped;
        protected GameController controller;

        public void Initialise(Game theGame, GameController theGameController)
        {
            Controls.Clear();
            InitializeComponent();
            game = theGame;
            controller = theGameController;
            sudokuPanel = controller.MakeSudokuPanel();
            Controls.Add(sudokuPanel);
            Size = new Size(Size.Width, sudokuPanel.Size.Height + 260);
            numWrong.Visible = false;
            game.StartTimer();

            //Timer
            timerLabel.Text = game.timeTaken.ToString();
            Timer timer = new Timer();
            timer.Interval = (1000); // 10 secs
            timer.Tick += new EventHandler(UpdateTimer);
            timer.Start();
        }
        private void UpdateTimer(object sender, EventArgs e)
        {
            timerLabel.Text = game.timeTaken.ToString();
        }

        public void GenerateGrid(int[] originalNumbersArray, int[] currentSaveArray)
        {
            for (var i = 0; i < originalNumbersArray.Length; i++)
            {
                if (originalNumbersArray[i] == 0)
                {
                    if (currentSaveArray[i] != 0)
                    {
                        sudokuPanel.Controls.Add(controller.MakeSudokuButton("sudoku_", currentSaveArray[i].ToString(), game.GetRowByIndex(i), game.GetColumnByIndex(i), false));
                    }
                    else
                    {
                        sudokuPanel.Controls.Add(controller.MakeSudokuButton("sudoku_", "", game.GetRowByIndex(i), game.GetColumnByIndex(i), false));
                    }
                }
                else
                {
                    sudokuPanel.Controls.Add(controller.MakeSudokuButton("sudoku_", originalNumbersArray[i].ToString(), game.GetRowByIndex(i), game.GetColumnByIndex(i), true));
                }
                
            }
            // Giving all of the textboxes the commmon event + add the borders 
            foreach (Control ctrl in sudokuPanel.Controls)
            {
                if ((ctrl as TextBox) != null)
                {
                    (ctrl as TextBox).TextChanged += CommonHandler_TextChanged;
                }

                string[] splitArray = (ctrl as TextBox).Name.Split('_');

                int currentIndex = game.GetByColumn(int.Parse(splitArray[1]), int.Parse(splitArray[2]));

                

                if ( (game.GetRowByIndex(currentIndex) + 1) % (game.gridHeight / game.squareHeight) == 0) // it is on a row with a horizonal line, bottom
                {
                    (ctrl as TextBox).Controls.Add(new Label() { Height = 3, Dock = DockStyle.Bottom, BackColor = Color.Black });
                }

                if ( (game.GetColumnByIndex(currentIndex) + 1) % (game.gridWidth / game.squareWidth) - 1 == 0 && game.GetColumnByIndex(currentIndex) != 0 )
                {
                    (ctrl as TextBox).Controls.Add(new Label() { Width = 3, Dock = DockStyle.Left, BackColor = Color.Black });
                }  
            }
        }

        

        private async void ShowIncorrectInput(Control currentCell)
        {
            currentCell.BackColor = Color.Red;
            beingWiped = currentCell;
            currentCell.Text = null;
            beingWiped = null;
            await Task.Delay(1000);
            currentCell.BackColor = Color.White;
        }

        private void CommonHandler_TextChanged(object sender, EventArgs e)
        {
            Control currentCell = sudokuPanel.Controls.Find((sender as TextBox).Name, true)[0];
            string[] splitArray = (sender as TextBox).Name.Split('_');

            if (beingWiped != currentCell)
            {
                if (currentCell.Text != "")
                {
                    if (!game.IsDigitsOnly(currentCell.Text))
                    {
                        ShowIncorrectInput(currentCell);
                    }
                    else if (int.Parse(currentCell.Text) > game.numberOfSquares || int.Parse(currentCell.Text) == 0)
                    {
                        ShowIncorrectInput(currentCell);
                    }
                    else
                    {
                        game.SetByColumn(int.Parse(currentCell.Text), int.Parse(splitArray[1]), int.Parse(splitArray[2]));
                        CheckHighlighting(game.GetByColumn(int.Parse(splitArray[1]), int.Parse(splitArray[2])));
                        IsPuzzleFinished();
                        
                    }
                }
                else
                {
                    CheckHighlighting(game.GetByColumn(int.Parse(splitArray[1]), int.Parse(splitArray[2])));
                }
            }
        }

        private void CheckHighlighting(int index)
        {
            if (game.RowValid(game.GetRowByIndex(index)))
            {
                for (var i = 0; i < game.gridWidth; i++)
                {
                    Control current = sudokuPanel.Controls.Find("sudoku_" + i + "_" + game.GetRowByIndex(index), true)[0];

                    current.ForeColor = Color.Green;
                    // Work in progress 
                    //current.Enabled = false;
                }

                hintOutput.Text = "row valid";
            }
            
            if (game.ColumnValid(game.GetColumnByIndex(index)))
            {
                for (var i = 0; i < game.gridHeight; i++)
                {
                    Control current = sudokuPanel.Controls.Find("sudoku_" + game.GetColumnByIndex(index) + "_" + i, true)[0];
                    current.ForeColor = Color.Green;
                    //current.Enabled = false;
                }

                hintOutput.Text = "column valid";
            }
            
            if (game.SquareValid(game.GetSquareFromIndex(index)))
            {
                int square = game.GetSquareFromIndex(index);

                for (var i = 0; i < game.numberOfSquares; i++)
                {
                    Control current = sudokuPanel.Controls.Find("sudoku_" + game.GetColumnByIndex(game.GetBySquare(square, i)) + "_" + game.GetRowByIndex(game.GetBySquare(square, i)), true)[0];
                    current.ForeColor = Color.Green;
                    //current.Enabled = false;
                }

                hintOutput.Text = "square valid";
            }
            
        }

        private void IsPuzzleFinished()
        {
            if (game.IsPuzzleValid())
            {
                hintOutput.Text = "Complete. with a score of " + game.GetScore() + " and in a time of " + game.timeTaken + " seconds. The highscore for this game is " + game.highScore;
                game.SetHighScore();
                game.StopTimer();

                foreach (Control ctrl in sudokuPanel.Controls)
                {
                    if ((ctrl as TextBox) != null)
                    {
                        (ctrl as TextBox).Enabled = false;
                    }
                }

                

            }
            else if (Array.Exists(game.numbersArray, element => element == 0) != true)
            {
                int wrongNum = game.NumberOfIncorrectSquares();
                numWrong.Text = wrongNum.ToString() + " cell/s are still incorrect";
                numWrong.Visible = true;
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //Resetting last hint
            int? x = lastHintIndex;
            if (x.HasValue)
            {
                Control lastHint = sudokuPanel.Controls.Find("sudoku_" + game.GetColumnByIndex(lastHintIndex) + "_" + game.GetRowByIndex(lastHintIndex), true)[0];
                lastHint.BackColor = Color.White;
            }

            int[] hintArray = game.GetHint();
            Control hintTextBox = sudokuPanel.Controls.Find("sudoku_" + game.GetColumnByIndex(hintArray[0]) + "_" + game.GetRowByIndex(hintArray[0]), true)[0];


            string output = "";
            for (var i = 1; i < hintArray.Length; i++)
            {
                output += "- " + hintArray[i];
            }

            hintOutput.Text = output;
            lastHintIndex = hintArray[0];

            hintTextBox.BackColor = Color.Aqua;
            await Task.Delay(2000);
            hintTextBox.BackColor = Color.White;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            controller.SaveAndQuit(null, false);
        }

        private void restartButton_Click(object sender, EventArgs e)
        {
            controller.RestartGame();
        }
    }
}
