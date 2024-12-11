using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class EmployeeRole
{
    public int EmployeeRoleId { get; set; }

    public int EmployeeIdFk { get; set; }

    public int RoleIdFk { get; set; }

    public virtual Employee EmployeeIdFkNavigation { get; set; } = null!;

    public virtual Role RoleIdFkNavigation { get; set; } = null!;
}
