using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class Employees
{
    // Returns a list of all employees.
    public static List<Employee> GetAllEmployees()
    {
        using (var context = new SchoolContext())
        {
            return context.Employees.ToList();
        }
    }
    
    // Returns a list of all teachers.
    public static List<Teacher> GetTeachers()
    {
        using (var context = new SchoolContext())
        {
            return context.Teachers
                .Include(e => e.EmployeeIdFkNavigation)
                .ToList();
        }
    }
    
    // Returns a list of all admins.
    public static List<Admin> GetAdmins()
    {
        using (var context = new SchoolContext())
        {
            return context.Admins
                .Include(e => e.EmployeeIdFkNavigation)
                .ToList();
        }
    }
}