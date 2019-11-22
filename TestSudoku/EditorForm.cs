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
    public partial class EditorForm : System.Windows.Forms.Form
    {
        protected Game game;
        protected GameController controller;
        private Panel sudokuPanel;
        private bool isNewGame;
        private Control beingWiped;

        public void Initialise(Game theGame, GameController theGameController, int x, int y, bool newGame)
        {
            Controls.Clear();
            
            InitializeComponent();
            
            game = theGame;
            isNewGame = newGame;

            if (newGame == true)
            {
                GameSettings blank = new GameSettings
                {
                    SquareWidth = x,
                    SquareHeight = y,
                    Highscore = 0,
                    TargetTime = 0,
                    HintsUsed = 0,
                    TimeSpent = 0,
                    BaseScore = 0
                };
                game.SetSettings(blank);
                saveExisting.Visible = false;
            }
            else
            {
                targetTimeInput.Value = game.targetTime;
                baseScoreInput.Value = game.baseScore;
                saveExisting.Dock = DockStyle.Bottom;
                inputText.Visible = false;
                submitButton.Visible = false;
            }

            controller = theGameController;
            sudokuPanel = controller.MakeSudokuPanel();
            Controls.Add(sudokuPanel);

            Size = new Size(Size.Width, sudokuPanel.Size.Height + 260);
        }

        public void GenerateGrid()
        {
            for (var i = 0; i < game.numbersArray.Length; i++)
            {
                sudokuPanel.Controls.Add(controller.MakeSudokuButton("sudoku_", game.numbersArray[i].ToString(), game.GetRowByIndex(i), game.GetColumnByIndex(i), false));
            }

            foreach (Control ctrl in sudokuPanel.Controls)
            {
                if ((ctrl as TextBox) != null)
                {
                    (ctrl as TextBox).TextChanged += CommonHandler_TextChanged;
                }

                string[] splitArray = (ctrl as TextBox).Name.Split('_');

                int currentIndex = game.GetByColumn(int.Parse(splitArray[1]), int.Parse(splitArray[2]));



                if ((game.GetRowByIndex(currentIndex) + 1) % (game.gridHeight / game.squareHeight) == 0) // it is on a row with a horizonal line, bottom
                {
                    (ctrl as TextBox).Controls.Add(new Label() { Height = 3, Dock = DockStyle.Bottom, BackColor = Color.Black });
                }

                if ((game.GetColumnByIndex(currentIndex) + 1) % (game.gridWidth / game.squareWidth) - 1 == 0 && game.GetColumnByIndex(currentIndex) != 0)
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
                        string[] splitArray = (sender as TextBox).Name.Split('_');
                        game.SetByColumn(int.Parse(currentCell.Text), int.Parse(splitArray[1]), int.Parse(splitArray[2]));
                    }
                }
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (game.IsPuzzleValidForSaving())
            {
                game.targetTime = decimal.ToInt32(targetTimeInput.Value);
                game.baseScore = decimal.ToInt32(baseScoreInput.Value);
                controller.SaveAndQuit(inputText.Text, false);
            }
            
        }

        public void FileNameError()
        {
            inputText.Text = "this name already exists or is blank";
        }

        private void saveExisting_Click(object sender, EventArgs e)
        {
            if (isNewGame == false && game.IsPuzzleValidForSaving())
            {
                controller.SaveAndQuit(null, true);
            }
        }
    }
}
