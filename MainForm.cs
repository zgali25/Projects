
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Event handler for the Click event of "button1" (Open CourseForm Button).

            // Create a new instance of the "CourseForm" class.
            Instructor courseForm = new Instructor();

            // Show the "CourseForm" as a new window.
            courseForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Event handler for the Click event of "button2" (Exit Button).

            // Exit the application when the "Exit" button is clicked.
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            Administrator adminForm = new Administrator();
            adminForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Students studentForm = new Students();
            studentForm.Show();
        }
    }
    }

