//Update GPA Program
namespace Challenge_3._4
{
    public partial class Form1 : Form
    {
        //create dictionary collection
        private Dictionary<string, Student> students = new Dictionary<string, Student>();

        //form
        public Form1()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
        //open update gpa form
        private void button1_Click(object sender, EventArgs e)
        {
            if (studentListBox.SelectedIndex != -1)
            {
                string selectedStudent = studentListBox.SelectedItem.ToString();
                string studentID = selectedStudent.Split(' ')[1];
                Student s = students[studentID];
                UpdateGpaForm gpaForm = new UpdateGpaForm(s);
                gpaForm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Must select a student.");
            }
        }
        //retrieve data from student file
        private void Form1_Load(object sender, EventArgs e)
        {
            using StreamReader sr = new StreamReader("student.txt");
            string studentID;
            while ((studentID = sr.ReadLine()) != null)
            {
                Student s = new Student(studentID, sr.ReadLine(), double.Parse(sr.ReadLine()), double.Parse(sr.ReadLine()));
                students.Add(studentID, s);
                studentListBox.Items.Add($"ID: {s.StudentId} " + $"Name: {s.StudentName} GPA: {s.Gpa:n2} " + $"Credit Hours: {s.CreditHours}");
            }
        }
        //activate main form
        private void Form1_Activated(object sender, EventArgs e)
        {
            studentListBox.Items.Clear();
            foreach (Student s in students.Values)
            {
                studentListBox.Items.Add($"ID: {s.StudentId} " + $"Name: {s.StudentName} GPA: " +
                    $"{s.Gpa:n2} " + $"Credit Hours: {s.CreditHours}");
            }
        }
        //Save updates to student file and close
        private void button2_Click(object sender, EventArgs e)
        {
            using StreamWriter sw = new StreamWriter("student.txt");
            foreach (Student s in students.Values)
            {
                sw.WriteLine(s);
            }
            Close();
        }
    }
    
   
}

