using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace TargetTime
{
    class TargetTime
    {
        public static void Main()
        {
            Console.WriteLine("\nPress the Enter key to exit the application...\n");
            Console.WriteLine("Enter target time to complete this sudoku: ");
            SetTargetTimer();
            System.Threading.Thread.Sleep(5000);
            Console.WriteLine("Terminating the application...");
        }

        public static void SetTargetTimer()
        {
            int mt;
            int st;
            Console.WriteLine("Enter Minutes: ");
            mt = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Seconds: ");
            st = int.Parse(Console.ReadLine());
            if (mt >= 2 && st >= 2)
            {
                Console.WriteLine($"the target time to complete this sudoku is: {mt} minutes and {st} seconds");
            } else if (mt >= 2 && st <= 1)
            {
                Console.WriteLine($"the target time to complete this sudoku is: {mt} minutes and {st} second");
            } else if (mt <= 1 && st >= 2)
            {
                Console.WriteLine($"the target time to complete this sudoku is: {mt} minute and {st} seconds");
            } else
            {
                Console.WriteLine($"the target time to complete this sudoku is: {mt} minute and {st} second");
            }

            /*
            if (m > mt %% s > st) 
            {
                Console.WriteLine("Times up")
            } 
            */
        }
    }

}

