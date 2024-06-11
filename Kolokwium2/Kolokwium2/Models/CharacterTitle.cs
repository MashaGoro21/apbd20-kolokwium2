using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Models;


[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public partial class CharacterTitle
{
    public int CharacterId { get; set; }

    public int TitleId { get; set; }

    public DateTime AcquiredAt { get; set; }

    [ForeignKey(nameof(CharacterId))]
    public virtual Character Character { get; set; } = null!;

    [ForeignKey(nameof(TitleId))]
    public virtual Title Title { get; set; } = null!;
}
