using SchoolDB.Data;

namespace SchoolDB;

public static class CourseEnrolmentRepository
{
    private static readonly Dictionary<string, int> GradeMapping = new()
    {
        { "A", 5 },
        { "B", 4 },
        { "C", 3 },
        { "D", 2 },
        { "E", 1 },
        { "F", 0 }
    };
    
    public static string GetRecentGrades()
    {
        using (var context = new SchoolContext())
        {
            var thirtyDaysAgo = DateOnly.FromDateTime(DateTime.Now.AddDays(-30));

            var query = context.CourseEnrolments
                .Where(ce => ce.GradingDate >= thirtyDaysAgo)
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

    public static string GetCourseStats(string course)
    {
        using (var context = new SchoolContext())
        {
            var query = context.CourseEnrolments
                .Where(ce => ce.CourseIdFkNavigation.CourseName == course)
                .Select(s => $"{s.Grade}");
            
            var numericGrades = new List<int>();
            
            foreach (var grade in query)
            {
                if (grade == "") continue;
                numericGrades.Add(GradeMapping[grade]);
            }

            if (numericGrades.Count == 0) return $"{course}\nNo available data for this course.";
            
            var numericHighestGrade = numericGrades.Max();
            var numericLowestGrade = numericGrades.Min();
            var numericAverageGrade = Convert.ToInt32(numericGrades.Average());

           return StringOfCourseStats(course, numericHighestGrade, numericLowestGrade, numericAverageGrade);
        }
    }

    private static string StringOfCourseStats(string course, int numericHighestGrade, int numericLowestGrade, int numericAverageGrade)
    {
        var highestGrade = GradeMapping.First(kvp => kvp.Value == numericHighestGrade).Key;
        var lowestGrade = GradeMapping.First(kvp => kvp.Value == numericLowestGrade).Key;
        var averageGrade = GradeMapping.First(kvp => kvp.Value == numericAverageGrade).Key;
        
        using (var context = new SchoolContext())
        {
            var queryForHighestGrade = context.CourseEnrolments
                .Where(ce => ce.CourseIdFkNavigation.CourseName == course && ce.Grade == highestGrade)
                .Select(s => 
                    $"{s.StudentIdFkNavigation.StudentFirstName} " +
                    $"{s.StudentIdFkNavigation.StudentLastName}")
                .ToList();

            var queryForLowestGrade = context.CourseEnrolments
                .Where(ce => ce.CourseIdFkNavigation.CourseName == course && ce.Grade == lowestGrade)
                .Select(s =>
                    $"{s.StudentIdFkNavigation.StudentFirstName} " +
                    $"{s.StudentIdFkNavigation.StudentLastName}")
                .ToList();

            var result = string.Join("\n", new[] 
            {
                $"Course: {course}",
                $"\nAverage Grade: {averageGrade}",
                $"\nHighest Grade: {highestGrade}: Acquired by -",
                string.Join("\n", queryForHighestGrade),
                $"\nLowest Grade: {lowestGrade}: Acquired by -",
                string.Join("\n", queryForLowestGrade)
            });

            return result;
        }
    }
}