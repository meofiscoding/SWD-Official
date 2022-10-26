using System;
using System.Collections.Generic;

namespace App.DAL.Models;

public partial class CardBox
{
    public int CardBoxId { get; set; }

    public int UserId { get; set; }

    public int CardId { get; set; }

    public int CreatedDate { get; set; }

    public int Status { get; set; }

    public virtual Card Card { get; set; } = null!;
}
