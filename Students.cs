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
    public partial class Students : Form
    {
        public Students()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register(); // Pass the connection string if needed
            registerForm.Show();
        }

        private void ViewRegisteredButton_Click(object sender, EventArgs e)
        {
            ViewRegistered viewRegisteredForm = new ViewRegistered();
            viewRegisteredForm.Show();
        }

        private void ViewGradeButton_Click(object sender, EventArgs e)
        {
            ViewGrades view = new ViewGrades();
            view.ShowDialog();
        }
    }
}
