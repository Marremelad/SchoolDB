using SchoolDB.Options;
using SchoolDB.Services;

namespace SchoolDB.Views;

public static class ClassMenu
{
    // Display the class menu.
    public static void DisplayClassMenu()
    {
        var choice = DisplayUi.DisplaySingleChoiceMenu("Select a class to see it's students", MenuText.ClassMenuText);

        var chosenClass = MenuText.ClassMenuText.First(p => p.Value == choice).Key;

        Console.WriteLine(StudentRepository.GetStudentsFilteredByClass(chosenClass));
    }
}