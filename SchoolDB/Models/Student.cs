using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class Student
{
    public int StudentId { get; set; }

    public string StudentFirstName { get; set; } = null!;

    public string StudentLastName { get; set; } = null!;

    public string? StudentSsn { get; set; }

    public int ClassIdFk { get; set; }

    public virtual Class ClassIdFkNavigation { get; set; } = null!;

    public virtual ICollection<CourseEnrolment> CourseEnrolments { get; set; } = new List<CourseEnrolment>();
}
