using SchoolDB.Options;
using SchoolDB.Services;

namespace SchoolDB.Views;

public static class ClassMenu
{
    public static void DisplayClassMenu()
    {
        var choice = DisplayUi.DisplaySingleChoiceMenu("Select a class to see it's students", MenuText.ClassMenuText);
    }
}