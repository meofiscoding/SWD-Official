using System;
using System.Collections.Generic;

namespace App.DAL.Entity
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
        public int Status { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
