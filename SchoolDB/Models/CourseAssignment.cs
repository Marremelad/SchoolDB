using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class CourseAssignment
{
    public int AssignmentId { get; set; }

    public int TeacherIdFk { get; set; }

    public int CourseIdFk { get; set; }

    public virtual Course CourseIdFkNavigation { get; set; } = null!;

    public virtual Teacher TeacherIdFkNavigation { get; set; } = null!;
}
