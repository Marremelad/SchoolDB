using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public class AdminRepository
{
    // Returns a list of all admins.
    public static Dictionary<string, IEnumerable<string>> GetAdminsWithClasses()
    {
        using (var context = new SchoolContext())
        {
            return context.Admins
                .Include(e => e.EmployeeIdFkNavigation)
                .Select(s => new
                {
                    AdminName = $"{s.EmployeeIdFkNavigation.EmployeeFirstName} " +
                                $"{s.EmployeeIdFkNavigation.EmployeeLastName}",
                    ClassName = s.Classes.Where(c => c.AdminIdFk == s.AdminId)
                        .Select(c => c.ClassName)
                })
                .ToDictionary(k => k.AdminName, v => v.ClassName);
        }
    }
}
