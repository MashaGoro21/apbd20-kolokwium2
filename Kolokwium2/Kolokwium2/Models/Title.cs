using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Kolokwium2.Models;

public partial class Title
{
    [Key]
    public int Id { get; set; }

    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;

    public virtual ICollection<CharacterTitle> CharacterTitles { get; set; } = new HashSet<CharacterTitle>();
}
