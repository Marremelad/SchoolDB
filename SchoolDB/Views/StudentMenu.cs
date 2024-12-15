using System.Linq.Expressions;
using SchoolDB.Models;
using SchoolDB.Options;
using SchoolDB.Services;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Views;

public static class StudentMenu
{
    // List containing lists of valid combinations.
    private static readonly List<List<MenuChoice>> ValidCombinations =
    [
        new() { MenuChoice.SortByFirstName, MenuChoice.OrderByDescending },
        new() { MenuChoice.SortByLastName, MenuChoice.OrderByDescending },
        new() { MenuChoice.SortByFirstName, MenuChoice.OrderByAscending },
        new() { MenuChoice.SortByLastName, MenuChoice.OrderByAscending }

    ];
    
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
            
            if (IsValidCombination(choice))
            {
                Console.WriteLine(ApplyOptions(choice));
                break;
            }
            Console.WriteLine("Invalid combination selected.");
            Thread.Sleep(2000);
        }
        
    }

    // Check if the chosen combination of options is valid.
    private static bool IsValidCombination(List<MenuChoice> choice)
    {
        return ValidCombinations.Any(vc =>
            vc.SequenceEqual(choice)); 
    }

    // Applies the combination of options and calls the method to retrieve student information.
    private static string ApplyOptions(List<MenuChoice> choice)
    {
        bool orderBy;
        Expression<Func<Student, string>> sortBy;
            
        if ((int)choice[0] == 5 && (int)choice[1] == 7)
        {
            sortBy = s => s.StudentFirstName;
            orderBy = false;
        }
        else
        {
            sortBy = s => s.StudentLastName;
            orderBy = true;
        }

        return StudentRepository.GetStudentsWithClasses(sortBy, orderBy);
    }
}   