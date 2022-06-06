using cs_app.Data.DTOs;
using cs_app.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_app.Data.Services
{
    public class OrderService
    {
        private EducationContext _context;

        public OrderService(EducationContext context)
        {
            _context = context;
        }


        
        public async Task<Order?> AddOrder(OrderDTO order)
        {
            Order norder = new Order
            {
                OrderAmount = order.OrderAmount,
                Customer = order.Customer,
                Id = order.Id,
                
            };
            if (order.Items.Any())
            {
                norder.Items = _context.Items.ToList().IntersectBy(order.Items, items => items.Id).ToList();
            }

            var result = _context.Orders.Add(norder);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }

        
        public async Task<List<Order>> GetOrders()
        {
            var result = await _context.Orders.Include(a => a.Customers).Include(b => b.Items).ToListAsync();
            return await Task.FromResult(result);
        }

        
        public async Task<Order?> GetOrder(int id)
        {
            var result = _context.Orders.Include(a => a.Customers).Include(b => b.Items)
                .FirstOrDefault(order => order.Id == id);

            return await Task.FromResult(result);
        }

        //Метод получения неполной информации об отеле
        public async Task<List<IncompleteOrderDTO>> GetOrdersIncomplete()
        {
            var orders = await _context.Orders.ToListAsync();
            List<IncompleteOrderDTO> result = new List<IncompleteOrderDTO>();
            orders.ForEach(au => result.Add(new IncompleteOrderDTO
            {
                Id = au.Id,
                OrderAmount = au.OrderAmount
            }));
            return await Task.FromResult(result);
        }

        //Метод обновления информации об отеле
        public async Task<Order?> UpdateOrder(int id, OrderDTO updatedOrder)
        {
            var order = await _context.Orders.Include(order => order.Customer).Include(b => b.Items)
                .FirstOrDefaultAsync(au => au.Id == id);
            if (order != null)
            if (order != null)
            {
                order.Customer = updatedOrder.Customer;
                order.OrderAmount = updatedOrder.OrderAmount;
                if (updatedOrder.Items.Any())
                {
                    order.Items = _context.Items.ToList().IntersectBy(updatedOrder.Items, item => item.Id).ToList();
                }
                if (updatedOrder.Customers.Any())
                {
                    order.Customers = _context.Customers.ToList().IntersectBy(updatedOrder.Customers, customer => customer.Id).ToList();
                }

                _context.Orders.Update(order);
                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return order;
            }

            return null;
        }

        //метод удаления отеля
        public async Task<bool> DeleteOrder(int id)
        {
            var order = await _context.Orders.FirstOrDefaultAsync(au => au.Id == id);
            if (order != null)
            {
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}