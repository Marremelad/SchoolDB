using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public class EmployeeRoleRepository
{
    // Returns a string of all employees and their assigned roles.
    public static string GetEmployeesWithRoles()
    {
        using (var context = new SchoolContext())
        {
            var query = context.EmployeeRoles
                .GroupBy(er => er.EmployeeIdFkNavigation)
                .Select(s => new
                {
                    EmployeeName = $"{s.Key.EmployeeFirstName} {s.Key.EmployeeLastName}",
                    RoleName = s.Select(r => r.RoleIdFkNavigation.RoleName)
                })
                .ToDictionary(k => k.EmployeeName, v => v.RoleName);

            var result = string.Join("\n", query.Select(q => $"{q.Key}: {string.Join(", ", q.Value)}"));

            return string.IsNullOrEmpty(result) ? "No employees found." : result;
        }
    }
}