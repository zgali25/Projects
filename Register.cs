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
    public partial class Register : Form
    {

        private int studentId; // Store the student's ID

        public Register()
        {
            InitializeComponent();
            
        }
        private void LoadStudents()
        {
            try
            {
                int searchedStudentId;
                if (int.TryParse(textBoxSearch.Text.Trim(), out searchedStudentId))
                {
                    studentId = searchedStudentId;

                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT StudentName FROM Students WHERE StudentId = @StudentId";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@StudentId", searchedStudentId);
                            string studentName = command.ExecuteScalar() as string;

                            if (!string.IsNullOrEmpty(studentName))
                            {
                                textBoxStudentName.Text = studentName;
                            }
                            else
                            {
                                textBoxStudentName.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Register_Load(object sender, EventArgs e)
        {
            LoadStudents(); // Load students into the text boxes
            InitializeAutoComplete(); // Initialize auto-completion for the textBoxSearch
        }


        private void CourseComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();

            if (!string.IsNullOrEmpty(searchText) && int.TryParse(searchText, out int courseId))
            {
                // Get the number of available seats for the selected course
                int availableSeats = GetAvailableSeatsForCourse(courseId);

                // Display the available seats in the TextBox
                seatsTextBox.Text = availableSeats.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Retrieve the student ID
                int studentId = this.studentId; // Get the student ID from wherever you're storing it

                // Get the selected course title from the textBoxSearch
                string courseTitle = textBoxSearch.Text.Trim();

                // Get the course ID based on the selected course title
                int courseId = GetCourseIdByTitle(courseTitle);

                if (courseId != 0)
                {
                    // Check if the student is already registered for the course
                    bool isRegistered = CheckIfStudentIsRegistered(studentId, courseId);

                    if (!isRegistered)
                    {
                        // Register the student for the course
                        RegisterStudentForCourse(studentId, courseId);

                        // Update the available seats for the course
                        int availableSeats = GetAvailableSeatsForCourse(courseId);
                        UpdateAvailableSeatsForCourse(courseId, availableSeats - 1);

                        // Update the student's registered courses
                        string existingCourses = GetExistingCoursesRegistered(studentId);
                        if (!string.IsNullOrEmpty(existingCourses))
                        {
                            existingCourses += ",";
                        }
                        existingCourses += courseId.ToString();
                        UpdateExistingCoursesRegistered(studentId, existingCourses);

                        // Refresh the student's courses list (you need to implement this function)
                        RefreshStudentCoursesList();

                        MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Course is already registered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Invalid course title entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetCourseIdByTitle(string courseTitle)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                string query = "SELECT CourseId FROM Courses WHERE CourseTitle = @CourseTitle";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CourseTitle", courseTitle);
                    object result = command.ExecuteScalar();

                    if (result != null && int.TryParse(result.ToString(), out int courseId))
                    {
                        return courseId;
                    }
                }
            }

            return 0; // Return 0 if the course title is not found
        }
        private void UpdateAvailableSeatsForCourse(int courseId, int newAvailableSeats)
        {
            // Implementation to update available seats for a course
        }
        private string GetExistingCoursesRegistered(int studentId)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                string query = "SELECT CoursesRegistered FROM Students WHERE StudentID = @StudentId";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@StudentId", studentId);
                    string coursesRegistered = command.ExecuteScalar() as string;
                    return coursesRegistered ?? string.Empty;
                }
            }
            // This return statement should be outside the using block
            return string.Empty;
        }
        private void UpdateExistingCoursesRegistered(int studentId, string coursesRegistered)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();

                    // Update the CoursesRegistered value for the specified student
                    string updateQuery = "UPDATE Students SET CoursesRegistered = @CoursesRegistered WHERE StudentId = @StudentId";
                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, conn))
                    {
                        updateCommand.Parameters.AddWithValue("@CoursesRegistered", coursesRegistered);
                        updateCommand.Parameters.AddWithValue("@StudentId", studentId);
                        updateCommand.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RefreshStudentCoursesList()
        {
            // Placeholder implementation: Refresh the student's courses list
            // You can update a ListBox or DataGridView with the updated courses here
        }


        private int GetCourseIdByTitle(SqlConnection connection, string courseTitle)
        {
            string query = "SELECT CourseId FROM Courses WHERE CourseTitle = @CourseTitle";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CourseTitle", courseTitle);
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int courseId))
                {
                    return courseId;
                }
            }

            return 0; // Return 0 if the course title is not found
        }


        private string GetExistingCoursesRegistered(SqlConnection connection, int studentId)
        {
            string query = "SELECT CoursesRegistered FROM Students WHERE StudentID = @StudentId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentId", studentId);
                string coursesRegistered = command.ExecuteScalar() as string;
                return coursesRegistered ?? string.Empty;
            }
        }
        private void RegisterStudentForCourse(int studentId, int courseId)
        {
            string connectionString = Properties.Settings.Default.ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Check if the student is already registered for the course
                bool isRegistered = CheckIfStudentIsRegistered(studentId, courseId);

                if (isRegistered)
                {
                    MessageBox.Show("Student is already registered for this course.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Do not proceed with registration
                }

                // Create a SQL command to insert a new record into the StudentCourses table
                SqlCommand command = new SqlCommand("INSERT INTO StudentCourses (StudentId, CourseId) VALUES (@StudentId, @CourseId)", connection);

                // Provide values for the parameters in the SQL command
                command.Parameters.AddWithValue("@StudentId", studentId);
                command.Parameters.AddWithValue("@CourseId", courseId);

                // Execute the command to insert the new record
                command.ExecuteNonQuery();

                MessageBox.Show("Registration successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private bool CheckIfStudentIsRegistered(int studentId, int courseId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT CoursesRegistered FROM Students WHERE StudentID = @StudentId";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);
                        string coursesRegistered = command.ExecuteScalar() as string;

                        if (!string.IsNullOrEmpty(coursesRegistered))
                        {
                            // Split the CoursesRegistered string into individual course IDs
                            string[] registeredCourses = coursesRegistered.Split(',');

                            // Check if the courseId is present in the array of registered courses
                            return registeredCourses.Contains(courseId.ToString());
                        }

                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();

        }

       

        private int GetAvailableSeatsForCourse(int courseId)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();

                // Query the database to get the available seats for the specified course
                string query = "SELECT AvailableSeats FROM Courses WHERE CourseId = @CourseId";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@CourseId", courseId);
                    object result = command.ExecuteScalar();

                    // Parse the result to an integer and return it
                    if (result != null && int.TryParse(result.ToString(), out int availableSeats))
                    {
                        return availableSeats;
                    }
                }
            }

            // Return 0 if something goes wrong or no seats are found
            return 0;
        }
        private void UpdateAvailableSeatsForCourse(SqlConnection connection, int courseId, int newAvailableSeats)
        {
            string updateQuery = "UPDATE Courses SET AvailableSeats = @AvailableSeats WHERE CourseId = @CourseId";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@AvailableSeats", newAvailableSeats);
                updateCommand.Parameters.AddWithValue("@CourseId", courseId);
                updateCommand.ExecuteNonQuery();
            }
        }
        private bool CheckIfCourseIsActive(SqlConnection connection, int courseId)
        {
            string query = "SELECT IsActive FROM Courses WHERE CourseId = @CourseId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@CourseId", courseId);
                bool isActive = (bool)command.ExecuteScalar();
                return isActive;
            }
        }
        private void activeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                int courseId = int.Parse(textBoxSearch.Text); // Assuming you have a textBoxCourseId for the course ID
                bool isActive = activeCheckBox.Checked;

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                    UpdateCourseActiveStatus(conn, courseId, isActive);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCourseActiveStatus(SqlConnection connection, int courseId, bool isActive)
        {
            string updateQuery = "UPDATE Courses SET IsActive = @IsActive WHERE CourseId = @CourseId";
            using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
            {
                updateCommand.Parameters.AddWithValue("@IsActive", isActive);
                updateCommand.Parameters.AddWithValue("@CourseId", courseId);
                updateCommand.ExecuteNonQuery();
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            string searchText = textBoxSearch.Text.Trim();

            // Search for courses based on the entered text
            SearchCourses(searchText);
        }


        private void SearchCourses(string searchText)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT CourseId, CourseTitle, AvailableSeats FROM Courses " +
                                   "WHERE CourseTitle LIKE @SearchText";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int courseIdResult = (int)reader["CourseId"];
                                textBoxCourseId.Text = courseIdResult.ToString();

                                int availableSeats = (int)reader["AvailableSeats"];
                                seatsTextBox.Text = availableSeats.ToString();
                            }
                            else
                            {
                                textBoxCourseId.Clear();
                                seatsTextBox.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (int.TryParse(textBoxStudentId.Text.Trim(), out studentId))
                {
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        conn.Open();

                        // Retrieve the student name from the database based on the entered student ID
                        string studentName = GetStudentNameFromDatabase(conn, studentId);

                        // Display the student's name in textBoxStudentName
                        textBoxStudentName.Text = studentName;

                        // Clear any previous error message
                        //ssageBox.Show("Valid student ID entered.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    // Show an error message
                    MessageBox.Show("Invalid student ID entered.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBoxStudentName.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void SearchStudentById()
        {
            try
            {
                int searchedStudentId;
                if (int.TryParse(textBoxSearch.Text.Trim(), out searchedStudentId))
                {
                    using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                    {
                        conn.Open();
                        string query = "SELECT StudentName FROM Students WHERE StudentId = @StudentId";
                        using (SqlCommand command = new SqlCommand(query, conn))
                        {
                            command.Parameters.AddWithValue("@StudentId", searchedStudentId);
                            string studentName = command.ExecuteScalar() as string;

                            if (!string.IsNullOrEmpty(studentName))
                            {
                                textBoxStudentName.Text = studentName;
                            }
                            else
                            {
                                textBoxStudentName.Clear();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private string GetStudentNameFromDatabase(SqlConnection connection, int studentId)
        {
            string query = "SELECT StudentName FROM Students WHERE StudentId = @StudentId";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@StudentId", studentId);
                string studentName = command.ExecuteScalar() as string;
                return studentName ?? string.Empty;
            }
        }
        private void InitializeAutoComplete()
        {
            // Set up auto-completion for the textBoxSearch
            textBoxSearch.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxSearch.AutoCompleteSource = AutoCompleteSource.CustomSource;

            // Create and set the auto-completion data source
            AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();
                string query = "SELECT CourseTitle FROM Courses";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            autoCompleteData.Add(reader.GetString(0));
                        }
                    }
                }
            }
            textBoxSearch.AutoCompleteCustomSource = autoCompleteData;
        }
        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            // Update auto-completion suggestions based on the current text in textBoxSearch
            textBoxSearch.AutoCompleteCustomSource.Clear();
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();
                string query = "SELECT CourseTitle FROM Courses " +
                               "WHERE CourseTitle LIKE @SearchText";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@SearchText", textBoxSearch.Text.Trim() + "%");
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            textBoxSearch.AutoCompleteCustomSource.Add(reader.GetString(0));
                        }
                    }
                }
            }
        }
    }
}