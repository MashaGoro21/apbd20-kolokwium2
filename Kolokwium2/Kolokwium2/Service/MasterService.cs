using Kolokwium2.Models;
using Kolokwium2.Data;
using Microsoft.EntityFrameworkCore;

namespace Kolokwium2.Service;

public class MasterService : IMasterService
{
    private readonly MasterContext _context;
    public MasterService(MasterContext context)
    {
        _context = context;
    }

    public async Task<ICollection<Character>> GetCharactersData(int characterId)
    {
        return await _context.Characters
            .Include(e => e.Backpacks)
            .Include(e => e.CharacterTitles)
            .ThenInclude(e => e.Title)
            .Include(e => e.Backpacks)
            .ThenInclude(e => e.Item)
            .Where(e => e.Id == characterId)
            .ToListAsync();
    }

    public async Task<bool> DoesCharacterExist(int characterId)
    {
        return await _context.Characters.AnyAsync(e => e.Id == characterId);
    }

    public async Task<bool> DoesItemExist(int itemId)
    {
        return await _context.Items.AnyAsync(e => e.Id == itemId);
    }

    public async Task AddNewBackpack(Backpack backpack)
    {
        await _context.AddAsync(backpack);
        await _context.SaveChangesAsync();
    }

    public async Task<Item> GetItemById(int itemId)
    {
        return await _context.Items.FirstOrDefaultAsync(e => e.Id == itemId);
    }

    public async Task<Character> GetCharacterById(int characterId)
    {
        return await _context.Characters.FirstOrDefaultAsync(e => e.Id == characterId);
    }
}
