namespace SchoolDB;

class Program
{
    static void Main(string[] args)
    {
        foreach (var employee in Employees.GetAllEmployees())
        {
            Console.WriteLine(employee.EmployeeFirstName);
        }

        foreach (var teacher in Employees.GetTeachers())
        {
            Console.WriteLine($"{teacher.EmployeeIdFkNavigation.EmployeeFirstName}" +
                              $"{teacher.EmployeeIdFkNavigation.EmployeeLastName}");
        }
    }
}