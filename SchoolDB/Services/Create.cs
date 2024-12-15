using SchoolDB.Repositories;

namespace SchoolDB.Services;

public class Create
{
    // Get user input to create a new student.
    public static void CreateNewStudent()
    {
        var firstName = Helper.GetFirstName("Please enter the new students first name.");
        
        var lastName = Helper.GetLastName("Please enter the new students last name.");
        
        var ssn = Helper.GetSsn("Please enter the new students SSN.");
        
        var classId = Helper.GetClassId("What class should the new student be enrolled into?");

        StudentRepository.AddStudentToDatabase(firstName, lastName, ssn, classId);
    }

    // Get user input to create a new employee.
    public static void CreateNewEmployee()
    {
        var firstName =  Helper.GetFirstName("Please enter the new employees first name.");
        
        var lastName =  Helper.GetLastName("Please enter the new employees last name.");
        
        EmployeeRepository.AddEmployeeToDatabase(firstName, lastName);
    }
}