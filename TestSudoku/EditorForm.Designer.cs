namespace Sudoku
{
    partial class EditorForm
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
            this.submitButton = new System.Windows.Forms.Button();
            this.inputText = new System.Windows.Forms.TextBox();
            this.saveExisting = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetTime = new System.Windows.Forms.NumericUpDown();
            this.baseScore = new System.Windows.Forms.NumericUpDown();
            this.newGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.targetTime)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseScore)).BeginInit();
            this.newGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(91, 142);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(75, 23);
            this.submitButton.TabIndex = 0;
            this.submitButton.Text = "Save as";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // inputText
            // 
            this.inputText.Location = new System.Drawing.Point(78, 116);
            this.inputText.Name = "inputText";
            this.inputText.Size = new System.Drawing.Size(100, 20);
            this.inputText.TabIndex = 1;
            // 
            // saveExisting
            // 
            this.saveExisting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.saveExisting.Location = new System.Drawing.Point(176, 12);
            this.saveExisting.Name = "saveExisting";
            this.saveExisting.Size = new System.Drawing.Size(118, 23);
            this.saveExisting.TabIndex = 2;
            this.saveExisting.Text = "Save changes";
            this.saveExisting.UseVisualStyleBackColor = true;
            this.saveExisting.Click += new System.EventHandler(this.saveExisting_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Target time:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Base score:";
            // 
            // targetTime
            // 
            this.targetTime.Location = new System.Drawing.Point(92, 25);
            this.targetTime.Name = "targetTime";
            this.targetTime.Size = new System.Drawing.Size(120, 20);
            this.targetTime.TabIndex = 5;
            // 
            // baseScore
            // 
            this.baseScore.Location = new System.Drawing.Point(92, 57);
            this.baseScore.Name = "baseScore";
            this.baseScore.Size = new System.Drawing.Size(120, 20);
            this.baseScore.TabIndex = 6;
            // 
            // newGroupBox
            // 
            this.newGroupBox.Controls.Add(this.submitButton);
            this.newGroupBox.Controls.Add(this.baseScore);
            this.newGroupBox.Controls.Add(this.inputText);
            this.newGroupBox.Controls.Add(this.targetTime);
            this.newGroupBox.Controls.Add(this.label1);
            this.newGroupBox.Controls.Add(this.label2);
            this.newGroupBox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.newGroupBox.Location = new System.Drawing.Point(0, 137);
            this.newGroupBox.Name = "newGroupBox";
            this.newGroupBox.Size = new System.Drawing.Size(306, 180);
            this.newGroupBox.TabIndex = 7;
            this.newGroupBox.TabStop = false;
            // 
            // EditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(306, 317);
            this.Controls.Add(this.newGroupBox);
            this.Controls.Add(this.saveExisting);
            this.Name = "EditorForm";
            this.Text = "EditorForm";
            ((System.ComponentModel.ISupportInitialize)(this.targetTime)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baseScore)).EndInit();
            this.newGroupBox.ResumeLayout(false);
            this.newGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button submitButton;
        private System.Windows.Forms.TextBox inputText;
        private System.Windows.Forms.Button saveExisting;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown targetTime;
        private System.Windows.Forms.NumericUpDown baseScore;
        private System.Windows.Forms.GroupBox newGroupBox;
    }
}