using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();
}
