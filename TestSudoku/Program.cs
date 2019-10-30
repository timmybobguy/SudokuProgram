using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new GameController(new ConsoleView(), new Game(), new MenuForm(), new SudokuForm()).Go();
            //Application.Run(form);

            //Application.Run(new MenuForm());
        }
    }
}
