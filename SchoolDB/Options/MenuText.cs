namespace SchoolDB.Options;

public static class MenuText
{
    public enum MenuChoice
    {
        // Main Menu.
        Employees,
        Admins,
        Teachers,
        Students,
    }
    
    public static readonly Dictionary<string, MenuChoice> MainMenuText = new()
    {
        // Main Menu Options.
        { "Show all employees", MenuChoice.Employees },
        { "Show all admins", MenuChoice.Admins },
        { "Show all teachers", MenuChoice.Teachers },
        { "Show all students", MenuChoice.Students },
    };
}