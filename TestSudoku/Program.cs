using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            new GameController(new ConsoleView(), new Game(1,1), new Validator(1, 1)).Go();
            new GameController(new ConsoleView(), new Game(2,2),new Validator(2,2)).Go();
            new GameController(new ConsoleView(), new Game(3,3), new Validator(3,3)).Go();
            new GameController(new ConsoleView(), new Game(2,3), new Validator(2,3)).Go();
            new GameController(new ConsoleView(), new Game(4,4), new Validator(4,4)).Go();
            new GameController(new ConsoleView(), new Game(6,2), new Validator(6,2)).Go();
        }
    }
}
