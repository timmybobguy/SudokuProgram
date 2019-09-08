using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class ConsoleView : IView
    {
        public void Start()
        {
            Console.Clear();
        }

        public void Stop()
        {
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        public void Show<T>(T prompt)
        {
            Console.WriteLine(prompt);
        }

        public string MakeSquare(int number)
        {
            string result = number.ToString();
            if (number.ToString().Length == 1)
            {
                result = " " + number + "  ";
            }
            if (number.ToString().Length == 2)
            {
                result = " " + number + " ";
            }
            return result;
        }

        public string MakeLine(int n)
        {
            int i = 0;
            string result = "";
            do
            {
                result += "-";
                i++;
            } while (i <= ((n * n) * 4) + n);
            return result;
        }

    }
}
