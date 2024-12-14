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
        Classes,
        
        // Student Menu.
        SortByFirstName,
        SortByLastName,
        OrderByDescending,
        OrderByAscending
    }
    
    public static readonly Dictionary<string, MenuChoice> MainMenuText = new()
    {
        // Main Menu Options.
        { "All Employees", MenuChoice.Employees },
        { "Admins", MenuChoice.Admins },
        { "Teachers", MenuChoice.Teachers },
        { "Students", MenuChoice.Students },
        { "Classes", MenuChoice.Classes }
    };

    public static readonly Dictionary<string, MenuChoice> StudentMenuText = new()
    {
        // Student Menu Options.
        { "Sort by First Name", MenuChoice.SortByFirstName },
        { "Sort by Last Name", MenuChoice.SortByLastName },
        { "Order by Descending", MenuChoice.OrderByDescending },
        { "Order by Ascending", MenuChoice.OrderByAscending }
    };
}