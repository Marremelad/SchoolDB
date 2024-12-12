using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public class AdminRepository
{
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