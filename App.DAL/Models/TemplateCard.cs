using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class TemplateCard
{
    public int TemplateId { get; set; }

    public int TypeId { get; set; }

    public string Title { get; set; } = null!;

    public double Price { get; set; }

    public int Status { get; set; }

    public virtual ICollection<Card> Cards { get; } = new List<Card>();

    public virtual CardType Type { get; set; } = null!;
}
