using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplicationDemo
{
    public partial class Form1 : Form
    {
        string ClickedText;

        public Form1()
        {
            InitializeComponent();
            // MakeButtons();
        }

        protected void MakeButtons()
        {
            Button btnNew = new Button();
            btnNew.Name = "btn";
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = "#";
            btnNew.Visible = true;
            btnNew.Location = new Point(10, 10);

            Controls.Add(btnNew);
        }        

        protected void MakeButtons2(string name, string text, int row, int column)
        {
            Button btnNew = new Button();
            btnNew.Name = name + column.ToString() + "_" + row.ToString();
            btnNew.Height = 50;
            btnNew.Width = 50;
            btnNew.Font = new Font("Arial", 20);
            btnNew.Text = text;
            btnNew.Visible = true;
            btnNew.Location = new Point(10 + 50 * row, 10 + 50 * column);

            Controls.Add(btnNew);            
        }

        protected void WhoClicked(object sender, EventArgs e)
        {
            Button btnWho = sender as Button;

            this.Text = btnWho.Name;

            if (btnWho.Name.StartsWith("btn"))
            {
                btnWho.Text = ClickedText;
            }
            else if (btnWho.Name.StartsWith("iptBtn_"))
            {
                this.ClickedText = btnWho.Text;
            }
        }

        protected void SetClicks()
        {
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    /*
                    if (c.Name.StartsWith("btn"))
                    {
                        Button who = c as Button;
                        who.Click += new EventHandler(WhoClicked);
                    } else if (c.Name.StartsWith("iptBtn_"))
                    {
                        this.ClickedText = c.Text;
                    }
                    */
                    Button who = c as Button;
                    who.Click += new EventHandler(WhoClicked);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // MakeButtons();

            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 5; ++j)
                {
                    MakeButtons2("btn_", "#", i, j);
                }
            }

            Control c = Controls.Find("btn_2_3", true)[0];
            Button b = c as Button;

            // c.Text = "@";
            b.Text = "@";            

            // SetClicks();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 6; ++i)
            {
                for (int j = 6; j < 7; ++j)
                {
                    MakeButtons2("iptBtn_", ((char)(35 + i)).ToString(), i, j);
                }
            }

            SetClicks();
        }
    }
}
