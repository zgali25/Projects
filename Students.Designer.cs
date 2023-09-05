namespace dropbox13
{
    partial class Students
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
            this.backButton = new System.Windows.Forms.Button();
            this.RegisterButton = new System.Windows.Forms.Button();
            this.ViewRegisteredButton = new System.Windows.Forms.Button();
            this.ViewGradeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(531, 362);
            this.backButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(100, 28);
            this.backButton.TabIndex = 2;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // RegisterButton
            // 
            this.RegisterButton.Location = new System.Drawing.Point(415, 178);
            this.RegisterButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.RegisterButton.Name = "RegisterButton";
            this.RegisterButton.Size = new System.Drawing.Size(216, 28);
            this.RegisterButton.TabIndex = 3;
            this.RegisterButton.Text = "Register";
            this.RegisterButton.UseVisualStyleBackColor = true;
            this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
            // 
            // ViewRegisteredButton
            // 
            this.ViewRegisteredButton.Location = new System.Drawing.Point(415, 254);
            this.ViewRegisteredButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.ViewRegisteredButton.Name = "ViewRegisteredButton";
            this.ViewRegisteredButton.Size = new System.Drawing.Size(216, 28);
            this.ViewRegisteredButton.TabIndex = 4;
            this.ViewRegisteredButton.Text = "View Registered";
            this.ViewRegisteredButton.UseVisualStyleBackColor = true;
            this.ViewRegisteredButton.Click += new System.EventHandler(this.ViewRegisteredButton_Click);
            // 
            // ViewGradeButton
            // 
            this.ViewGradeButton.Location = new System.Drawing.Point(415, 310);
            this.ViewGradeButton.Name = "ViewGradeButton";
            this.ViewGradeButton.Size = new System.Drawing.Size(216, 23);
            this.ViewGradeButton.TabIndex = 5;
            this.ViewGradeButton.Text = "View Grade";
            this.ViewGradeButton.UseVisualStyleBackColor = true;
            this.ViewGradeButton.Click += new System.EventHandler(this.ViewGradeButton_Click);
            // 
            // Students
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.ViewGradeButton);
            this.Controls.Add(this.ViewRegisteredButton);
            this.Controls.Add(this.RegisterButton);
            this.Controls.Add(this.backButton);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Students";
            this.Text = "Students";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.Button RegisterButton;
        private System.Windows.Forms.Button ViewRegisteredButton;
        private System.Windows.Forms.Button ViewGradeButton;
    }
}