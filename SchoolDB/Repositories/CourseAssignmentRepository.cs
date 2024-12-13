using System.Threading.Tasks.Dataflow;
using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public class CourseAssignmentRepository
{
    // Returns a list of all teachers and their assigned courses.
    public static string GetTeachersWithCourses()
    {
        using (var context = new SchoolContext())
        {
            return string.Join("\n", context.CourseAssignments
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
                .ToDictionary(k => k.TeacherName, v => v.Courses)
                .Select(q => $"{q.Key} {string.Join(", ", q.Value)}"));
        }
    }
}