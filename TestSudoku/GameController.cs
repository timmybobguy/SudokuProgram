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

        public GameController(IView theView, Game theGame)
        {
            view = theView;
            game = theGame;
        }

        public void Go()
        {
            view.Start();
            //game.ToCSV();
            game.FromCSV("sudokuGame1", false);
            game.StartTimer();
            view.Show(game.ToPrettyString());
            view.Stop();
        }
    }
}
