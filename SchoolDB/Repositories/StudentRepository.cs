using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;

namespace SchoolDB;

public static class StudentRepository
{
    // Returns a dictionary of all students and their classes.
    public static Dictionary<string, string> GetStudents()
    {
        using (var context = new SchoolContext())
        {
            return context.Students
                .Include(i => i.ClassIdFkNavigation)
                .Select(s => new
                {
                    StudentName = $"{s.StudentFirstName} {s.StudentLastName}",
                    s.ClassIdFkNavigation.ClassName
                })
                .ToDictionary(k => k.StudentName, v => v.ClassName);
        }
    }
}