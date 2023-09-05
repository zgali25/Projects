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
    public partial class ViewGrades : Form
    {
        public ViewGrades()
        {
            InitializeComponent();
        }

        private void FetchAndDisplayGrades()
        {
            try
            {
                if (!int.TryParse(StudentIdTextBox.Text, out int studentId))
                {
                    MessageBox.Show("Please enter a valid student ID.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    conn.Open();
                    string queryGrades = @"SELECT 
                    Courses.CourseTitle AS Course,
                    StudentCourses.Grade, 
                     CASE 
                     WHEN StudentCourses.Grade IN ('A', 'B', 'C') THEN 3 
                     WHEN StudentCourses.Grade IN ('D', 'F') THEN 0
                     ELSE NULL 
                     END AS CreditHours
                     FROM StudentCourses 
                     JOIN Courses ON StudentCourses.CourseId = Courses.CourseId 
                     WHERE StudentCourses.StudentId = @StudentId";




                    using (SqlCommand cmdGrades = new SqlCommand(queryGrades, conn))
                    {
                        cmdGrades.Parameters.AddWithValue("@StudentId", studentId);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmdGrades))
                        {
                            DataTable gradeTable = new DataTable();
                            adapter.Fill(gradeTable);

                            // Append a row for the total credit hours
                            DataRow totalRow = gradeTable.NewRow();
                            totalRow["Course"] = "Total Credit Hours";
                            totalRow["CreditHours"] = gradeTable.Compute("SUM(CreditHours)", "");
                            gradeTable.Rows.Add(totalRow);

                            // Bind the DataTable to the DataGridView
                            dataGridViewCourses.DataSource = gradeTable;

                            dataGridViewCourses.Columns[0].HeaderText = "";
                            dataGridViewCourses.Columns[1].HeaderText = "Grade";
                            dataGridViewCourses.Columns[2].HeaderText = "Credit Hours";

                            string queryCreditHours = "SELECT SUM(CASE WHEN StudentCourses.Grade IN ('A', 'B', 'C') THEN Courses.CreditHours ELSE 0 END) as TotalCreditHours " +
                           "FROM StudentCourses " +
                           "JOIN Courses ON StudentCourses.CourseId = Courses.CourseId " +
                           "WHERE StudentCourses.StudentId = @StudentId";


                            using (SqlCommand cmdCreditHours = new SqlCommand(queryCreditHours, conn))
                            {
                                cmdCreditHours.Parameters.AddWithValue("@StudentId", studentId);
                                object result = cmdCreditHours.ExecuteScalar();

                                if (result != DBNull.Value && int.TryParse(result.ToString(), out int totalCreditHours))
                                {
                                    if (totalCreditHours >= 120)
                                    {
                                        MessageBox.Show("Congratulations, you have just graduated from Tiny College!", "Graduation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
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

        private void ViewGrades_Load(object sender, EventArgs e)
        {
          
        }

        private void FindButton_Click(object sender, EventArgs e)
        {
            FetchAndDisplayGrades();
        }
    }
}
