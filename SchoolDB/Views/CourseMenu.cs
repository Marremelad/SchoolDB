using SchoolDB.Services;

namespace SchoolDB.Views;

public static class CourseMenu
{
    // Display the course menu.
    public static void DisplayCourseMenu()
    {
        var choice = DisplayUi.DisplaySingleChoiceMenu("Select a course to show it's statistics", CourseRepository.DisplayCourses());

        Console.WriteLine(CourseEnrolmentRepository.DisplayCourseStats((string)choice));
        
    }
}