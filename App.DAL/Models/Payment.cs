using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class Payment
{
    public int PaymentId { get; set; }

    public int UserId { get; set; }

    public string TransactionId { get; set; } = null!;

    public double Amount { get; set; }

    public bool Status { get; set; }

    public virtual User User { get; set; } = null!;
}
