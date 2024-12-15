using System.Linq.Expressions;
using SchoolDB.Models;
using SchoolDB.Options;
using SchoolDB.Services;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Views;

public static class StudentMenu
{
    // Display the student menu.
    public static void DisplayStudentMenu()
    {
        while (true)
        {
            Console.Clear();
            
            // A list of type string that is converted into a list of type MenuChoice.
            var choice = DisplayUi.DisplayMultiChoiceMenu("Select options to filter by", MenuText.StudentMenuText)
                .Where(StudentMenuText.ContainsKey)
                .Select(key => StudentMenuText[key])
                .ToList();
            
            if (Helper.IsValidCombination(choice))
            {
                var (sortBy, orderBy) = Helper.ApplyOptions(choice);
                Console.WriteLine(StudentRepository.DisplayStudentsWithClasses(sortBy, orderBy));
                break;
            }
            Console.WriteLine("Invalid combination selected.");
            Thread.Sleep(2000);
        }
        
    }
}   