using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class Card
{
    public int CardId { get; set; }

    public int TemplateId { get; set; }

    public string CardContent { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public int Status { get; set; }

    public virtual ICollection<CardBox> CardBoxes { get; } = new List<CardBox>();

    public virtual TemplateCard Template { get; set; } = null!;
}
