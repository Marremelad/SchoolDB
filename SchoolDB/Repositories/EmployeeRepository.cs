using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class EmployeeRepository
{
    // Returns a string of all employees.
    public static string DisplayAllEmployees()
    {
        using (var context = new SchoolContext())
        {
            var query = context.Employees
                .Select(s => $"{s.EmployeeFirstName} {s.EmployeeLastName}");

            var result = string.Join("\n", new[]
            {
                "All employees",
                string.Join("\n", query)
            });

            return result;
        }
    }
    
    // Return the employee with the principal role.
    public static string DisplayPrincipal()
    {
        using (var context = new SchoolContext())
        {
            return context.Employees
                .Where(e => e.EmployeeRoles.Any(er => er.RoleIdFkNavigation.RoleName == "Principal"))
                .Select(e => $"Principal\nName: {e.EmployeeFirstName} {e.EmployeeLastName}")
                .SingleOrDefault() ?? "Principal not found";
        }
    }
    
    public static void AddEmployeeToDatabase(string firstName, string lastName)
    {
        using (var context = new SchoolContext())
        {
            var newEmployee = new Employee()
            {
                EmployeeFirstName = firstName,
                EmployeeLastName = lastName
            };

            context.Employees.Add(newEmployee);
            context.SaveChanges();
            
            Console.Clear();
            Console.WriteLine("New employee added successfully.");
        }
    }
}