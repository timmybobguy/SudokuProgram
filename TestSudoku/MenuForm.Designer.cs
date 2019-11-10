namespace Sudoku
{
    partial class MenuForm
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
            this.refreshButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSave = new System.Windows.Forms.RadioButton();
            this.radioButtonNew = new System.Windows.Forms.RadioButton();
            this.loadButton = new System.Windows.Forms.Button();
            this.buttonStartEditor = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(710, 33);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(75, 23);
            this.refreshButton.TabIndex = 0;
            this.refreshButton.Text = "Refresh list";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSave);
            this.groupBox1.Controls.Add(this.radioButtonNew);
            this.groupBox1.Location = new System.Drawing.Point(12, 338);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Choose load type";
            // 
            // radioButtonSave
            // 
            this.radioButtonSave.AutoSize = true;
            this.radioButtonSave.Location = new System.Drawing.Point(7, 44);
            this.radioButtonSave.Name = "radioButtonSave";
            this.radioButtonSave.Size = new System.Drawing.Size(75, 17);
            this.radioButtonSave.TabIndex = 1;
            this.radioButtonSave.TabStop = true;
            this.radioButtonSave.Text = "Load save";
            this.radioButtonSave.UseVisualStyleBackColor = true;
            // 
            // radioButtonNew
            // 
            this.radioButtonNew.AutoSize = true;
            this.radioButtonNew.Location = new System.Drawing.Point(7, 20);
            this.radioButtonNew.Name = "radioButtonNew";
            this.radioButtonNew.Size = new System.Drawing.Size(101, 17);
            this.radioButtonNew.TabIndex = 0;
            this.radioButtonNew.TabStop = true;
            this.radioButtonNew.Text = "Load new game";
            this.radioButtonNew.UseVisualStyleBackColor = true;
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(234, 358);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 2;
            this.loadButton.Text = "Start game";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // buttonStartEditor
            // 
            this.buttonStartEditor.Location = new System.Drawing.Point(234, 403);
            this.buttonStartEditor.Name = "buttonStartEditor";
            this.buttonStartEditor.Size = new System.Drawing.Size(75, 23);
            this.buttonStartEditor.TabIndex = 3;
            this.buttonStartEditor.Text = "Start editor";
            this.buttonStartEditor.UseVisualStyleBackColor = true;
            this.buttonStartEditor.Click += new System.EventHandler(this.buttonStartEditor_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonStartEditor);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.refreshButton);
            this.Name = "MenuForm";
            this.Text = "MenuForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSave;
        private System.Windows.Forms.RadioButton radioButtonNew;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Button buttonStartEditor;
    }
}