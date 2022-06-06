using cs_app.Data.DTOs;
using cs_app.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace cs_app.Data.Services
{
    public class ItemService
    {
        private EducationContext _context;

        public ItemService(EducationContext context)
        {
            _context = context;
        }


        
        public async Task<Item?> AddItem(ItemDTO item)
        {
            Item nitem = new Item
            {
                Id = item.Id,
                Description = item.Description,
                DateOfService = item.DateOfService,
                Parameters = item.Parameters,
                QuantityInStock = item.QuantityInStock,
                Name = item.Name,
                Cost = item.Cost,
                CompanyName = item.CompanyName
            };
            if (item.Customers.Any())
            {
                nitem.Customers = _context.Customers.ToList().IntersectBy(item.Customers, order => order.Id).ToList();
            }

            var result = _context.Items.Add(nitem);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        //Метод получения отеля
        public async Task<List<Item>> GetItems()
        {
            var result = await _context.Items.Include(a => a.Customers).Include(b => b.Orders).ToListAsync();
            return await Task.FromResult(result);
        }

        //Метод получения отеля по ID
        public async Task<Item?> GetItem(long id)
        {
            var result = _context.Items.Include(a => a.Customers).Include(b => b.Orders)
                .FirstOrDefault(item => item.Id == id);

            return await Task.FromResult(result);
        }

        //Метод получения неполной информации об отеле
        public async Task<List<IncompleteItemDTO>> GetItemsIncomplete()
        {
            var items = await _context.Items.ToListAsync();
            List<IncompleteItemDTO> result = new List<IncompleteItemDTO>();
            items.ForEach(au => result.Add(new IncompleteItemDTO
            {
                Id = au.Id,
                Name = au.Name,
                Description = au.Description,
                QuantityInStock = au.QuantityInStock,
                Cost = au.Cost,
                CompanyName = au.CompanyName,
                Parameters = au.Parameters
                
            }));
            return await Task.FromResult(result);
        }

        //Метод обновления информации об отеле
        public async Task<Item?> UpdateItem(long id, ItemDTO updatedItem)
        {
            var item = await _context.Items.Include(item => item.Customers).Include(b => b.Orders)
                .FirstOrDefaultAsync(au => au.Id == id);
            if (item != null)
            {
                item.Name = updatedItem.Name;
                item.Cost = updatedItem.Cost;
                item.Description = updatedItem.Description;
                item.Parameters = updatedItem.Parameters;
                item.CompanyName = updatedItem.CompanyName;
                item.QuantityInStock = updatedItem.QuantityInStock;
                item.DateOfService = updatedItem.DateOfService;
                if (updatedItem.Customers.Any())
                {
                    item.Customers = _context.Customers.ToList()
                        .IntersectBy(updatedItem.Customers, customer => customer.Id).ToList();
                }

                if (updatedItem.Orders.Any())
                {
                    item.Orders = _context.Orders.ToList().IntersectBy(updatedItem.Orders, orders => orders.Id).ToList();
                }

                _context.Items.Update(item);
                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return item;
            }

            return null;
        }

        //метод удаления отеля
        public async Task<bool> DeleteItem(long id)
        {
            var item = await _context.Items.FirstOrDefaultAsync(au => au.Id == id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}