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
    public partial class AddInstructor : Form
    {
        public AddInstructor()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void createButton_Click(object sender, EventArgs e)
        {
            // Generate the next InstructorID (sequential) instead of random
            int instructorId = GetNextInstructorId();

            // Retrieve the instructor name from the TextBox (assuming the TextBox is named txtInstructorName)
            string instructorName = txtInstructorName.Text;

            // Insert the new instructor into the Instructors table
            InsertNewInstructor(instructorId, instructorName);

            // Display a success message
            MessageBox.Show("Instructor added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }
        private int GetNextInstructorId()
        {
            string connectionString = Properties.Settings.Default.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ISNULL(MAX(InstructorID), 0) + 1 FROM Instructors;";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    int nextId = Convert.ToInt32(command.ExecuteScalar());
                    return nextId;
                }
            }
        }
        private void InsertNewInstructor(int instructorId, string instructorName)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Instructors (InstructorID, InstructorName) VALUES (@InstructorID, @InstructorName);";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@InstructorID", instructorId);
                    command.Parameters.AddWithValue("@InstructorName", instructorName);
                    command.ExecuteNonQuery();
                }
            }
        }

        private void AddInstructor_Load(object sender, EventArgs e)
        {
            // Additional loading logic if needed
        }
    }
}
