
using System;
using System.Collections.Generic;
using System.Linq;



// Define the main program
class Program
{
    // Define the main method of the program
    static void Main(string[] args)
    {
        // Create a list of Employee objects, each initialized with the provided data
        List<Employee> employees = new List<Employee>
        {
            new Employee { Name = "Cristina Smith", HoursWorked = 35.3, PayRate = 22.00, Department = "Marketing" },
            new Employee { Name = "Logan Reed", HoursWorked = 42, PayRate = 31.25, Department = "Marketing" },
            new Employee { Name = "Brandon Wang", HoursWorked = 20, PayRate = 18.50, Department = "Analytics" },
            new Employee { Name = "Clayton Smith", HoursWorked = 45, PayRate = 40.00, Department = "Marketing" },
            new Employee { Name = "Justin Gale", HoursWorked = 51.2, PayRate = 35.25, Department = "Analytics" }
        };

        // Define a LINQ query using query syntax that selects all employees who worked more than 40 hours
        var result = from e in employees
                     where e.HoursWorked > 40
                     select e;

        // Iterate over the result of the query with a foreach loop
        foreach (var employee in result)
        {
            // For each employee in the result, print their name, department, and hours worked to the console
            Console.WriteLine($"{employee.Name} from {employee.Department} worked {employee.HoursWorked} hours");
        }
    }
}
