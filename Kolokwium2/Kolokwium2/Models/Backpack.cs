using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;

[PrimaryKey(nameof(ItemId), nameof(CharacterId))]
public partial class Backpack
{
    public int ItemId { get; set; }

    public int CharacterId { get; set; }

    public int Amount { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public virtual Character Character { get; set; } = null!;

    [ForeignKey(nameof(ItemId))]
    public virtual Item Item { get; set; } = null!;
}
