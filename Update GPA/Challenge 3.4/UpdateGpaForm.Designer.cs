namespace Challenge_3._4
{
    partial class UpdateGpaForm
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
            idTextBox = new TextBox();
            nameTextBox = new TextBox();
            gradeTextBox = new TextBox();
            hoursTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            SuspendLayout();
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(233, 64);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(157, 27);
            idTextBox.TabIndex = 0;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(233, 131);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.ReadOnly = true;
            nameTextBox.Size = new Size(206, 27);
            nameTextBox.TabIndex = 1;
            // 
            // gradeTextBox
            // 
            gradeTextBox.Location = new Point(233, 189);
            gradeTextBox.Name = "gradeTextBox";
            gradeTextBox.Size = new Size(157, 27);
            gradeTextBox.TabIndex = 2;
            // 
            // hoursTextBox
            // 
            hoursTextBox.Location = new Point(233, 257);
            hoursTextBox.Name = "hoursTextBox";
            hoursTextBox.Size = new Size(157, 27);
            hoursTextBox.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(36, 22);
            label1.Name = "label1";
            label1.Size = new Size(128, 20);
            label1.TabIndex = 4;
            label1.Text = "Enter Course Data";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(123, 71);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 5;
            label2.Text = "Student ID:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 138);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 6;
            label3.Text = "Student Name";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(123, 196);
            label4.Name = "label4";
            label4.Size = new Size(98, 20);
            label4.TabIndex = 7;
            label4.Text = "Course Grade";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(123, 264);
            label5.Name = "label5";
            label5.Size = new Size(97, 20);
            label5.TabIndex = 8;
            label5.Text = "Course Hours";
            // 
            // button1
            // 
            button1.Location = new Point(36, 371);
            button1.Name = "button1";
            button1.Size = new Size(94, 29);
            button1.TabIndex = 9;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(332, 371);
            button2.Name = "button2";
            button2.Size = new Size(94, 29);
            button2.TabIndex = 10;
            button2.Text = "Clear";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(606, 371);
            button3.Name = "button3";
            button3.Size = new Size(94, 29);
            button3.TabIndex = 11;
            button3.Text = "Close";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // UpdateGpaForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(hoursTextBox);
            Controls.Add(gradeTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Name = "UpdateGpaForm";
            Text = "UpdateGpaForm";
            Load += UpdateGpaForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox idTextBox;
        private TextBox nameTextBox;
        private TextBox gradeTextBox;
        private TextBox hoursTextBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button button1;
        private Button button2;
        private Button button3;
    }
}