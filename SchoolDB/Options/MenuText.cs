namespace SchoolDB.Options;

public static class MenuText
{
    // Menu options.
    public enum MenuChoice
    {
        // Main Menu.
        Employees,
        Students,
        Classes,
        Courses,
        RecentlySetGrades,
        AddStudent,
        AddEmployee,
        Exit,
        
        // Employee Menu.
        AllEmployees,
        AllEmployeesWithAssignedRoles,
        Principal,
        Admins,
        Teachers,
        
        // Student Menu.
        SortByFirstName, // 13
        SortByLastName, // 14
        OrderByDescending, // 15
        OrderByAscending, // 16
        
        // Class Menu.
        SoftwareEngineering,
        DataScience,
        AiAndMachineLearning,
    }
    
    // Main Menu Options.
    public static readonly Dictionary<string, MenuChoice> MainMenuText = new()
    {
        { "Employees", MenuChoice.Employees },
        { "Students", MenuChoice.Students },
        { "Classes", MenuChoice.Classes },
        { "Courses", MenuChoice.Courses },
        { "Recently set grades", MenuChoice.RecentlySetGrades },
        { "Add a student", MenuChoice.AddStudent },
        { "Add an employee", MenuChoice.AddEmployee },
        { "Exit", MenuChoice.Exit }
    };
    
    // Employee Menu Options.
    public static readonly Dictionary<string, MenuChoice> EmployeeMenuText = new()
    {
        { "All employees", MenuChoice.AllEmployees},
        { "All employees with assigned roles", MenuChoice.AllEmployeesWithAssignedRoles},
        { "Principal", MenuChoice.Principal },
        { "Admins", MenuChoice.Admins },
        { "Teachers", MenuChoice.Teachers },
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