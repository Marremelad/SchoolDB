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
        OrderByAscending,
        
        // Class Menu.
        SoftwareEngineering,
        DataScience,
        AiAndMachineLearning
    }
    
    // Main Menu Options.
    public static readonly Dictionary<string, MenuChoice> MainMenuText = new()
    {
        { "All Employees", MenuChoice.Employees },
        { "Admins", MenuChoice.Admins },
        { "Teachers", MenuChoice.Teachers },
        { "Students", MenuChoice.Students },
        { "Classes", MenuChoice.Classes }
    };

    // Student Menu Options.
    public static readonly Dictionary<string, MenuChoice> StudentMenuText = new()
    {
        { "Sort by First Name", MenuChoice.SortByFirstName },
        { "Sort by Last Name", MenuChoice.SortByLastName },
        { "Order by Descending", MenuChoice.OrderByDescending },
        { "Order by Ascending", MenuChoice.OrderByAscending }
    };

    // Class Menu Options.
    public static readonly Dictionary<string, MenuChoice> ClassMenuText = new()
    {
        { "SoftwareEngineering2024", MenuChoice.SoftwareEngineering },
        { "DataScience2024", MenuChoice.DataScience },
        { "AIAndMachineLearning2024", MenuChoice.AiAndMachineLearning }
    };
}