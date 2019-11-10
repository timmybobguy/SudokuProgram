using System;
using System.Collections.Generic;
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
        protected SudokuForm sudokuForm;
        protected EditorForm editorForm;

        public GameController(IView theView, Game theGame, MenuForm theForm, SudokuForm theSudokuForm)
        {
            view = theView;
            game = theGame;
            form = theForm;
            sudokuForm = theSudokuForm;
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
            sudokuForm.Initialise(game);
            sudokuForm.GenerateGrid(game.numbersArray);
            sudokuForm.ShowDialog();
        }

        public void StartEditor(int x, int y)
        {
            game = new Game();
            int[] grid = game.CreateGridBlank(x, y);
            game.Set(grid);
            editorForm.ShowDialog();
        }
    }
}
