using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3._4
{
    //Student class
    public class Student
    {
        //fields
        private string studentId;
        private string studentName;
        private double gpa;
        private double creditHours;

        //properties

        //student ID accessor and mutator
        public string StudentId
        {
            get { return studentId; }
            set { studentId = value; }
        }

        //student name  accessor and mutator
        public string StudentName
        {
            get { return studentName; }
            set { studentName = value; }
        }

        //GPA  accessor and mutator
        public double Gpa
        {
            get { return gpa; }
            set { gpa = value; }
        }

        //Credit hours  accessor and mutator
        public double CreditHours
        {
            get { return creditHours; }
            set { creditHours = value; }
        }

        //constructor
        public Student(string studentId, string studentName, double gpa, double creditHours)
        {
            this.studentId = studentId;
            this.studentName = studentName;
            this.gpa = gpa;
            this.creditHours = creditHours;
        }
        //method for GPA values
        public void UpdateGPA(char courseGrade, double courseCredit)
        {
            courseGrade = char.ToUpper(courseGrade);
            double courseGpa;
            if (courseGrade == 'A')
            {
                courseGpa = 4.0;
            }
            else if (courseGrade == 'B')
            {
                courseGpa = 3.0;
            }
            else if (courseGrade == 'C')
            {
                courseGpa = 2.0;
            }
            else if (courseGrade == 'D')
            {
                courseGpa = 1.0;
            }
            else { courseGpa = 0.0; }
            //Calculate GPA
            Gpa = (Gpa * CreditHours + courseGpa * courseCredit) / (creditHours + courseCredit);
            CreditHours += courseCredit;
        }
        public override string ToString()
        {
            string str;
            str = $"{StudentId}\n{StudentName}\n{Gpa}\n{creditHours}";
            return str;
        }
    }
}
