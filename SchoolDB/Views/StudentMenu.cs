using System.Linq.Expressions;
using SchoolDB.Models;
using SchoolDB.Options;
using SchoolDB.Services;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Views;

public static class StudentMenu
{
    private static readonly List<List<MenuChoice>> ValidCombinations =
    [
        new() { MenuChoice.SortByFirstName, MenuChoice.OrderByDescending },
        new() { MenuChoice.SortByLastName, MenuChoice.OrderByDescending },
        new() { MenuChoice.SortByFirstName, MenuChoice.OrderByAscending },
        new() { MenuChoice.SortByLastName, MenuChoice.OrderByAscending }

    ];
    
    public static void DisplayStudentMenu()
    {
        var choice = DisplayUi.DisplayMultiChoiceMenu("Select options to filter by", MenuText.StudentMenuText)
            .Where(StudentMenuText.ContainsKey)
            .Select(key => StudentMenuText[key])
            .ToList();

        var isValidCombination = ValidCombinations.Any(validCombination =>
            validCombination.SequenceEqual(choice));
        
        if (isValidCombination)
        {
            bool orderBy;
            
            Expression<Func<Student, string>> sortBy;
            
            if ((int)choice[0] == 4 && (int)choice[1] == 6)
            {
                sortBy = s => s.StudentFirstName;
                orderBy = false;
            }
            else
            {
                sortBy = s => s.StudentLastName;
                orderBy = true;
            }

            Console.WriteLine(StudentRepository.GetStudentsWithClasses(sortBy, orderBy));
        }
        else
        {
            Console.WriteLine("Invalid combination selected.");
        }
    }
}   