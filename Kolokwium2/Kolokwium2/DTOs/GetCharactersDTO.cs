namespace Kolokwium2.DTOs;

public class GetCharactersDTO
{
    public string FirstName { get; set; } = string.Empty;
    
    public string LastName { get; set; } = string.Empty;

    public int CurrentWeight { get; set; }

    public int MaxWeight { get; set; }

    public ICollection<GetBackpacksDTO> backpackItems { get; set; } = null!;
    public ICollection<GetCharacterTitlesDTO> titles { get; set; } = null!;
}

public class GetBackpacksDTO
{
    public string ItemName { get; set; } = string.Empty;

    public int ItemWeight { get; set; }
    
    public int Amount { get; set; }
}

public class GetCharacterTitlesDTO
{
    public string Title { get; set; } = string.Empty;
    
    public DateTime AcquiredAt { get; set; }
}