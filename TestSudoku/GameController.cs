using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class GameController
    {
        protected IView view;
        protected Game game;
        protected SudokuForm form;

        public GameController(IView theView, Game theGame, SudokuForm theForm)
        {
            view = theView;
            game = theGame;
            form = theForm;
        }

        public void Go()
        {
            view.Start();
            //game.ToCSV();
            view.Show(game.FromCSV("3X3Blank", false));
            game.StartTimer();
            view.Show(game.ToPrettyString());
            game.ToCSV();



            //form.Show();

            form.Initialise(game);

            form.GenerateGrid(game.numbersArray);

            //view.Stop();
        }
    }
}
