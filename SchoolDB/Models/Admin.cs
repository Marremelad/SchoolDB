using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class Admin
{
    public int AdminId { get; set; }

    public int EmployeeIdFk { get; set; }

    public virtual ICollection<Class> Classes { get; set; } = new List<Class>();

    public virtual Employee EmployeeIdFkNavigation { get; set; } = null!;
}
