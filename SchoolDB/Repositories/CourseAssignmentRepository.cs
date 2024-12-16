using SchoolDB.Data;

namespace SchoolDB.Repositories;

public class CourseAssignmentRepository
{
    // Returns a string of all teachers and their assigned courses.
    public static string DisplayTeachersWithCourses()
    {
        using (var context = new SchoolContext())
        {
            var query = context.CourseAssignments
                .Join(context.Employees,
                    assignment => assignment.TeacherIdFkNavigation.EmployeeIdFk,
                    employee => employee.EmployeeId,
                    (assignment, employee) => new { assignment, employee })
                .Join(context.Courses,
                    result => result.assignment.CourseIdFk,
                    course => course.CourseId,
                    (result, course) => new { result.assignment, result.employee, course })
                .GroupBy(g => g.assignment.TeacherIdFk)
                .Select(s => new
                {
                    TeacherName = $"{s.First().employee.EmployeeFirstName} {s.First().employee.EmployeeLastName}",
                    Courses = s.Select(r => r.course.CourseName)
                })
                .ToDictionary(k => k.TeacherName, v => v.Courses);

            var result = string.Join("\n", new[]
            {
                "Teachers",
                string.Join("\n", query.Select(q => $"Name: {q.Key}, Courses: {string.Join(", ", q.Value)}"))
            });

            return string.IsNullOrEmpty(result) ? "No Teachers found." : result;
        }
    }
}