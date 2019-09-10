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
            game.ToCSV();
            game.FromCSV("sudokuGame1");
            view.Show(String.Join(",", game.GetValidValues(2)));
            view.Show(game.ToPrettyString());
            view.Show(game.IsPuzzleValid());
            view.Stop();
        }
    }
}
