using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dropbox13
{
    public partial class Administrator : Form
    {
        public Administrator()
        {
            InitializeComponent();
        }

        private void addCourseButton_Click(object sender, EventArgs e)
        {
            AddCourseForm addCourseForm = new AddCourseForm();
            addCourseForm.Show();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addStudentButton_Click(object sender, EventArgs e)
        {
            AddStudent addStudentForm = new AddStudent();
            addStudentForm.Show();
        }

        private void setupActiveButton_Click(object sender, EventArgs e)
        {
            ManageCourses manageCoursesForm = new ManageCourses();
            manageCoursesForm.ShowDialog(); // Show the form as a dialog
        }

        private void assignInstructorButton_Click(object sender, EventArgs e)
        {
            ChangeInsturctor Change = new ChangeInsturctor();
            Change.ShowDialog();
        }

        private void AddInstructorButton_Click(object sender, EventArgs e)
        {
            AddInstructor addInstructorForm = new AddInstructor();
            addInstructorForm.Show();
        }
    }
}
