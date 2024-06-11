using Kolokwium2.DTOs;
using Kolokwium2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CharactersController : ControllerBase
{
    private readonly IMasterService _masterService;
    public CharactersController(IMasterService masterService)
    {
        _masterService = masterService;
    }

    [HttpGet("${characterId}")]
    public async Task<IActionResult> GetCharactersData(int characterId)
    {
        var characters = await _masterService.GetCharactersData(characterId);

        return Ok(characters.Select(e => new GetCharactersDTO()
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWeight = e.CurrentWeight,
            MaxWeight = e.MaxWeight,
            backpackItems = e.Backpacks.Select(p => new GetBackpacksDTO
            {
                ItemName = p.Item.Name,
                ItemWeight = p.Item.Weight,
                Amount = p.Amount
            }).ToList(),
            titles = e.CharacterTitles.Select(p => new GetCharacterTitlesDTO
            {
                Title = p.Title.Name,
                AcquiredAt = p.AcquiredAt
            }).ToList()
        }));

    }
}
