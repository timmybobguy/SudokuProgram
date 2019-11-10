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
            game = new Game();
            game.FromCSV(selection, options);
            sudokuForm.Initialise(game, this);
            sudokuForm.GenerateGrid(game.numbersArray);
            sudokuForm.ShowDialog();
        }

        public void StartEditor(int x, int y, bool editExisting, string file)
        {
            game = new Game();

            if (editExisting == false)
            {
                int[] grid = game.CreateGridBlank(x, y);
                game.Set(grid);
                editorForm.ShowDialog();
            }
            else
            {
                game.FromCSV(file, false);
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

            return btnNew;
        }
    }
}
