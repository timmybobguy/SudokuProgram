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
            new GameController(new ConsoleView(), new Game(3,3), new Validator(3,3)).Go();
        }
    }
}
