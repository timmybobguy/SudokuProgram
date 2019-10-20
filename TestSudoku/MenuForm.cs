using System;
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
    public partial class MenuForm : Form
    {
        private string[] fileList;
        private ListBox listBox;
 

        public MenuForm()
        {
            InitializeComponent();
            //Only done here for testing
            RefreshFileList();
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
            listBox.Size = new Size(600, 200);
            listBox.Location = new Point(10, 10);

            Controls.Add(listBox);
            //this initially updates the list box
            UpdateListBox();
        }

        public void UpdateListBox()
        {
            listBox.BeginUpdate();
            listBox.Items.Clear();
            for (int x = 0; x < fileList.Length; x++)
            {
                listBox.Items.Add(fileList[x]);
            }
            listBox.EndUpdate();
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            UpdateListBox();
        }
    }
}
