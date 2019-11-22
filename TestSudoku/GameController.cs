using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public class GameController
    {
        protected IView view;
        protected Game game;
        protected MenuForm form;
        protected Form sudokuForm;
        protected EditorForm editorForm;

        private string currentFileName;

        public GameController(IView theView, Game theGame, MenuForm theForm)
        {
            view = theView;
            game = theGame;
            form = theForm;
            sudokuForm = new Form();
            editorForm = new EditorForm();
        }

        public void Go()
        {
            form.Initialise(game, this);
            Application.Run(form);
            
            //view.Start();
            ////game.ToCSV();
            //view.Show(game.FromCSV("3X3Blank", false));
            //game.StartTimer();
            //view.Show(game.ToPrettyString());
            //game.ToCSV();
            
            ////form.Show();

            //form.Initialise(game);

            ////form.GenerateGrid(game.numbersArray);

            ////view.Stop();
        }

        public void StartSudoku(string selection, bool options)
        {
            // Make the controller create a new instance of the model each time a game is loaded
            currentFileName = selection;
            game = new Game();
            game.FromCSV(selection, options);
            if (options == false)
            {
                game.timeTaken = 0;
            }
            sudokuForm.Initialise(game, this);
            sudokuForm.GenerateGrid(game.originalNumbersArray, game.lastSaveNumbersArray);
            sudokuForm.ShowDialog();
        }

        public void StartEditor(int x, int y, bool editExisting, string file)
        {
            game = new Game();

            if (editExisting == false)
            {
                int[] grid = game.CreateGridBlank(x, y);
                game.Set(grid);
                editorForm.Initialise(game, this, x, y, true);
                editorForm.GenerateGrid();
                editorForm.ShowDialog();
            }
            else
            {
                game.FromCSV(file, false);
                editorForm.Initialise(game, this, x, y, false);
                editorForm.GenerateGrid();
                editorForm.ShowDialog();
            }
            
        }

        public Control MakeSudokuButton (string name, string value, int row, int column, bool locked)
        {
            TextBox btnNew = new TextBox
            {
                Name = name + column.ToString() + "_" + row.ToString(),
                Height = 50,
                Width = 50,
                Font = new Font("Arial", 20),
                Text = value,
                AutoSize = false,
                Visible = true,
                TextAlign = HorizontalAlignment.Center,
                BorderStyle = BorderStyle.None,
                Location = new Point(50 * column, 50 * row)
            };

            if (locked == true)
            {
                DisabledTextBox btnDisabled = new DisabledTextBox
                {
                    Name = name + column.ToString() + "_" + row.ToString(),
                    Height = 50,
                    Width = 50,
                    Font = new Font("Arial", 20),
                    Text = value,
                    AutoSize = false,
                    Visible = true,
                    TextAlign = HorizontalAlignment.Center,
                    BorderStyle = BorderStyle.None,
                    ReadOnly = false,
                    TabStop = false,
                    BackColor = Color.White,
                    ForeColor = Color.Black,
                    Location = new Point(50 * column, 50 * row)
                };

                return btnDisabled;
            }

            return btnNew;
        }

        public Panel MakeSudokuPanel ()
        {
            Panel sudokuPanel = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(game.gridHeight * 50, game.gridWidth * 50),
                BorderStyle = BorderStyle.Fixed3D
            };

            return sudokuPanel;
        }

        public void SaveAndQuit(string newFileName, bool existingSave)
        {
            if (newFileName != null)
            {
                bool alreadyExists = false;
                for (var i = 0; i < form.fileList.Length; i++)
                {
                    if (newFileName == form.fileList[i])
                    {
                        alreadyExists = true;
                    }
                }
                if (alreadyExists == false && newFileName != "")
                {
                    game.originalNumbersArray = game.numbersArray;
                    game.lastSaveNumbersArray = game.numbersArray;
                    game.ToCSV(newFileName);
                    editorForm.Close();
                    form.UpdateListBox();
                }
                else
                {
                    editorForm.FileNameError();
                }
                
            }
            else if (existingSave == true)
            {
                game.originalNumbersArray = game.numbersArray;
                game.lastSaveNumbersArray = game.numbersArray;
                game.ToCSV(form.listBox.SelectedItem.ToString());
                editorForm.Close();
            }
            else
            {
                game.StopTimer();
                game.ToCSV(currentFileName);
                sudokuForm.Close();
            }
            
        }

        public void RestartGame()
        {
            game.StopTimer();
            game.lastSaveNumbersArray = game.originalNumbersArray;
            game.numbersArray = game.originalNumbersArray;
            //game.Restart();
            game.timeTaken = 0;
            game.ToCSV(currentFileName);

            game = new Game();
            game.FromCSV(currentFileName, false);
            sudokuForm.Initialise(game, this);
            sudokuForm.GenerateGrid(game.originalNumbersArray, game.lastSaveNumbersArray);
        }

    }
}
