﻿namespace dropbox13
{
    partial class ChangeInsturctor
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.instructorComboBox = new System.Windows.Forms.ComboBox();
            this.findButton = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.currentInstructor = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.courseTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.courseIdTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.instructorComboBox);
            this.groupBox1.Controls.Add(this.findButton);
            this.groupBox1.Controls.Add(this.updateButton);
            this.groupBox1.Controls.Add(this.button3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.currentInstructor);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.courseTitle);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.courseIdTextBox);
            this.groupBox1.Location = new System.Drawing.Point(157, 66);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(487, 319);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Change Instructor";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // instructorComboBox
            // 
            this.instructorComboBox.FormattingEnabled = true;
            this.instructorComboBox.Location = new System.Drawing.Point(170, 183);
            this.instructorComboBox.Margin = new System.Windows.Forms.Padding(2);
            this.instructorComboBox.Name = "instructorComboBox";
            this.instructorComboBox.Size = new System.Drawing.Size(174, 21);
            this.instructorComboBox.TabIndex = 7;
            // 
            // findButton
            // 
            this.findButton.Location = new System.Drawing.Point(348, 81);
            this.findButton.Margin = new System.Windows.Forms.Padding(2);
            this.findButton.Name = "findButton";
            this.findButton.Size = new System.Drawing.Size(56, 20);
            this.findButton.TabIndex = 1;
            this.findButton.Text = "&Find";
            this.findButton.UseVisualStyleBackColor = true;
            this.findButton.Click += new System.EventHandler(this.findButton_Click_1);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(170, 219);
            this.updateButton.Margin = new System.Windows.Forms.Padding(2);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(56, 20);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "&Save";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(288, 219);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(56, 19);
            this.button3.TabIndex = 3;
            this.button3.Text = "Cl&ose";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(57, 186);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Select New Instructor";
            // 
            // currentInstructor
            // 
            this.currentInstructor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.currentInstructor.Location = new System.Drawing.Point(170, 146);
            this.currentInstructor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.currentInstructor.Name = "currentInstructor";
            this.currentInstructor.Size = new System.Drawing.Size(174, 20);
            this.currentInstructor.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(78, 153);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Current Instructor";
            // 
            // courseTitle
            // 
            this.courseTitle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.courseTitle.Location = new System.Drawing.Point(170, 112);
            this.courseTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.courseTitle.Name = "courseTitle";
            this.courseTitle.Size = new System.Drawing.Size(174, 20);
            this.courseTitle.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(103, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Course Title";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(112, 84);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Course ID";
            // 
            // courseIdTextBox
            // 
            this.courseIdTextBox.Location = new System.Drawing.Point(170, 81);
            this.courseIdTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.courseIdTextBox.Name = "courseIdTextBox";
            this.courseIdTextBox.Size = new System.Drawing.Size(174, 20);
            this.courseIdTextBox.TabIndex = 0;
            // 
            // ChangeInsturctor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangeInsturctor";
            this.Text = "ChangeInstructors";
            this.Load += new System.EventHandler(this.ChangeInsturctor_Load_1);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox instructorComboBox;
        private System.Windows.Forms.Button findButton;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label currentInstructor;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label courseTitle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox courseIdTextBox;
    }
}