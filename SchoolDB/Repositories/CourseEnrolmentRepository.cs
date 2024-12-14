using SchoolDB.Data;

namespace SchoolDB;

public static class CourseEnrolmentRepository
{
    public static string GetRecentGrades()
    {
        using (var context = new SchoolContext())
        {
            var thirtyDaysAgo = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));

            var query = context.CourseEnrolments
                .Where(g => g.GradingDate >= thirtyDaysAgo)
                .Select(s => 
                    $"Grade: {s.Grade}, " +
                    $"Date: {s.GradingDate}, " +
                    $"Course: {s.CourseIdFkNavigation.CourseName}, " +
                    $"Student: {s.StudentIdFkNavigation.StudentFirstName} " +
                    $"{s.StudentIdFkNavigation.StudentLastName}");

            var result = string.Join("\n", query);

            return result;
        }
    }
}