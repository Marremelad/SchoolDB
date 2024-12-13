using SchoolDB.Services;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Views;

public static class MainMenu
{
    public static void DisplayMainMenu()
    {
        var choice = DisplayUi.DisplaySingleChoiceMenu("Welcome To SchoolDB", MainMenuText);

        switch (choice)
        {
            case MenuChoice.Employees:
                Console.WriteLine(EmployeeRoleRepository.GetEmployeesWithRoles());
                break;
            
            case MenuChoice.Admins:
                Console.WriteLine(AdminRepository.GetAdminsWithClasses());
                break;
            
            case MenuChoice.Teachers:
                Console.WriteLine(CourseAssignmentRepository.GetTeachersWithCourses());
                break;
            
            case MenuChoice.Students:
                StudentMenu.DisplayStudentMenu();
                break;
        }
    }
}