using System;
using System.Collections.Generic;

namespace App.DAL.Models
{
    public partial class TemplateCard
    {
        public TemplateCard()
        {
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
        public virtual ICollection<Card> Cards { get; set; }
    }
}
