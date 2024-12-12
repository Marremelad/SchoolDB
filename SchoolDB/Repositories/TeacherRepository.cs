using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class TeacherRepository
{
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
}