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
    public partial class SudokuForm : Form
    {
        protected Game game;
        private int lastHintIndex;
        private Panel sudokuPanel;
        private Control beingWiped;

        public void Initialise(Game theGame)
        {
            Controls.Clear();
            InitializeComponent();
            game = theGame;
            sudokuPanel = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(game.gridHeight * 50, game.gridWidth * 50),
                BorderStyle = BorderStyle.Fixed3D
            };
            Controls.Add(sudokuPanel);
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

        public void MakeSudokuButton(string name, string value, int row, int column, bool locked)
        {
            TextBox btnNew = new TextBox
            {
                Name = name + column.ToString() + "_" + row.ToString(),
                Height = 50,
                Width = 50,
                Font = new Font("Arial", 20),
                Text = value,
                Visible = true,
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.None
            };

            if (locked == true)
            {
                btnNew.ReadOnly = true;
                btnNew.Enabled = false;
            }
            btnNew.Location = new Point(50 * column, 50 * row);

            sudokuPanel.Controls.Add(btnNew);
        }

        public void GenerateGrid(int[] numbersArray)
        {
            for (var i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] == 0)
                {
                    MakeSudokuButton("sudoku_", "", game.GetRowByIndex(i), game.GetColumnByIndex(i), false);
                }
                else
                {
                    MakeSudokuButton("sudoku_", numbersArray[i].ToString(), game.GetRowByIndex(i), game.GetColumnByIndex(i), true);
                }
                
            }
            // Giving all of the textboxes the commmon event
            foreach (Control ctrl in sudokuPanel.Controls)
            {
                if ((ctrl as TextBox) != null)
                {
                    (ctrl as TextBox).TextChanged += CommonHandler_TextChanged;
                }
            }
        }

        bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
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

            if (beingWiped != currentCell)
            {
                if (currentCell.Text != "")
                {
                    if (!IsDigitsOnly(currentCell.Text))
                    {
                        ShowIncorrectInput(currentCell);
                    }
                    else if (int.Parse(currentCell.Text) > game.numberOfSquares || int.Parse(currentCell.Text) == 0)
                    {
                        ShowIncorrectInput(currentCell);
                    }
                    else
                    {
                        string[] splitArray = (sender as TextBox).Name.Split('_');
                        game.SetByColumn(int.Parse(currentCell.Text), int.Parse(splitArray[1]), int.Parse(splitArray[2]));
                        CheckHighlighting(game.GetByColumn(int.Parse(splitArray[1]), int.Parse(splitArray[2])));
                        IsPuzzleFinished();
                        
                    }
                }
            }
        }

        private void CheckHighlighting(int index) //Is working but need to add the colour changing part and for column and square
        {
            if (game.RowValid(game.GetRowByIndex(index)))
            {
                Control[] rowArray = new Control[game.gridLength];
                hintOutput.Text = "row valid";
            }
            if (game.ColumnValid(game.GetColumnByIndex(index)))
            {
                hintOutput.Text = "column valid";
            }
            if (game.SquareValid(game.GetSquareFromIndex(index)))
            {
                hintOutput.Text = "square valid";
            }
        }

        private void IsPuzzleFinished()
        {
            if (game.IsPuzzleValid())
            {
                hintOutput.Text = "Complete...";
                game.StopTimer();

                foreach (Control ctrl in sudokuPanel.Controls)
                {
                    if ((ctrl as TextBox) != null)
                    {
                        (ctrl as TextBox).Enabled = false;
                    }
                }
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

            //txtName.BackColor = Color.Aqua;


            Control hintTextBox = sudokuPanel.Controls.Find("sudoku_" + game.GetColumnByIndex(hintArray[0]) + "_" + game.GetRowByIndex(hintArray[0]), true)[0];
            //Button b = c as Button;

            // c.Text = "@";
            

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

            //;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Controls.Remove(sudokuPanel);
            sudokuPanel.Dispose();
        }
        

    }
}
