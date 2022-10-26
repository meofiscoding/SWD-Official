using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class User
{
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

    public virtual ICollection<Payment> Payments { get; } = new List<Payment>();

    public virtual ICollection<Receipt> Receipts { get; } = new List<Receipt>();
}
