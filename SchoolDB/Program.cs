using System.Security;

namespace SchoolDB;

class Program
{
    static void Main(string[] args)
    {
        var students = StudentRepository.GetStudentsByClass("SoftwareEngineering2024");

        Console.WriteLine(students);
    }
}