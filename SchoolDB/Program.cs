using System.Security;

namespace SchoolDB;

class Program
{
    static void Main(string[] args)
    {
        var employees = EmployeeRoleRepository.GetEmployees();

        Console.WriteLine(employees);
    }
}