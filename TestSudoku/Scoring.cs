using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sudoku
{
    partial class Game
    {

        public int highScore;
        public int targetTime;
        private int timeTaken = 0;
        private int baseScore = 100;
        private static Timer aTimer;


        public int GetScore()
        {   
            int TimeScore = baseScore - (timeTaken-targetTime);

            int gridScore = 0;

            for (var i = 0; i < originalNumbersArray.Length; i++)
            {
                if (i == 0)
                {
                    gridScore++;
                }
            }

            gridScore = gridScore / originalNumbersArray.Length;

            return (TimeScore * gridScore) - (hintsUsed * 10);
        }

        

        public void StartTimer()
        {
            // Create a timer with a one second interval.
            aTimer = new Timer(1000);
            // Hook up the Elapsed event for the timer. 
            aTimer.Elapsed += OnTimedEvent;
            aTimer.AutoReset = true;
            aTimer.Enabled = true;
        }

        public void StopTimer()
        {
            aTimer.Stop();
            aTimer.Dispose();
        }


        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            timeTaken++;
        }

        public int GetHighScores()
        {
            int result =0;
            int HighScore = 0;
            int Score = 300;
            Console.WriteLine("HighScore: " + HighScore);

            if (Score > HighScore)
            {
                HighScore = Score;
                Console.WriteLine("New HighScore: " + HighScore);
            }
            else
            {
                Console.WriteLine("You Did not beat the HighScore");
                Console.WriteLine("Current HighScore: " + HighScore);
            }
            Console.ReadKey();

            return result;
        }

    }
}
