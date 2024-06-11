using Kolokwium2.Models;

namespace Kolokwium2.Service;

public interface IMasterService
{
    Task<ICollection<Character>> GetCharactersData(int characterId);
    Task<bool> DoesCharacterExist(int characterId);
    Task<bool> DoesItemExist(int itemId);
    Task AddNewBackpack(Backpack backpack);
    Task<Item> GetItemById(int itemId);
    Task<Character> GetCharacterById(int characterId);
    
}