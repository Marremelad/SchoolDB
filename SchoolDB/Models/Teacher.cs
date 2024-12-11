using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class Teacher
{
    public int TeacherId { get; set; }

    public int EmployeeIdFk { get; set; }

    public virtual ICollection<CourseAssignment> CourseAssignments { get; set; } = new List<CourseAssignment>();

    public virtual ICollection<CourseEnrolment> CourseEnrolments { get; set; } = new List<CourseEnrolment>();

    public virtual Employee EmployeeIdFkNavigation { get; set; } = null!;
}
