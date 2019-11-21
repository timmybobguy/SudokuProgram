namespace Sudoku
{
    partial class Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.hintOutput = new System.Windows.Forms.TextBox();
            this.timerLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.restartButton = new System.Windows.Forms.Button();
            this.numWrong = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(701, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Get hint";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // hintOutput
            // 
            this.hintOutput.Location = new System.Drawing.Point(688, 41);
            this.hintOutput.Name = "hintOutput";
            this.hintOutput.Size = new System.Drawing.Size(100, 20);
            this.hintOutput.TabIndex = 1;
            // 
            // timerLabel
            // 
            this.timerLabel.AutoSize = true;
            this.timerLabel.Location = new System.Drawing.Point(726, 128);
            this.timerLabel.Name = "timerLabel";
            this.timerLabel.Size = new System.Drawing.Size(29, 13);
            this.timerLabel.TabIndex = 3;
            this.timerLabel.Text = "timer";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(701, 191);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 41);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save and quit";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // restartButton
            // 
            this.restartButton.Location = new System.Drawing.Point(701, 258);
            this.restartButton.Name = "restartButton";
            this.restartButton.Size = new System.Drawing.Size(75, 23);
            this.restartButton.TabIndex = 5;
            this.restartButton.Text = "Restart";
            this.restartButton.UseVisualStyleBackColor = true;
            this.restartButton.Click += new System.EventHandler(this.restartButton_Click);
            // 
            // numWrong
            // 
            this.numWrong.AutoSize = true;
            this.numWrong.Location = new System.Drawing.Point(708, 64);
            this.numWrong.Name = "numWrong";
            this.numWrong.Size = new System.Drawing.Size(59, 13);
            this.numWrong.TabIndex = 6;
            this.numWrong.Text = "numWrong";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 777);
            this.Controls.Add(this.numWrong);
            this.Controls.Add(this.restartButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.timerLabel);
            this.Controls.Add(this.hintOutput);
            this.Controls.Add(this.button1);
            this.Name = "Form";
            this.Text = "SudokuForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox hintOutput;
        private System.Windows.Forms.Label timerLabel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button restartButton;
        private System.Windows.Forms.Label numWrong;
    }
}