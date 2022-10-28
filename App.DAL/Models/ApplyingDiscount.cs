using System;
using System.Collections.Generic;

namespace App.DAL.Models
{
    public partial class ApplyingDiscount
    {
        public int ApplyingDiscountId { get; set; }
        public int TemplateCardId { get; set; }
        public int DiscountId { get; set; }

        public virtual Discount Discount { get; set; } = null!;
    }
}
