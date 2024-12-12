using System.Security;

namespace SchoolDB;

class Program
{
    static void Main(string[] args)
    {
        var studentsByFirstName = StudentRepository.GetStudents(s => s.ClassIdFkNavigation.ClassName , false);

        foreach (var student in studentsByFirstName)
        {
            Console.WriteLine(student.Key);
        }
    }
}