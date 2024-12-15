using SchoolDB.Options;
using SchoolDB.Repositories;
using SchoolDB.Services;
using Spectre.Console;

namespace SchoolDB.Views;

public static class MainMenu
{
    // Display the main menu.
    public static void DisplayMainMenu()
    {
        while (true)
        {
            Console.Clear();
            
            var choice = DisplayUi.DisplaySingleChoiceMenu("Welcome To SchoolDB", MenuText.MainMenuText);

            switch (choice)
            {
                case MenuText.MenuChoice.Employees:
                    EmployeeMenu.DisplayEmployeeMenu();
                    break;
                
                case MenuText.MenuChoice.Students:
                    StudentMenu.DisplayStudentMenu();
                    break;
            
                case MenuText.MenuChoice.Classes:
                    ClassMenu.DisplayClassMenu();
                    break;
            
                case MenuText.MenuChoice.Courses:
                    CourseMenu.DisplayCourseMenu();
                    break;
                
                case MenuText.MenuChoice.RecentlySetGrades:
                    Console.WriteLine(CourseEnrolmentRepository.DisplayRecentlySetGrades());
                    break;
                
                case MenuText.MenuChoice.AddStudent:
                    Create.CreateNewStudent();
                    break;
                
                case MenuText.MenuChoice.AddEmployee:
                    Create.CreateNewEmployee();
                    break;
                
                case MenuText.MenuChoice.Exit:
                    return;
            }

            AnsiConsole.MarkupLine("\n[green]'Q'[/] to quit, or [green]Enter[/] to get back to the main menu");
            
            if (Console.ReadLine() == "Q".ToLower()) break;
        }
    }
}