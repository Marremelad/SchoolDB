using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB.Repositories;

public static class StudentRepository
{
    // Returns a string of all students and their classes ordered by specific input.
    public static string DisplayStudentsWithClasses<TKey>(
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

            var result = string.Join("\n", query
                .Select(s =>
                    $"Name: {s.StudentFirstName} " +
                    $"{s.StudentLastName}, " +
                    $"Class: {s.ClassIdFkNavigation.ClassName}"));

            return string.IsNullOrEmpty(result) ? "No students found." : result;
        }
    }

    // Returns a string of students filtered by class name.
    public static string DisplayStudentsFilteredByClass<TKey>(
        Expression<Func<Student, TKey>> orderByExpression,
        bool descending,
        string className)
    {
        using (var context = new SchoolContext())
        {
            var query = context.Students
                .Where(s => s.ClassIdFkNavigation.ClassName == className);

            query = descending
                ? query.OrderByDescending(orderByExpression)
                : query.OrderBy(orderByExpression);

            var selection = query.Select(s => new
            {
                FirstName = s.StudentFirstName,
                LastName = s.StudentLastName
            });

            var result = string.Join("\n", new[]
            {
                $"{className}",
                string.Join("\n", selection.Select(s => $"{s.FirstName} {s.LastName}"))
            });

            return string.IsNullOrEmpty(result) ? "No students found." : result;
        }

    }
    
    // Adds a student to the database.
    public static void AddStudentToDatabase(string firstName, string lastName, string studentSsn, int classId)
    {
        using (var context = new SchoolContext())
        {
            var newStudent = new Student()
            {
                StudentFirstName = firstName,
                StudentLastName = lastName,
                StudentSsn = studentSsn,
                ClassIdFk = classId
            };

            context.Students.Add(newStudent);
            context.SaveChanges();

            Console.Clear();
            Console.WriteLine("New student added successfully.");
        }
    }
   
}