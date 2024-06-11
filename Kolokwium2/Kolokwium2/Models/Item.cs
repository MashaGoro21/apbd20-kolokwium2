using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public partial class Item
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public int Weight { get; set; }

    public virtual ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();
}
