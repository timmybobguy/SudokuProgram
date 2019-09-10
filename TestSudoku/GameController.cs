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
        protected Validator validator;

        public GameController(IView theView, Game theGame, Validator theValidator)
        {
            view = theView;
            game = theGame;
            validator = theValidator;
        }

        public void Go()
        {
            view.Start();
            game.ToCSV();
            game.FromCSV("sudokuGame1");
            view.Show(game.ToPrettyString());
            view.Show(validator.IsPuzzleValid());
            view.Stop();
        }
    }
}
