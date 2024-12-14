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

    public static readonly Dictionary<string, MenuChoice> ClassMenuText = new()
    {
        // Class Menu Options.
        { "SoftwareEngineering2024", MenuChoice.SoftwareEngineering },
        { "DataScience2024", MenuChoice.DataScience },
        { "AIAndMachineLearning2024", MenuChoice.AiAndMachineLearning }
    };
}