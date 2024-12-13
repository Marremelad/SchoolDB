using System.Collections;
using Azure.Core;
using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class EmployeeRepository
{
    // Return the employee with the principal role.
    public static string GetPrincipal()
    {
        using (var context = new SchoolContext())
        {
            return context.Employees
                .Where(e => e.EmployeeRoles.Any(er => er.RoleIdFkNavigation.RoleName == "Principal"))
                .Select(e => $"{e.EmployeeFirstName} {e.EmployeeLastName}")
                .SingleOrDefault() ?? "Principal not found";
        }
    }
}