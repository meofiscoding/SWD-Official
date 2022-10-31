using System;
using System.Collections.Generic;

namespace App.DAL.Entity
{
    public partial class User
    {
        public User()
        {
            CardBoxes = new HashSet<CardBox>();
            Payments = new HashSet<Payment>();
            Receipts = new HashSet<Receipt>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Fullname { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string IdentityNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Address { get; set; } = null!;
        public int RoleId { get; set; }
        public int Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<CardBox> CardBoxes { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
        public virtual ICollection<Receipt> Receipts { get; set; }
    }
}
