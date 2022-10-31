using System;
using System.Collections.Generic;

namespace App.DAL.Entity
{
    public partial class TemplateCard
    {
        public TemplateCard()
        {
            ApplyingDiscounts = new HashSet<ApplyingDiscount>();
            Cards = new HashSet<Card>();
        }

        public int TemplateId { get; set; }
        public int TypeId { get; set; }
        public string Title { get; set; } = null!;
        public double Price { get; set; }
        public int Status { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string? FileName { get; set; }

        public virtual CardType Type { get; set; } = null!;
        public virtual ICollection<ApplyingDiscount> ApplyingDiscounts { get; set; }
        public virtual ICollection<Card> Cards { get; set; }
    }
}
