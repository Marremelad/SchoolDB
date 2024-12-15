using SchoolDB.Options;
using SchoolDB.Services;
using Spectre.Console;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Views;

public static class MainMenu
{
    // Display the main menu.
    public static void DisplayMainMenu()
    {
        while (true)
        {
            Console.Clear();
            
            var choice = DisplayUi.DisplaySingleChoiceMenu("Welcome To SchoolDB", MainMenuText);

            switch (choice)
            {
                case MenuChoice.Employees:
                    EmployeeMenu.DisplayEmployeeMenu();
                    break;
                
                case MenuChoice.Students:
                    StudentMenu.DisplayStudentMenu();
                    break;
            
                case MenuChoice.Classes:
                    ClassMenu.DisplayClassMenu();
                    break;
            
                case MenuChoice.Courses:
                    CourseMenu.DisplayCourseMenu();
                    break;
                
                case MenuChoice.RecentlySetGrades:
                    Console.WriteLine(CourseEnrolmentRepository.DisplayRecentlySetGrades());
                    break;
                
                case MenuChoice.AddStudent:
                    Create.CreateNewStudent();
                    break;
                
                case MenuChoice.AddEmployee:
                    Create.CreateNewEmployee();
                    break;
                
                case MenuChoice.Exit:
                    return;
            }

            AnsiConsole.MarkupLine("\n[green]'Q'[/] to quit, or [green]Enter[/] to get back to the main menu");
            
            if (Console.ReadLine() == "Q".ToLower()) break;
        }
    }
}