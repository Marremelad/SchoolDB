using SchoolDB.Data;

namespace SchoolDB;

public class EmployeeRoleRepository
{
    // Returns a string of all employees with assigned roles.
    public static string DisplayEmployeesWithRoles()
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

            var result = string.Join("\n", new[]
            {
                "All employees with assigned roles",
                string.Join("\n", query.Select(q => $"Name: {q.Key}, Role: {string.Join(", ", q.Value)}"))
            });

            return string.IsNullOrEmpty(result) ? "No employees found." : result;
        }
    }
}