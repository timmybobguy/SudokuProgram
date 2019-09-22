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
        private static SudokuForm form;

        static void Main(string[] args)
        {
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            form = new SudokuForm();

            new GameController(new ConsoleView(), new Game(), form).Go();
            Application.Run(form);
        }
    }
}
