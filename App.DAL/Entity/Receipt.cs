using System;
using System.Collections.Generic;

namespace App.DAL.Entity
{
    public partial class Receipt
    {
        public int ReceiptId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual User User { get; set; } = null!;
    }
}
