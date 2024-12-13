using System.Security;

namespace SchoolDB;

class Program
{
    static void Main(string[] args)
    {
        var employees = EmployeeRoleRepository.GetEmployeesWithRoles();

        Console.WriteLine(employees);
    }
}