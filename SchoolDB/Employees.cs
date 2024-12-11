using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class Employees
{
    public static List<Employee> GetAllEmployees()
    {
        using (var context = new SchoolContext())
        {
            return context.Employees.ToList();
        }
    }
    
}