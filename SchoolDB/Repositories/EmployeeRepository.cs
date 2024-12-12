using System.Collections;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class EmployeeRepository
{
    // Returns a dictionary of all employees and their assigned roles.
    public static Dictionary<Employee, List<string>> GetEmployees()
    {
        using (var context = new SchoolContext())
        {
            return context.EmployeeRoles
                .GroupBy(r => r.EmployeeIdFkNavigation)
                .Select(s => new
                {
                    s.Key,
                    RoleName = s.Select(r => r.RoleIdFkNavigation.RoleName).ToList()
                })
                .ToDictionary(k => k.Key, v => v.RoleName);
        }
    }
    
    // Return the employee with the principal role.
    public static Employee GetPrincipal()
    {
        using (var context = new SchoolContext())
        {
            return context.Employees
                .Single(e => e.EmployeeRoles.Any(er => er.RoleIdFkNavigation.RoleName == "Principal"));
        }
    }
}