
namespace dropbox13
{
    partial class Instructor
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.CourseComboBox = new System.Windows.Forms.ComboBox();
            this.dataGridViewClassData = new System.Windows.Forms.DataGridView();
            this.InstructorIdTextBox = new System.Windows.Forms.TextBox();
            this.SearchButton = new System.Windows.Forms.Button();
            this.InstructorNameTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassData)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(476, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Instructor ID / Instructor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(442, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Instructor:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(428, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Instructor ID:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(689, 211);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CourseComboBox
            // 
            this.CourseComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CourseComboBox.FormattingEnabled = true;
            this.CourseComboBox.Location = new System.Drawing.Point(502, 163);
            this.CourseComboBox.Name = "CourseComboBox";
            this.CourseComboBox.Size = new System.Drawing.Size(262, 21);
            this.CourseComboBox.TabIndex = 7;
            this.CourseComboBox.SelectedIndexChanged += new System.EventHandler(this.CourseComboBox_SelectedIndexChanged);
            // 
            // dataGridViewClassData
            // 
            this.dataGridViewClassData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClassData.Location = new System.Drawing.Point(12, 98);
            this.dataGridViewClassData.Name = "dataGridViewClassData";
            this.dataGridViewClassData.Size = new System.Drawing.Size(404, 210);
            this.dataGridViewClassData.TabIndex = 8;
            this.dataGridViewClassData.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewClassData_CellContentClick);
            this.dataGridViewClassData.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dataGridViewClassData_CellValidating);
            // 
            // InstructorIdTextBox
            // 
            this.InstructorIdTextBox.Location = new System.Drawing.Point(502, 111);
            this.InstructorIdTextBox.Name = "InstructorIdTextBox";
            this.InstructorIdTextBox.Size = new System.Drawing.Size(181, 20);
            this.InstructorIdTextBox.TabIndex = 9;
            this.InstructorIdTextBox.TextChanged += new System.EventHandler(this.InstructorIdTextBox_TextChanged_1);
            // 
            // SearchButton
            // 
            this.SearchButton.Location = new System.Drawing.Point(689, 109);
            this.SearchButton.Name = "SearchButton";
            this.SearchButton.Size = new System.Drawing.Size(75, 23);
            this.SearchButton.TabIndex = 10;
            this.SearchButton.Text = "Search";
            this.SearchButton.UseVisualStyleBackColor = true;
            this.SearchButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // InstructorNameTextBox
            // 
            this.InstructorNameTextBox.Location = new System.Drawing.Point(502, 137);
            this.InstructorNameTextBox.Name = "InstructorNameTextBox";
            this.InstructorNameTextBox.ReadOnly = true;
            this.InstructorNameTextBox.Size = new System.Drawing.Size(262, 20);
            this.InstructorNameTextBox.TabIndex = 11;
            this.InstructorNameTextBox.TextChanged += new System.EventHandler(this.InstructorNameTextBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(453, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Course:";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(502, 211);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 13;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Instructor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.InstructorNameTextBox);
            this.Controls.Add(this.SearchButton);
            this.Controls.Add(this.InstructorIdTextBox);
            this.Controls.Add(this.dataGridViewClassData);
            this.Controls.Add(this.CourseComboBox);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Instructor";
            this.Text = "CourseForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClassData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox CourseComboBox;
        private System.Windows.Forms.DataGridView dataGridViewClassData;
        private System.Windows.Forms.DataGridView dataGridViewGrades;
        private System.Windows.Forms.TextBox InstructorIdTextBox;
        private System.Windows.Forms.Button SearchButton;
        private System.Windows.Forms.TextBox InstructorNameTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button SaveButton;
    }
}