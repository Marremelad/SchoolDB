using SchoolDB.Repositories;
using SchoolDB.Services;
using static SchoolDB.Options.MenuText;

namespace SchoolDB.Views;

public static class EmployeeMenu
{
    // Display the employee menu.
    public static void DisplayEmployeeMenu()
    {
        var choice = DisplayUi.DisplaySingleChoiceMenu("Select an option", EmployeeMenuText);

        switch ((MenuChoice)choice)
        {
            case MenuChoice.AllEmployees:
                Console.WriteLine(EmployeeRepository.DisplayAllEmployees());
                break;
            
            case MenuChoice.AllEmployeesWithAssignedRoles:
                Console.WriteLine(EmployeeRoleRepository.DisplayEmployeesWithRoles());
                break;
            
            case MenuChoice.Principal:
                Console.WriteLine(EmployeeRepository.DisplayPrincipal());
                break;
            
            case MenuChoice.Admins:
                Console.WriteLine(AdminRepository.DisplayAdminsWithClasses());
                break;
            
            case MenuChoice.Teachers:
                Console.WriteLine(CourseAssignmentRepository.DisplayTeachersWithCourses());
                break;
        }
    }
}