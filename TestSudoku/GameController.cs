using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class GameController
    {
        protected IView view;
        protected Game game;
        protected MenuForm form;
        protected SudokuForm sudokuForm;

        public GameController(IView theView, Game theGame, MenuForm theForm, SudokuForm theSudokuForm)
        {
            view = theView;
            game = theGame;
            form = theForm;
            sudokuForm = theSudokuForm;
        }

        public void Go()
        {
            form.Initialise(game, sudokuForm);
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
    }
}
