﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Sudoku
{
    public partial class MenuForm : System.Windows.Forms.Form
    {
        public string[] fileList;
        public ListBox listBox;
        protected Game game;
        protected GameController controller;


        public MenuForm()
        {
            InitializeComponent();
        }

        public void Initialise(Game theGame, GameController theController)
        {
            game = theGame;
            controller = theController;
            //Only done here for testing
            RefreshFileList();
            FilterPaths();
            CreateFileSelection();
        }

        public void RefreshFileList()
        {
            try
            {
                string directory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
                string finalPath = Path.Combine(directory, "..\\..\\..\\Export");
                fileList = Directory.GetFiles(finalPath, "*.csv");
            }
            catch (Exception e)
            {
                Console.WriteLine("The process failed: {0}", e.ToString());
            }
        }

        public void CreateFileSelection()
        {

            //Creating listbox
            listBox = new ListBox();
            listBox.Size = new Size(400, 200);
            listBox.Location = new Point(10, 80);

            Controls.Add(listBox);
            //this initially updates the list box
            UpdateListBox();
        }

        public void UpdateListBox()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            RefreshFileList();
            FilterPaths();
            for (int x = 0; x < fileList.Length; x++)
            {
                listBox.Items.Add(fileList[x]);
            }
            listBox.EndUpdate();
        }

        public string GetSelection()
        {
            if (listBox.SelectedItem == null)
            {
                return "null";
            }
            else
            {
                return listBox.SelectedItem.ToString();
            }
        }

        private void FilterPaths()
        {
            string toRemove = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "..\\..\\..\\Export";
            for (var i = 0; i < fileList.Length; i++)
            {
                fileList[i] = fileList[i].Remove(0, toRemove.Length + 2);
                fileList[i] = fileList[i].Remove(fileList[i].Length - 4);
            }
        }

        public bool? GetOption()
        {
            if (radioButtonNew.Checked == true)
            {
                return false;
            }
            else if (radioButtonSave.Checked == true)
            {
                return true;
            }
            else
            {
                return null; // When no option is selected
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            bool? option = GetOption();
            bool options = false;

            if (option == true)
            {
                options = true;
            }

            if (option == null || GetSelection() == "null")
            {
                //Do error message/thingy

            }
            else
            {
                controller.StartSudoku(GetSelection(), options);
            }
        }

        private void buttonStartEditor_Click(object sender, EventArgs e)
        {
           controller.StartEditor((int)numericUpDown1.Value, (int)numericUpDown2.Value, false, null);   
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GetSelection() != "null")
            {
                controller.StartEditor(0, 0, true, GetSelection());
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (GetSelection() != "null")
            {
                RefreshFileList();

                File.Delete(fileList[listBox.SelectedIndex]);

                UpdateListBox();
            }
        }
    }   
}
