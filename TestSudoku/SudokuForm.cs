using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sudoku
{
    public partial class SudokuForm : Form
    {
        protected Game game;
        private int lastHintIndex;

        public SudokuForm()
        {
            InitializeComponent();
        }

        public void Initialise(Game theGame)
        {
            game = theGame;
        }

        public void MakeSudokuButton(string name, string value, int row, int column, bool locked)
        {
            TextBox btnNew = new TextBox();
            btnNew.Name = name + column.ToString() + "_" + row.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = value;
            btnNew.Visible = true;
            if (locked == true)
            {
               btnNew.ReadOnly = true;
            }
            btnNew.Location = new Point(10 + 50 * row, 10 + 50 * column);

            Controls.Add(btnNew);
        }

        public void GenerateGrid(int[] numbersArray)
        {
            for (var i = 0; i < numbersArray.Length; i++)
            {
                if (numbersArray[i] == 0)
                {
                    MakeSudokuButton("sudoku_", "", game.GetRowByIndex(i), game.GetColumnByIndex(i), false);
                }
                else
                {
                    MakeSudokuButton("sudoku_", numbersArray[i].ToString(), game.GetRowByIndex(i), game.GetColumnByIndex(i), true);
                }
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Resetting last hint
            int? x = lastHintIndex;
            if (x.HasValue)
            {
                Control lastHint = Controls.Find("sudoku_" + game.GetColumnByIndex(lastHintIndex) + "_" + game.GetRowByIndex(lastHintIndex), true)[0];
                lastHint.BackColor = Color.White;
            }
           

            int[] hintArray = game.GetHint();

            //txtName.BackColor = Color.Aqua;


            Control hintTextBox = Controls.Find("sudoku_" + game.GetColumnByIndex(hintArray[0]) + "_" + game.GetRowByIndex(hintArray[0]), true)[0];
            //Button b = c as Button;

            // c.Text = "@";
            hintTextBox.BackColor = Color.Aqua;

            string output = "";
            for (var i = 1; i < hintArray.Length; i++)
            {
                output += "- " + hintArray[i];
            }

            hintOutput.Text = output;
            lastHintIndex = hintArray[0];

            

            //;
        }

    }
}
