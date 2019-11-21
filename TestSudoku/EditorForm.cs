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

        public void Initialise(Game theGame, GameController theGameController, int x, int y, bool newGame)
        {
            Controls.Clear();
            InitializeComponent();
            game = theGame;

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
            }

            controller = theGameController;
            sudokuPanel = controller.MakeSudokuPanel();
            Controls.Add(sudokuPanel);
            
        }

        public void GenerateGrid()
        {
            for (var i = 0; i < game.numbersArray.Length; i++)
            {
                sudokuPanel.Controls.Add(controller.MakeSudokuButton("sudoku_", game.numbersArray[i].ToString(), game.GetRowByIndex(i), game.GetColumnByIndex(i), false));
            }
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            controller.SaveAndQuit(inputText.Text);
        }

        public void ExistingFile()
        {
            inputText.Text = "this file already exists";
        }
    }
}
