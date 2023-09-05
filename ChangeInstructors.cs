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
    public partial class ChangeInsturctor : Form
    {
        public ChangeInsturctor()
        {
            InitializeComponent();
        }




        private void updateButton_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Courses SET InstructorId = @InstructorId, InstructorName = @InstructorName WHERE CourseId = @CourseId", conn))
                {
                    cmd.Parameters.AddWithValue("@InstructorId", instructorComboBox.SelectedValue);
                    cmd.Parameters.AddWithValue("@InstructorName", instructorComboBox.Text);
                    cmd.Parameters.AddWithValue("@CourseId", courseIdTextBox.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Instructor Changed");
                }
            }
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();

        }

        private void findButton_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Courses JOIN Instructors on Courses.InstructorId = " + "Instructors.InstructorId WHERE CourseId = @CourseId", conn))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.SelectCommand.Parameters.AddWithValue("@CourseId", courseIdTextBox.Text);
                        DataTable courseTable = new DataTable();
                        adapter.Fill(courseTable);

                        if (courseTable.Rows.Count < 1)
                        {
                            courseTitle.Text = "No Courses Found";
                            currentInstructor.Enabled = false;
                            updateButton.Enabled = false;
                        }
                        else
                        {
                            // If a matching course is found, display its details and enable the update button.
                            updateButton.Enabled = true;
                            DataRow dr = courseTable.Rows[0];
                            courseTitle.Text = dr["CourseTitle"].ToString();
                            currentInstructor.Text = dr["InstructorName"].ToString();
                        }
                    }
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void ChangeInsturctor_Load_1(object sender, EventArgs e)
        {
            {
                using (SqlConnection conn = new SqlConnection(Properties.Settings.Default.ConnectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("SELECT * FROM Instructors", conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable instructorTable = new DataTable();
                            adapter.Fill(instructorTable);

                            instructorComboBox.DisplayMember = "InstructorName";
                            instructorComboBox.ValueMember = "InstructorId";
                            instructorComboBox.DataSource = instructorTable;
                        }
                    }
                }

            }
        }
    }
}
