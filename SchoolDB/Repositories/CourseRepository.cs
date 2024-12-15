using SchoolDB.Data;

namespace SchoolDB;

public static class CourseRepository
{
    // Returns a list of all courses in the database.
    public static List<string> DisplayCourses()
    {
        using (var context = new SchoolContext())
        {
            return context.Courses
                .Select(s => s.CourseName)
                .ToList();
        }
    }
}