//Ian Rhoades
//CISS 311
//Assignment 13
//Aug 4, 2023
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dropbox13
{
    public partial class AddCourseForm : Form
    {
        public AddCourseForm()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler for the SelectedIndexChanged event of a combo box named "comboBox1."
        }

        private void label1_Click(object sender, EventArgs e)
        {
            // Event handler for the Click event of a label named "label1."
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string courseTitle = courseNameTextBox.Text;

            if (!string.IsNullOrEmpty(courseTitle) && instructorComboBox.SelectedItem is DataRowView selectedInstructor)
            {
                int instructorId = Convert.ToInt32(selectedInstructor["InstructorId"]);

                if (int.TryParse(numberOfSeatsTextBox.Text, out int availableSeats))
                {
                    int courseId = GenerateNewCourseId();
                    bool isActive = activeCheckBox.Checked;

                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        using (SqlCommand comd = new SqlCommand("INSERT INTO Courses (CourseId, CourseTitle, InstructorId, AvailableSeats, IsActive) VALUES (@courseId, @courseTitle, @instructorId, @availableSeats, @isActive)", conn))
                        {
                            comd.Parameters.AddWithValue("@courseId", courseId);
                            comd.Parameters.AddWithValue("@courseTitle", courseTitle);
                            comd.Parameters.AddWithValue("@instructorId", instructorId);
                            comd.Parameters.AddWithValue("@availableSeats", availableSeats);
                            comd.Parameters.AddWithValue("@isActive", isActive);

                            conn.Open();
                            comd.ExecuteNonQuery();

                            MessageBox.Show($"Course saved with CourseId: {courseId}");
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please enter a valid number of available seats.");
                }
            }
            else
            {
                MessageBox.Show("Please enter a course title and select an instructor.");
            }
        }

        // Generate a new unique CourseId
        private int GenerateNewCourseId()
        {
            
            Random random = new Random();
            return random.Next(10000, 99999); // Generates a random number between 10000 and 99999
        }

        private void SaveCourseToDatabase(string courseTitle, int instructorId)
        {
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            // Event handler for the Click event of a button named "closeButton."
            // This code handles the closing of the form.
            this.Close();
        }

        private void AddCourseForm_Load(object sender, EventArgs e)
        {
            // Establishes connection to the SQL server
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                // Queries data from the Instructors table
                using (SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Instructors", conn))
                {
                    // Creates a new DataTable to hold the queried data
                    DataTable instructorsTable = new DataTable();
                    // Fills the instructorsTable with data from the Instructors table
                    adapter.Fill(instructorsTable);
                    // Sets the display member and value member for InstructorComboBox
                    instructorComboBox.DisplayMember = "InstructorName"; // Assuming the column name is "InstructorName"
                    instructorComboBox.ValueMember = "InstructorId";   // Assuming the column name is "InstructorId"
                                                                       // Assigns the DataSource of InstructorComboBox to instructorsTable
                    instructorComboBox.DataSource = instructorsTable;
                }
            }
        }

    }
}
