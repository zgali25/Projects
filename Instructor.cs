using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace dropbox13
{
    public partial class Instructor : Form
    {
        private Dictionary<int, string> courseIdTitleMap = new Dictionary<int, string>();
        private List<int> courseIds = new List<int>();
        private int selectedInstructorId;

        private int selectedCourseId; // Declare selectedCourseId as a class-level variable
        public Instructor()
        {
            InitializeComponent();

            // Load instructors into the ComboBox during the form initialization.
            LoadInstructors();
            // SaveButton.Click += SaveButton_Click;
            // Wire up the CellValidating event handler
            dataGridViewClassData.CellValidating += dataGridViewClassData_CellValidating;
        }
    

        private void LoadInstructors()
        {
            // Load instructors from the database and populate the ComboBox.

            // Get the connection string from the application settings.
            string connectionString = Properties.Settings.Default.ConnectionString;

            // Create a new SQL connection using the connection string.
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Open the database connection.
                connection.Open();

                // Create a SQL command to select all rows from the "Instructors" table.
                SqlCommand command = new SqlCommand("SELECT * FROM Instructors", connection);

                // Execute the command and read the data using a DataReader.
                SqlDataReader reader = command.ExecuteReader();

                // Loop through the rows in the DataReader and add instructor info to the ComboBox.
                while (reader.Read())
                {
                    int instructorId = Convert.ToInt32(reader["InstructorId"]);

                    // Add the instructor ID to the ComboBox.
                    
                }
            } // The using block will automatically close the connection.
        }

        private void LoadCoursesForInstructor(int instructorId)
        {
            CourseComboBox.Items.Clear();
            selectedInstructorId = instructorId;
            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand($"SELECT CourseId, CourseTitle FROM Courses WHERE InstructorId = {instructorId}", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int courseId = Convert.ToInt32(reader["CourseId"]);
                    string courseTitle = reader["CourseTitle"].ToString();
                    string courseInfo = $"{courseId} - {courseTitle}";
                    CourseComboBox.Items.Add(courseInfo);
                }
            }
        }

        private void InstructorIdTextBox_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(InstructorIdTextBox.Text, out int instructorId))
            {
                // Load courses for the specified instructor ID and update the ComboBox.
                LoadCoursesForInstructor(instructorId);
            }
            else
            {
                CourseComboBox.Items.Clear();
            }
        }

        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CourseComboBox.SelectedItem is string selectedCourseInfo)
            {
                int courseId = int.Parse(selectedCourseInfo.Split('-')[0].Trim());
                selectedCourseId = courseId; // Set the selectedCourseId here
                LoadClassData(courseId);
            }
        }


        private void LoadClassData(int courseId)
        {
            // Fetch data from the database and populate a DataTable
            DataTable classDataTable = new DataTable();
            classDataTable.Columns.Add("StudentId", typeof(int));
            classDataTable.Columns.Add("StudentName", typeof(string));
            classDataTable.Columns.Add("Grade", typeof(string));

            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Select StudentId, StudentName, Grade from StudentCourses for the selected course
                SqlCommand command = new SqlCommand(@"
            SELECT sc.StudentId, s.StudentName, sc.Grade
            FROM StudentCourses sc
            INNER JOIN Students s ON sc.StudentId = s.StudentId
            WHERE sc.CourseId = @CourseId", connection);

                // Provide the value of the @CourseId parameter
                command.Parameters.AddWithValue("@CourseId", courseId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["StudentId"]);
                        string studentName = reader["StudentName"].ToString();
                        string grade = reader["Grade"].ToString();

                        classDataTable.Rows.Add(studentId, studentName, grade);
                    }
                }
            }

            // Clear existing columns before adding new ones
            dataGridViewClassData.Columns.Clear();

            // Add columns to the DataGridView
            DataGridViewTextBoxColumn studentIdColumn = new DataGridViewTextBoxColumn();
            studentIdColumn.DataPropertyName = "StudentId"; // Set the DataPropertyName
            studentIdColumn.HeaderText = "Student ID";
            dataGridViewClassData.Columns.Add(studentIdColumn);

            DataGridViewTextBoxColumn studentNameColumn = new DataGridViewTextBoxColumn();
            studentNameColumn.DataPropertyName = "StudentName"; // Set the DataPropertyName
            studentNameColumn.HeaderText = "Student Name";
            dataGridViewClassData.Columns.Add(studentNameColumn);

            DataGridViewTextBoxColumn gradeColumn = new DataGridViewTextBoxColumn();
            gradeColumn.DataPropertyName = "Grade"; // Set the DataPropertyName
            gradeColumn.HeaderText = "Grade";
            dataGridViewClassData.Columns.Add(gradeColumn);

            // Bind the DataGridView to the DataTable
            dataGridViewClassData.DataSource = classDataTable;
        }



        private DataTable FetchStudentCourseData(int courseId)
        {
            DataTable classDataTable = new DataTable();
            classDataTable.Columns.Add("StudentId", typeof(int));
            classDataTable.Columns.Add("StudentName", typeof(string));
            classDataTable.Columns.Add("Grade", typeof(string));

            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Select StudentId, StudentName, Grade from StudentCourses for the selected course
                SqlCommand command = new SqlCommand(@"
            SELECT sc.StudentId, s.StudentName, sc.Grade
            FROM StudentCourses sc
            INNER JOIN Students s ON sc.StudentId = s.StudentId
            WHERE sc.CourseId = @CourseId", connection);

                // Provide the value of the @CourseId parameter
                command.Parameters.AddWithValue("@CourseId", courseId);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int studentId = Convert.ToInt32(reader["StudentId"]);
                        string studentName = reader["StudentName"].ToString();
                        string grade = reader["Grade"].ToString();

                        classDataTable.Rows.Add(studentId, studentName, grade);
                    }
                }
            }

            return classDataTable;
        }



        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the DataTable bound to the DataGridView
                DataTable classDataTable = (DataTable)dataGridViewClassData.DataSource;

                using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    connection.Open();

                    // Loop through the rows in the DataTable and update the database
                    foreach (DataRow row in classDataTable.Rows)
                    {
                        int studentId = Convert.ToInt32(row["StudentId"]);
                        string grade = row["Grade"].ToString();

                        UpdateStudentCourseGrade(connection, studentId, selectedCourseId, grade);

                        // Update the DataTable with the new grade value
                        row["Grade"] = grade;
                    }

                    MessageBox.Show("Changes were saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStudentCourseGrade(SqlConnection connection, int studentId, int courseId, string grade)
        {
            // Update the Grade column in StudentCourses table for the student and course
            SqlCommand updateCommand = new SqlCommand(
                "UPDATE StudentCourses SET Grade = @Grade WHERE StudentId = @StudentId AND CourseId = @CourseId", connection);
            updateCommand.Parameters.AddWithValue("@StudentId", studentId);
            updateCommand.Parameters.AddWithValue("@CourseId", courseId);
            updateCommand.Parameters.AddWithValue("@Grade", grade);
            updateCommand.ExecuteNonQuery();
        }



        private void UpdateStudentCourseGrade(int studentId, int courseId, string grade)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Update the Grade column in StudentCourses table for the student and course
                SqlCommand updateCommand = new SqlCommand(
                    "UPDATE StudentCourses SET Grade = @Grade WHERE StudentId = @StudentId AND CourseId = @CourseId", connection);
                updateCommand.Parameters.AddWithValue("@StudentId", studentId);
                updateCommand.Parameters.AddWithValue("@CourseId", courseId);
                updateCommand.Parameters.AddWithValue("@Grade", grade);
                updateCommand.ExecuteNonQuery();
            }
        }

        private void CourseListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Event handler for the SelectedIndexChanged event of the "CourseListBox".
        }
 
        private void button1_Click(object sender, EventArgs e)
        {
            // Event handler for the Click event of the button "button1".
            this.Close();
        }

        private void dataGridViewClassData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
       
        private void LoadStudentGrades(int studentId)
        {
            dataGridViewGrades.DataSource = null;

            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Fetch the grade details for the student
                SqlCommand selectCommand = new SqlCommand($"SELECT GradeDetails FROM Students WHERE StudentId = {studentId}", connection);
                string gradeDetailsJson = selectCommand.ExecuteScalar() as string;

                // Parse the JSON grade details into a dictionary
                Dictionary<int, string> gradeDetails = JsonConvert.DeserializeObject<Dictionary<int, string>>(gradeDetailsJson);

                // Create a DataTable to hold the grade information
                DataTable gradeDataTable = new DataTable();
                gradeDataTable.Columns.Add("CourseId", typeof(int));
                gradeDataTable.Columns.Add("CourseTitle", typeof(string));
                gradeDataTable.Columns.Add("Grade", typeof(string));

                // Fetch course information for each course in the grade details
                foreach (var courseEntry in gradeDetails)
                {
                    int courseId = courseEntry.Key;
                    string grade = courseEntry.Value;

                    // Fetch course information from the Courses table based on the courseId
                    SqlCommand courseCommand = new SqlCommand($"SELECT CourseTitle FROM Courses WHERE CourseId = {courseId}", connection);
                    string courseTitle = courseCommand.ExecuteScalar() as string;

                    // Add the grade information to the DataTable
                    gradeDataTable.Rows.Add(courseId, courseTitle, grade);
                }

                // Set the DataTable as the data source for the DataGridView
                dataGridViewGrades.DataSource = gradeDataTable;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.TryParse(InstructorIdTextBox.Text, out int instructorId))
            {
                // Load instructor data based on the specified instructor ID
                LoadInstructorData(instructorId);
            }
            else
            {
                // Show an error message or perform appropriate action for invalid input
            }
        }
        private void LoadInstructorData(int instructorId)
        {
            // Clear any previous data
           // ClearInstructorData();

            // Set the default item for the CourseComboBox
            CourseComboBox.Items.Add("Select a course");

            // Fetch instructor data from the database using the instructor ID
            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Create a SQL command to select instructor data based on the provided ID
                SqlCommand command = new SqlCommand($"SELECT * FROM Instructors WHERE InstructorId = {instructorId}", connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // Display instructor data in appropriate controls
                    string instructorName = reader["InstructorName"].ToString();
                    InstructorNameTextBox.Text = instructorName;

                    // Load courses for the specified instructor
                    LoadCoursesForInstructor(instructorId);
                }
                else
                {
                    // Handle the case where no instructor with the specified ID was found
                    // For example, you can display an error message
                }
            }
        }

        private void ClearInstructorData()
        {
            // Clear instructor-related controls
            InstructorIdTextBox.Text = string.Empty;
            InstructorNameTextBox.Text = string.Empty; // Clear the InstructorNameTextBox
            CourseComboBox.Items.Clear();
            dataGridViewClassData.DataSource = null;
            // ... Clear other controls as needed
        }


        private void InstructorNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void InstructorIdTextBox_TextChanged_1(object sender, EventArgs e)
        {

        }
        private void dataGridViewClassData_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            // Replace gradeColumnIndex with the actual index of the Grade column
            int gradeColumnIndex = 2; // Replace with the actual index of the Grade column

            if (e.ColumnIndex == gradeColumnIndex)
            {
                string newGrade = e.FormattedValue.ToString();

                // Validate the entered grade
                if (!IsValidGrade(newGrade))
                {
                    e.Cancel = true; // Cancel the cell validation

                    // Show an error message box
                    MessageBox.Show("Please enter A, B, C, D, or F", "Invalid Grade", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Clear the error message in the DataGridView cell
                    dataGridViewClassData.Rows[e.RowIndex].ErrorText = "Enter A, B, C, D, or F";
                }
                else
                {
                    // Clear the error message if the input is valid
                    dataGridViewClassData.Rows[e.RowIndex].ErrorText = string.Empty;
                }
            }
        }


        private bool IsValidGrade(string grade)
        {
            return Regex.IsMatch(grade, "^[ABCDFabcdf]$");
        }




    }
}
