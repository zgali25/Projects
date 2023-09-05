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
    public partial class ViewRegistered : Form
    {
        public ViewRegistered()
        {
            InitializeComponent();
            LoadStudents(); // Populate the ComboBox with students on form load.
        }

        private void LoadRegisteredCourses(int studentId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT Courses.CourseTitle, StudentCourses.Grade " +
                    "FROM StudentCourses " +
                    "JOIN Courses ON StudentCourses.CourseId = Courses.CourseId " +
                    "WHERE StudentCourses.StudentId = @StudentId";



                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        command.Parameters.AddWithValue("@StudentId", studentId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable coursesTable = new DataTable();
                            adapter.Fill(coursesTable);

                            // Bind the DataTable to the DataGridView
                            dataGridViewCourses.DataSource = coursesTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void ViewRegistered_Load(object sender, EventArgs e)
        {
            // The LoadStudents method will be called automatically when the form loads.
        }

        private void dataGridViewCourses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // You can handle DataGridView cell content click events here if needed.
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem is DataRowView selectedStudentRow)
            {
                int studentId = Convert.ToInt32(selectedStudentRow["StudentId"]);
                LoadRegisteredCourses(studentId);
            }
        }

        private void LoadStudents()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                    string query = "SELECT StudentId, StudentName FROM Students";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable studentsTable = new DataTable();
                            adapter.Fill(studentsTable);

                            // Bind the DataTable to the ComboBox
                            comboBox1.DisplayMember = "StudentName";
                            comboBox1.ValueMember = "StudentId";
                            comboBox1.DataSource = studentsTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}