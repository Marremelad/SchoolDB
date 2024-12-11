using System;
using System.Collections.Generic;

namespace SchoolDB.Models;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string EmployeeFirstName { get; set; } = null!;

    public string EmployeeLastName { get; set; } = null!;

    public virtual ICollection<Admin> Admins { get; set; } = new List<Admin>();

    public virtual ICollection<EmployeeRole> EmployeeRoles { get; set; } = new List<EmployeeRole>();

    public virtual ICollection<Teacher> Teachers { get; set; } = new List<Teacher>();
}
