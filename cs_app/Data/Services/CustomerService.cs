using cs_app.Data;
using cs_app.Data.DTOs;
using cs_app.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace cs_app.Data.Services
{
    public class CustomerService
    {
        private EducationContext _context;
        public CustomerService(EducationContext context)
        {
            _context = context;
        }


        //метод создания клиента
        public async Task<Customer?> AddCustomer(CustomerDTO customer)
        {
            Customer ncustomer = new Customer()
            {
                Id = customer.Id,
                Name = customer.Name,
                PhoneNumber = customer.PhoneNumber,
                Email = customer.Email,
                PassportDetails = customer.PassportDetails
            };
            if (customer.Orders.Any())
            {
                ncustomer.Orders = _context.Orders.ToList().IntersectBy(customer.Items, order => order.Id).ToList();
            }
            var result = _context.Customers.Add(ncustomer);
            await _context.SaveChangesAsync();
            return await Task.FromResult(result.Entity);
        }
        //Метод получения клиента
        public async Task<List<Customer>> GetCustomers()
        {
            var result = await _context.Customers.Include(a => a.Orders).Include(b => b.Items).ToListAsync();
            return await Task.FromResult(result);
        }
        //Метод получения клиента по ID
        public async Task<Customer?> GetCustomers(int id)
        {

            var result = _context.Customers.Include(a => a.Orders).
                                        Include(b => b.Items).
                                        FirstOrDefault(customer => customer.Id == id);

            return await Task.FromResult(result);
        }
        //Метод получения неполной информации об отеле
        public async Task<List<IncompleteCustomerDTO>> GetCustomersIncomplete()
        {
            var customers = await _context.Customers.ToListAsync();
            List<IncompleteCustomerDTO> result = new List<IncompleteCustomerDTO>();
            customers.ForEach(au => result.Add(new IncompleteCustomerDTO
            {
                Id = au.Id,
                Name = au.Name
            }));
            return await Task.FromResult(result);
        }
        //Метод обновления информации об отеле
        public async Task<Customer?> UpdateCustomer(int id, CustomerDTO updatedCustomer)
        {
            var customer = await _context.Customers.Include(customer => customer.Orders).
                                              Include(b => b.Items).
                                              FirstOrDefaultAsync(au => au.Id == id);
            if (customer != null)
            {
                customer.Name = updatedCustomer.Name;
                customer.PhoneNumber = updatedCustomer.PhoneNumber;
                customer.Email = updatedCustomer.Email;
                customer.PassportDetails = updatedCustomer.PassportDetails;
                if (updatedCustomer.Orders.Any())
                {
                    customer.Orders = _context.Orders.ToList().IntersectBy(updatedCustomer.Orders, orders => orders.Id).ToList();
                }
                if (updatedCustomer.Items.Any())
                {
                    customer.Items = _context.Items.ToList().IntersectBy(updatedCustomer.Items, item => item.Id).ToList();
                }
                _context.Customers.Update(customer);
                _context.Entry(customer).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return customer;
            }
            return null;
        }
        //метод удаления отеля
        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(au => au.Id == id);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
