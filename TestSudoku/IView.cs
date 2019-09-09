﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    interface IView
    {
        void Start();
        void Stop();
        void Show<T>(T Prompt);
        string MakeSquare(int number);
        string MakeLine(int n);
    }
}