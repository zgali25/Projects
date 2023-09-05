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
    public partial class ManageCourses : Form
    {
        public ManageCourses()
        {
            InitializeComponent();
        }

        private void ManageCourses_Load(object sender, EventArgs e)
        {
            LoadCourses();
        }
        private void LoadCourses()
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();

                string query = "SELECT CourseId, CourseTitle, AvailableSeats, IsActive, InstructorId, InstructorName FROM Courses";

                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable coursesTable = new DataTable();
                        adapter.Fill(coursesTable);
                        dataGridViewCourses.DataSource = coursesTable;

                        // Load instructors
                        using (SqlCommand instructorCommand = new SqlCommand("SELECT InstructorId, InstructorName FROM Instructors", conn))
                        {
                            using (SqlDataAdapter instructorAdapter = new SqlDataAdapter(instructorCommand))
                            {
                                DataTable instructorsTable = new DataTable();
                                instructorAdapter.Fill(instructorsTable);

                                // Define DataGridViewComboBoxColumn for "InstructorName"
                                DataGridViewComboBoxColumn instructorColumn = new DataGridViewComboBoxColumn();
                                instructorColumn.HeaderText = "Instructor";
                                instructorColumn.DataPropertyName = "InstructorId"; // Bind to the InstructorId
                                instructorColumn.DisplayMember = "InstructorName"; // Display InstructorName
                                instructorColumn.ValueMember = "InstructorId"; // Use InstructorId as the underlying value
                                instructorColumn.DataSource = instructorsTable;

                                // Add the DataGridViewComboBoxColumn to the DataGridView
                                dataGridViewCourses.Columns.Add(instructorColumn);
                            }
                        }
                    }
                }
            }
        }



        private void dataGridViewCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void UpdateCourseInfo(int courseId, bool isActive, int availableSeats, int instructorId)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE Courses SET IsActive = @IsActive, AvailableSeats = @AvailableSeats, InstructorId = @InstructorId WHERE CourseId = @CourseId";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                {
                    updateCommand.Parameters.AddWithValue("@IsActive", isActive);
                    updateCommand.Parameters.AddWithValue("@AvailableSeats", availableSeats);
                    updateCommand.Parameters.AddWithValue("@InstructorId", instructorId); // Add parameter for InstructorId
                    updateCommand.Parameters.AddWithValue("@CourseId", courseId);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }
        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridViewCourses.Rows)
                {
                    int courseId = Convert.ToInt32(row.Cells["CourseId"].Value);
                    bool isActive = Convert.ToBoolean(row.Cells["IsActive"].Value);
                    int availableSeats = Convert.ToInt32(row.Cells["AvailableSeats"].Value);
                    int instructorId = Convert.ToInt32(row.Cells["InstructorId"].Value); // Get the selected instructor ID

                    // Update the IsActive, AvailableSeats, and InstructorId columns in the database
                    UpdateCourseInfo(courseId, isActive, availableSeats, instructorId);
                }

                MessageBox.Show("Changes saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private void dataGridViewCourses_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridViewCourses.Rows[e.RowIndex];
                int columnIndex = e.ColumnIndex;

                if (columnIndex == 3) // Assuming the instructor column is the fourth column (index 3)
                {
                    int courseId = Convert.ToInt32(row.Cells[0].Value); // Assuming CourseId is in the first column

                    if (int.TryParse(row.Cells[columnIndex].Value.ToString(), out int newInstructorId))
                    {
                        // Update InstructorId in the database
                        UpdateInstructorId(courseId, newInstructorId);
                    }
                    else
                    {
                        MessageBox.Show("Invalid Instructor ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void UpdateInstructorId(int courseId, int newInstructorId)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();

                string updateQuery = "UPDATE Courses SET InstructorId = @InstructorId WHERE CourseId = @CourseId";
                using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                {
                    updateCommand.Parameters.AddWithValue("@InstructorId", newInstructorId);
                    updateCommand.Parameters.AddWithValue("@CourseId", courseId);
                    updateCommand.ExecuteNonQuery();
                }
            }
        }


    }
}
    

