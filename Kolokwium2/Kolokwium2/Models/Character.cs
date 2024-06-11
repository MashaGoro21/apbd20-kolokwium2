using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public partial class Character
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [MaxLength(120)]
    public string LastName { get; set; } = string.Empty;

    public int CurrentWeight { get; set; }

    public int MaxWeight { get; set; }

    public virtual ICollection<Backpack> Backpacks { get; set; } = new HashSet<Backpack>();

    public virtual ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}
