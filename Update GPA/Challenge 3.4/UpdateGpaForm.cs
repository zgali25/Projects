using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Challenge_3._4
{
    public partial class UpdateGpaForm : Form
    {
        //GPA form
        public UpdateGpaForm()
        {
            InitializeComponent();
        }

        //print to read only text box
        private void UpdateGpaForm_Load(object sender, EventArgs e)
        {
            idTextBox.Text = student.StudentId;
            nameTextBox.Text = student.StudentName;
            ActiveControl = gradeTextBox;
        }
        //student object
        private Student student;

        //student constructor
        public UpdateGpaForm(Student student)
        {
            InitializeComponent();
            this.student = student;
        }

        //update student gpa button
        private void button1_Click(object sender, EventArgs e)
        {
            if (char.TryParse(gradeTextBox.Text, out char grade) && double.TryParse(hoursTextBox.Text, out double hours))
            {
                student.UpdateGPA(grade, hours);
                Close();
            }
            else
            {
                MessageBox.Show("Invalid grade or credit hours.");
            }
        }
        //clear button
        private void button2_Click(object sender, EventArgs e)
        {
            gradeTextBox.Clear();
            hoursTextBox.Clear();
            gradeTextBox.Clear();
        }
        //close button
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
