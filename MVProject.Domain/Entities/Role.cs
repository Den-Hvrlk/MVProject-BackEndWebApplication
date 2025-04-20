using System;
using System.Collections.Generic;

namespace MVProject.Domain.Entities;

public partial class Role
{
    public int ID_Role { get; set; }

    public string RoleName { get; set; } = null!;

    public virtual ICollection<User> ID_Users { get; set; } = new List<User>();
}
