
using BlazorApp1.Data;
using BlazorApp1.Data.Models;

namespace BlazorApp1.Data.Services;

public interface IItemProvider
{
     Task<List<Item>> GetAll();
     Task<Item> GetOne(int id);
     Task<bool> Add(Item item1);
     Task<Item> Edit(Item item1);
    Task<bool> Remove(int id);

}