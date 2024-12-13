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
        
        // Student Menu.
        OrderByDescending,
        OrderByAscending,
        OrderByFirstName,
        OrderByLastName,
    }
    
    public static readonly Dictionary<string, MenuChoice> MainMenuText = new()
    {
        // Main Menu Options.
        { "Show all employees", MenuChoice.Employees },
        { "Show all admins", MenuChoice.Admins },
        { "Show all teachers", MenuChoice.Teachers },
        { "Show all students", MenuChoice.Students },
    };

    public static readonly Dictionary<string, MenuChoice> StudentMenuText = new()
    {
        // Student Menu Options.
        { "Order by Descending", MenuChoice.OrderByDescending },
        { "Order by Ascending", MenuChoice.OrderByAscending },
        { "Order by First Name", MenuChoice.OrderByFirstName },
        { "Order by Last Name", MenuChoice.OrderByLastName },
    };
}