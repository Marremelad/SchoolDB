using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using SchoolDB.Data;
using SchoolDB.Models;

namespace SchoolDB;

public static class StudentRepository
{
    // Returns a dictionary of all students and their classes ordered by specific input.
    public static Dictionary<string, string> GetStudents<TKey>(Expression<Func<Student, TKey>> orderByExpression, bool descending)
    {
        using (var context = new SchoolContext())
        {
            IQueryable<Student> query = context.Students.Include(i => i.ClassIdFkNavigation);
            
            query = descending
                ? query.OrderByDescending(orderByExpression)
                : query.OrderBy(orderByExpression);
            
            return query
                .Select(s => new
                {
                    StudentName = $"{s.StudentFirstName} {s.StudentLastName}",
                    s.ClassIdFkNavigation.ClassName
                })
                .ToDictionary(k => k.StudentName, v => v.ClassName);
        }
    }




}