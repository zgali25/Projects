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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // Generate a random StudentId in the range of 1000 to 9999
            Random random = new Random();
            int studentId = random.Next(1000, 10000);

            // Retrieve the student name from the TextBox (assuming the TextBox is named txtStudentName)
            string studentName = txtStudentName.Text;

            // Insert the new student into the Students table
            InsertNewStudent(studentId, studentName);

            // Close the AddStudent form after creating the student
            this.Close();
        }

        private void InsertNewStudent(int studentId, string studentName)
        {
            // Use the existing connection string to connect to the database
            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SQL command to insert the new student into the Students table
                string query = "INSERT INTO Students (StudentID, StudentName) VALUES (@StudentID, @StudentName);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Set the parameter values for the StudentID and StudentName
                    command.Parameters.AddWithValue("@StudentID", studentId);
                    command.Parameters.AddWithValue("@StudentName", studentName);

                    // Execute the SQL command to insert the new student
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }
    }
}
