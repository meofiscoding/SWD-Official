using System;
using System.Collections.Generic;

namespace App.DAL.Entity
{
    public partial class Discount
    {
        public Discount()
        {
            ApplyingDiscounts = new HashSet<ApplyingDiscount>();
        }

        public int DiscountId { get; set; }
        public int DiscountPercent { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Status { get; set; }

        public virtual ICollection<ApplyingDiscount> ApplyingDiscounts { get; set; }
    }
}
