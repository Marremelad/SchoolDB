using System.Linq.Expressions;
using System.Text.RegularExpressions;
using SchoolDB.Models;
using SchoolDB.Options;

namespace SchoolDB.Services;

public static class Helper
{
    // Get first name from user input.
    public static string GetFirstName(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            var firstName = Console.ReadLine();
            
            if (!string.IsNullOrEmpty(firstName)) return firstName;
            Console.WriteLine("First name can not be empty.");
            Thread.Sleep(2000);
        }
    }

    // Get last name from user input.
    public static string GetLastName(string title)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            var lastName = Console.ReadLine();

            if (!string.IsNullOrEmpty(lastName)) return lastName;
            Console.WriteLine("Last name can not be empty");
            Thread.Sleep(2000);
        }
    }

    
    // Get SSN from user input.
    public static string GetSsn(string title)
    {
        const string pattern = @"^\d{8}-\d{4}$";
        
        while (true)
        {
            Console.Clear();
            Console.WriteLine(title);
            
            var ssn = Console.ReadLine();
            
            if (ssn != null && Regex.IsMatch(ssn, pattern)) return ssn;
            Console.WriteLine("Invalid SSN format.");
            Thread.Sleep(2000);
        }
    }

    // Get class ID from user input.
    public static int GetClassId(string title)
    {
        Console.Clear();
        
        var choice = DisplayUi.DisplaySingleChoiceMenu(title,
            MenuText.ClassMenuText);

        int classId = 0;
        switch ((MenuText.MenuChoice)choice)
        {
            case MenuText.MenuChoice.SoftwareEngineering:
                classId = 1;
                break;
            
            case MenuText.MenuChoice.DataScience:
                classId = 2;
                break;
            
            case MenuText.MenuChoice.AiAndMachineLearning:
                classId = 3;
                break;
        }

        return classId;
    }
    
    // Check if the chosen combination of options is valid.
    public static bool IsValidCombination(List<MenuText.MenuChoice> choice)
    {
        
        // List containing lists of valid combinations.
        List<List<MenuText.MenuChoice>> validCombinations =
        [
            new() { MenuText.MenuChoice.SortByFirstName, MenuText.MenuChoice.OrderByDescending },
            new() { MenuText.MenuChoice.SortByLastName, MenuText.MenuChoice.OrderByDescending },
            new() { MenuText.MenuChoice.SortByFirstName, MenuText.MenuChoice.OrderByAscending },
            new() { MenuText.MenuChoice.SortByLastName, MenuText.MenuChoice.OrderByAscending }

        ];
        
        return validCombinations.Any(vc =>
            vc.SequenceEqual(choice)); 
    }
    
    // Applies the combination of options and calls the method to retrieve student information.
    public static Tuple<Expression<Func<Student, string>>, bool> ApplyOptions(List<MenuText.MenuChoice> choice)
    {
        Expression<Func<Student, string>> sortBy;
        bool orderBy;
        
        if ((int)choice[0] == 13 && (int)choice[1] == 15)
        {
            sortBy = s => s.StudentFirstName;
            orderBy = false; // Order by Descending.
        }
        else if ((int)choice[0] == 14 && (int)choice[1] == 15)
        {
            sortBy = s => s.StudentLastName;
            orderBy = false; // Order by Descending.
        }
        else if((int)choice[0] == 13 && (int)choice[1] == 16)
        {
            sortBy = s => s.StudentFirstName;
            orderBy = true; // Order by Ascending.
        }
        else
        {
            sortBy = s => s.StudentLastName;
            orderBy = true; // Order by Ascending.
        }

        return new Tuple<Expression<Func<Student, string>>, bool>(sortBy, orderBy);
    }
}