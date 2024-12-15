using SchoolDB.Options;
using SchoolDB.Services;

namespace SchoolDB.Views;

public static class ClassMenu
{
    // Display the class menu.
    public static void DisplayClassMenu()
    {
        var classAsEnum = DisplayUi.DisplaySingleChoiceMenu("Select a class to see it's students", MenuText.ClassMenuText);

        var classAsString = MenuText.ClassMenuText.First(p => p.Value == (MenuText.MenuChoice)classAsEnum).Key;
        
        while (true)
        {
            Console.Clear();
            
            // A list of type string that is converted into a list of type MenuChoice.
            var choice = DisplayUi.DisplayMultiChoiceMenu("Select options to filter by", MenuText.StudentMenuText)
                .Where(MenuText.StudentMenuText.ContainsKey)
                .Select(key => MenuText.StudentMenuText[key])
                .ToList();
            
            if (Helper.IsValidCombination(choice))
            {
                var (sortBy, orderBy) = Helper.ApplyOptions(choice);
                Console.WriteLine(StudentRepository.DisplayStudentsFilteredByClass(sortBy, orderBy, classAsString));
                break;
            }
            Console.WriteLine("Invalid combination selected.");
            Thread.Sleep(2000);
        }
        
        // Console.WriteLine(StudentRepository.GetStudentsFilteredByClass(chosenClass));
    }
}