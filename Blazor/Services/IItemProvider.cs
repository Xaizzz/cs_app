using Blazor.Data.Models;

namespace Blazor.Services
{
    public interface IItemProvider //интерфейс, описывающий получение данных по билетам
    {
        Task<List<Item>> GetAll();
        Task<Item> GetOne(int id);
        Task<bool> Add(Item item);
        Task<Item> Edit(Item item);
        Task<bool> Remove(int id);
    }
}
