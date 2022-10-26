﻿using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class CardType
{
    public int TypeId { get; set; }

    public string TypeName { get; set; } = null!;

    public int Status { get; set; }

    public virtual ICollection<TemplateCard> TemplateCards { get; } = new List<TemplateCard>();
}