using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class CourseEnrolment
{
    public int EnrolmentsId { get; set; }

    public int StudentIdFk { get; set; }

    public int CourseIdFk { get; set; }

    public string? Grade { get; set; }

    public int? GradeSetterFk { get; set; }

    public DateOnly? GradingDate { get; set; }

    public virtual Course CourseIdFkNavigation { get; set; } = null!;

    public virtual Teacher? GradeSetterFkNavigation { get; set; }

    public virtual Student StudentIdFkNavigation { get; set; } = null!;
}
