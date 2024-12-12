using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public class EmployeeRoleRepository
{
    // Returns a dictionary of all employees and their assigned roles.
    public static Dictionary<string, IEnumerable<string>> GetEmployees()
    {
        using (var context = new SchoolContext())
        {
           return context.EmployeeRoles
                .GroupBy(er => er.EmployeeIdFkNavigation)
                .Select(s => new
                {
                    EmployeeName = $"{s.Key.EmployeeFirstName} {s.Key.EmployeeLastName}",
                    RoleName = s.Select(r => r.RoleIdFkNavigation.RoleName)
                })
                .ToDictionary(k => k.EmployeeName, v => v.RoleName);
        }
    }
}