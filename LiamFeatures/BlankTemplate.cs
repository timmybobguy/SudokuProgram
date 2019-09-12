using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlankTemplate
{
    class BlankTemplate
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("Enter amount of squares in Sudoku: ");
            CreateGridBlank();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Terminating the application...");
        }
		
		private static void CreateGridBlank()
		{			
            int a;
			a = int.Parse(Console.ReadLine());
            a = a * a;
            int[] blankGrid = new int[a];
            Console.Write(blankGrid.Length);
            Console.WriteLine("\n");
            Console.Write("Elements in array are: ");
            foreach (int i in blankGrid)
            {
                System.Console.Write("{0} ", i);
            }

		}
		
    }
}
