﻿namespace Challenge_3._4
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            studentListBox = new ListBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // studentListBox
            // 
            studentListBox.FormattingEnabled = true;
            studentListBox.ItemHeight = 20;
            studentListBox.Location = new Point(203, 146);
            studentListBox.Name = "studentListBox";
            studentListBox.Size = new Size(315, 104);
            studentListBox.TabIndex = 0;
            // 
            // button1
            // 
            button1.Location = new Point(87, 347);
            button1.Name = "button1";
            button1.Size = new Size(184, 58);
            button1.TabIndex = 1;
            button1.Text = "Update GPA";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(532, 351);
            button2.Name = "button2";
            button2.Size = new Size(220, 54);
            button2.TabIndex = 2;
            button2.Text = "Save && Exit";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(studentListBox);
            Name = "Form1";
            Text = "Main Form";
            Activated += Form1_Activated;
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox studentListBox;
        private Button button1;
        private Button button2;
    }
}