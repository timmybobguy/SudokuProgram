using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    class Model
    {
        public string MakeGrid(int size)
        {
            string line = String.Empty;
            int[] array1 = new int[size * size];
            for (int i = 0; i < array1.Length; i++)
            {
                bool endOfLine = i % size == 0 && i != 0;
                /*if( i%3 == 0)
                {
                    line += "|";
                }
                if (i % ((size * size) / 3) == 0 && i != 0)
                {
                    line += "\n"+DrawLine(size+size/3);
                }*/
                line += endOfLine ? "\n" + array1[i] : array1[i].ToString();
            }
            return line;
        }

        public string DrawLine(int length)
        {
            int i = 0;
            string line = String.Empty;
            do
            {
                line += "-";
                i++;
            } while (i < length);
            return line;
        }
    }
}
