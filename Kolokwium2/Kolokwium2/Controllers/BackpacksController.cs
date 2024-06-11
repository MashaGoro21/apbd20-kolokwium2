using System.Transactions;
using Kolokwium2.DTOs;
using Kolokwium2.Models;
using Kolokwium2.Service;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BackpacksController : ControllerBase
{
    private readonly IMasterService _masterService;
    public BackpacksController(IMasterService masterService)
    {
        _masterService = masterService;
    }

    [HttpPost]
    public async Task<IActionResult> AddNewBackPack(NewBackpacksDTO newBackpacksDto)
    {
        if (!await _masterService.DoesCharacterExist(newBackpacksDto.CharacterId))
            return NotFound($"Character with given ID - {newBackpacksDto.CharacterId} doesn't exist");

        if (!await _masterService.DoesItemExist(newBackpacksDto.ItemId))
            return NotFound($"Item with given ID - {newBackpacksDto.ItemId} doesn't exist");

        Character character = await _masterService.GetCharacterById(newBackpacksDto.CharacterId);
        Item item = await _masterService.GetItemById(newBackpacksDto.ItemId);

        if (character.CurrentWeight + item.Weight > character.MaxWeight)
        {
            return BadRequest($"Character hasn't enough free weight for new item");
        }
        
        var backpack = new Backpack()
        {
            Amount = newBackpacksDto.Amount,
            ItemId = newBackpacksDto.ItemId,
            CharacterId = newBackpacksDto.CharacterId
        };
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            await _masterService.AddNewBackpack(backpack);
            scope.Complete();
        }


        return Created("api/backpacks", new
        {
            backpack.Amount,
            backpack.ItemId,
            backpack.CharacterId
        });
    }
    
}