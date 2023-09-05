namespace dropbox13
{
    partial class Administrator
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
            this.addStudentButton = new System.Windows.Forms.Button();
            this.assignInstructorButton = new System.Windows.Forms.Button();
            this.addCourseButton = new System.Windows.Forms.Button();
            this.setupActiveButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.AddInstructorButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // addStudentButton
            // 
            this.addStudentButton.Location = new System.Drawing.Point(293, 126);
            this.addStudentButton.Name = "addStudentButton";
            this.addStudentButton.Size = new System.Drawing.Size(230, 23);
            this.addStudentButton.TabIndex = 4;
            this.addStudentButton.Text = "Add Student";
            this.addStudentButton.UseVisualStyleBackColor = true;
            this.addStudentButton.Click += new System.EventHandler(this.addStudentButton_Click);
            // 
            // assignInstructorButton
            // 
            this.assignInstructorButton.Location = new System.Drawing.Point(293, 175);
            this.assignInstructorButton.Name = "assignInstructorButton";
            this.assignInstructorButton.Size = new System.Drawing.Size(230, 23);
            this.assignInstructorButton.TabIndex = 5;
            this.assignInstructorButton.Text = "Change Instructor For Course";
            this.assignInstructorButton.UseVisualStyleBackColor = true;
            this.assignInstructorButton.Click += new System.EventHandler(this.assignInstructorButton_Click);
            // 
            // addCourseButton
            // 
            this.addCourseButton.Location = new System.Drawing.Point(293, 221);
            this.addCourseButton.Name = "addCourseButton";
            this.addCourseButton.Size = new System.Drawing.Size(230, 23);
            this.addCourseButton.TabIndex = 6;
            this.addCourseButton.Text = "Add Course";
            this.addCourseButton.UseVisualStyleBackColor = true;
            this.addCourseButton.Click += new System.EventHandler(this.addCourseButton_Click);
            // 
            // setupActiveButton
            // 
            this.setupActiveButton.Location = new System.Drawing.Point(293, 266);
            this.setupActiveButton.Name = "setupActiveButton";
            this.setupActiveButton.Size = new System.Drawing.Size(230, 23);
            this.setupActiveButton.TabIndex = 7;
            this.setupActiveButton.Text = "Manage Courses";
            this.setupActiveButton.UseVisualStyleBackColor = true;
            this.setupActiveButton.Click += new System.EventHandler(this.setupActiveButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(448, 310);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 8;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(335, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 9;
            this.textBox1.Text = "Administrators";
            // 
            // AddInstructorButton
            // 
            this.AddInstructorButton.Location = new System.Drawing.Point(293, 83);
            this.AddInstructorButton.Name = "AddInstructorButton";
            this.AddInstructorButton.Size = new System.Drawing.Size(230, 23);
            this.AddInstructorButton.TabIndex = 10;
            this.AddInstructorButton.Text = "Add Instructor";
            this.AddInstructorButton.UseVisualStyleBackColor = true;
            this.AddInstructorButton.Click += new System.EventHandler(this.AddInstructorButton_Click);
            // 
            // Administrator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.AddInstructorButton);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.setupActiveButton);
            this.Controls.Add(this.addCourseButton);
            this.Controls.Add(this.assignInstructorButton);
            this.Controls.Add(this.addStudentButton);
            this.Name = "Administrator";
            this.Text = "Administrator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addStudentButton;
        private System.Windows.Forms.Button assignInstructorButton;
        private System.Windows.Forms.Button addCourseButton;
        private System.Windows.Forms.Button setupActiveButton;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button AddInstructorButton;
    }
}