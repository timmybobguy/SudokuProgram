﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Sudoku
{
    public partial class Game
    {

        public int highScore;
        public int targetTime;
        public int timeTaken;
        public int baseScore;
        private static Timer aTimer;


        public int GetScore()
        {   
            int TimeScore = baseScore - (timeTaken-targetTime);
            int gridScore = 0;
            for (var i = 0; i < originalNumbersArray.Length; i++)
            {
                if (originalNumbersArray[i] == 0)
                {
                    gridScore++;
                }
            }
            gridScore = originalNumbersArray.Length / gridScore;
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

        public void SetHighScore()
        {
            if (GetScore() > highScore)
            {
                highScore = GetScore();  
            }
        }

    }
}
