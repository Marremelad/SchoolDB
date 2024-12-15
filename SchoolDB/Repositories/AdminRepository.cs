using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;

namespace SchoolDB;

public class AdminRepository
{
    // Returns a list of all admins.
    public static string DisplayAdminsWithClasses()
    {
        using (var context = new SchoolContext())
        {
            var query = context.Admins
                .Include(e => e.EmployeeIdFkNavigation)
                .Select(s => new
                {
                    AdminName = $"{s.EmployeeIdFkNavigation.EmployeeFirstName} " +
                                $"{s.EmployeeIdFkNavigation.EmployeeLastName}",
                    ClassName = s.Classes.Where(c => c.AdminIdFk == s.AdminId)
                        .Select(c => c.ClassName)
                })
                .ToDictionary(k => k.AdminName, v => v.ClassName);

            var result = string.Join("\n", new[] 
            {
                "Admins",
                string.Join("\n", query.Select(q => $"Name: {q.Key}, Class: {string.Join(", ", q.Value)}"))
            });


            return string.IsNullOrEmpty(result) ? "No admins found." : result;
        }
    }
}
