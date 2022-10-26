using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class Role
{
    public int RoleId { get; set; }

    public string RoleName { get; set; } = null!;

    public int Status { get; set; }
}
