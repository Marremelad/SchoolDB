using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class StudentRepository
{
    // Returns a string of all students and their classes ordered by specific input.
    public static string GetStudents<TKey>(
        Expression<Func<Student, TKey>> orderByExpression,
        bool descending)
    {
        using (var context = new SchoolContext())
        {
            IQueryable<Student> query = context.Students
                .Include(i => i.ClassIdFkNavigation);
            
            query = descending
                ? query.OrderByDescending(orderByExpression)
                : query.OrderBy(orderByExpression);
            
            return string.Join("\n", query
                .Select(s =>
                    $"{s.StudentFirstName} " +
                    $"{s.StudentLastName} " +
                    $"{s.ClassIdFkNavigation.ClassName}"));
        }
    }

    // Returns a string of students filtered by class name.
    public static string GetStudentsByClass(string className)
    {
        using (var context = new SchoolContext())
        {
            return string.Join("\n",context.Students
                .Where(s => s.ClassIdFkNavigation.ClassName == className)
                .Select(s =>
                    $"{s.StudentFirstName} " +
                    $"{s.StudentLastName} " +
                    $"{s.ClassIdFkNavigation.ClassName}"));
        }
    }
}